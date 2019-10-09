using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PayProject.DTO;
using PayProject.Logic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PayProject.WebAdmin.MQ.Consumer
{
    public class PayOrderNotifyService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IConnection _rabbitConnection;
        private readonly IModel _channel;

        public PayOrderNotifyService(ILogger<PayOrderNotifyService> logger, IConnection rabbitConnection)
        {
            _logger = logger;
            _rabbitConnection = rabbitConnection;
            _channel = _rabbitConnection.CreateModel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        { 
            var exchangeD = "PayOrderNotify.exchange";
            var routeD = "PayOrderNotify.route";
            var queueD = "PayOrderNotify.queue";

            _channel.BasicQos(0, 1, false);
            _channel.ExchangeDeclare(exchangeD, type: "fanout", durable: true, autoDelete: false);
            _channel.QueueDeclare(queueD, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queueD, exchangeD, routeD);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                //The safebox_withdraw is always successful.
                try
                {
                    var msg = JsonConvert.DeserializeObject<PayOrderNotifyMsg>(Encoding.UTF8.GetString(ea.Body));
                    _channel.BasicAck(ea.DeliveryTag, false);
                    PayOrderBll._.SendNotify(msg.orderid);
                }
                catch (AlreadyClosedException ex)
                {
                    _logger.LogCritical(ex, "RabbitMQ is closed!");
                }
            };

            _channel.BasicConsume(queueD, false, consumer);
            _logger.LogInformation("queueD started...");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("queueD ended...");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();

            _rabbitConnection?.Close();
            _rabbitConnection?.Dispose();
        }
    }
}

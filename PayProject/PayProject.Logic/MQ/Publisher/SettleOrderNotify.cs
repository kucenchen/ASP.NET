using Newtonsoft.Json;
using PayProject.DTO;
using PayProject.Extensions;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Logic.MQ.Publisher
{
    public class SettleOrderNotify
    {
        ConnectionFactory factory = null;
        public SettleOrderNotify()
        {
            factory = new ConnectionFactory
            {
                Uri = new Uri(WebConfig.rabbitMqConnection),
                AutomaticRecoveryEnabled = true
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ttl">秒</param>
        public void PublishMessage(SettleOrderNotifyMsg msg, int ttl)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var _channel = connection.CreateModel())
                {
                    var exchangeA = string.Format("SettleOrderNotify.exchange.Delay_ttl_{0}", ttl);
                    var routeA = string.Format("SettleOrderNotify.route.Delay_ttl_{0}", ttl);
                    var queueA = string.Format("SettleOrderNotify.queue.Delay_ttl_{0}", ttl);

                    var exchangeD = "SettleOrderNotify.exchange";
                    var routeD = "SettleOrderNotify.route";
                    var queueD = "SettleOrderNotify.queue";

                    //_channel.BasicQos(0, 1, false);
                    _channel.ExchangeDeclare(exchangeD, type: "fanout", durable: true, autoDelete: false);
                    _channel.QueueDeclare(queueD, durable: true, exclusive: false, autoDelete: false);
                    _channel.QueueBind(queueD, exchangeD, routeD);

                    //死信交换 这样10秒后消息过期，可以看到queueD中有了消息
                    _channel.ExchangeDeclare(exchangeA, type: "fanout", durable: true, autoDelete: false);
                    _channel.QueueDeclare(queueA, durable: true, exclusive: false, autoDelete: false, arguments: new Dictionary<string, object> {
                                         { "x-dead-letter-exchange",exchangeD}, //设置当前队列的DLX
                                         { "x-dead-letter-routing-key",routeD}, //设置DLX的路由key，DLX会根据该值去找到死信消息存放的队列
                                         { "x-message-ttl",ttl*1000 } //设置消息的存活时间，即过期时间
                                         });
                    _channel.QueueBind(queueA, exchangeA, routeA);
                    _channel.ConfirmSelect();

                    var properties = _channel.CreateBasicProperties();
                    properties.Persistent = true;
                    //发布消息
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(msg));
                    _channel.BasicPublish(exchange: exchangeA, routingKey: routeA, basicProperties: properties, body: body);
                }
            }
        }
    }
}

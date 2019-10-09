using EasyNetQ.AutoSubscribe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayProject.Mq.Messages;
using PayProject.Bll;
using EasyNetQ.Topology;

namespace PayProject.Mq.Subscribe
{
    public class PayOrderNotifyConsumer : IConsumeAsync<PayOrderNotify>
    {
        [AutoSubscriberConsumer(SubscriptionId = "PayOrderService")]

        public Task ConsumeAsync(PayOrderNotify message)
        {
            //System.Console.ForegroundColor = System.ConsoleColor.Red;
            //System.Console.WriteLine("收到Pay : {0}, {1:yyyy-MM-dd HH:mm:ss.fff}", message.orderid, DateTime.Now);
            //System.Console.ResetColor();

            //return Task.CompletedTask;
            return Pay_OrderBll.Instance.SendNotify(message.orderid);
            //业务代码
        }
    }
}

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
    public class SettleOrderNotifyConsumer : IConsumeAsync<SettleOrderNotify>
    {
        [AutoSubscriberConsumer(SubscriptionId = "SettleOrderService")]

        public Task ConsumeAsync(SettleOrderNotify message)
        {

            //System.Console.ForegroundColor = System.ConsoleColor.Red;
            //System.Console.WriteLine("收到Settle : {0}, {1:yyyy-MM-dd HH:mm:ss.fff}", message.orderid,DateTime.Now);
            //System.Console.ResetColor();

            //return Task.CompletedTask;
            return Settle_OrderBll.Instance.SendNotify(message.orderid);
            //业务代码
        }
    }
}

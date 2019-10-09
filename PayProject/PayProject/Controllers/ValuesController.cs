using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.AspNetCore.Mvc;
using PayProject.Mq.Messages;

namespace PayProject.Controllers
{
    //[Route("api/[controller]")]
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var m = DB.Context.From<PayProject.Model.Pay_mch>().First();
            m.Mch_key = DateTime.Now.ToString();
            m.Id = 0;
            var yyy = DB.Context.Update<PayProject.Model.Pay_mch>(new PayProject.Model.Pay_mch { Mch_key = "1233444"}, o=>o.Mch_id==m.Mch_id);

            string tt = PayProject.DB.Context.From<PayProject.Model.Pay_mch>().Select().Count().ToString();
            return new string[] { "value1"+tt, "value2" ,yyy.ToString() };
        }

        // GET api/values/5

        [HttpGet("/p/{id}")]
        public ActionResult<string> Get(string id)
        {

            //DB.RabbiBus.PublishAsync(new Mq.Messages.SettleOrderNotify { mchid = DB.MchId, orderid = id.ToString() });

            //return string.Format("{0} 时间 {1:yyyy-MM-dd HH:mm:ss.fff}", id, DateTime.Now);

            int ttl = 10;

            var channel = DB.RabbiBus.Advanced;

            var exchange = channel.ExchangeDeclare("OrderNotify.Delay.Exchange", ExchangeType.Direct);

            string key = string.Format("Pay.OrderNotify.Delay.Ttl_{0}", ttl);
            var queue = channel.QueueDeclare(key, deadLetterExchange: "Pay.OrderNotify", deadLetterRoutingKey: "#", perQueueMessageTtl: ttl * 1000);
            var binding = channel.Bind(exchange, queue, key);

            var message = new Message<Mq.Messages.PayOrderNotify>(new Mq.Messages.PayOrderNotify { mchid = DB.MchId, orderid = id });



            channel.Publish(exchange, key, false, message);


            return string.Format("{0} 时间 {1:yyyy-MM-dd HH:mm:ss.fff}", id, DateTime.Now);
        }

        [HttpGet("/s/{id}")]
        public ActionResult<string> PayGet(string id)
        {

            //DB.RabbiBus.PublishAsync(new Mq.Messages.SettleOrderNotify { mchid = DB.MchId, orderid = id.ToString() });

            //return string.Format("{0} 时间 {1:yyyy-MM-dd HH:mm:ss.fff}", id, DateTime.Now);
            int ttl = 10;

            var channel = DB.RabbiBus.Advanced;

            var exchange = channel.ExchangeDeclare("OrderNotify.Delay.Exchange", ExchangeType.Direct);

            string key = string.Format("Settle.OrderNotify.Delay.Ttl_{0}", ttl);
            var queue = channel.QueueDeclare(key, deadLetterExchange: "Settle.OrderNotify", deadLetterRoutingKey: "#", perQueueMessageTtl: ttl * 1000);
            var binding = channel.Bind(exchange, queue, key);

            var message = new Message<Mq.Messages.SettleOrderNotify>(new Mq.Messages.SettleOrderNotify { mchid = DB.MchId, orderid = id });

            channel.Publish(exchange, key, false, message);





            return string.Format("{0} 时间 {1:yyyy-MM-dd HH:mm:ss.fff}",id,DateTime.Now);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    
}

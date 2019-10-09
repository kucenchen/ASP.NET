using PayProject.Model;
using PayProject.Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayProject.Common;
using EasyNetQ;
using PayProject.Mq.Messages;
using EasyNetQ.Topology;
using Dos.ORM;

namespace PayProject.Bll
{
    public class Pay_OrderBll
    {
        private static readonly Pay_OrderBll instance = new Pay_OrderBll();

        // 显示的static 构造函数
        //没必要标记类型 - 在field初始化以前
        static Pay_OrderBll()
        {
        }

        private Pay_OrderBll()
        {
        }

        public static Pay_OrderBll Instance
        {
            get
            {
                return instance;
            }
        }



        /// <summary>
        /// 统一下单
        /// </summary>
        /// <param name="mchid"></param>
        /// <param name="orderid"></param>
        /// <param name="body"></param>
        /// <param name="paytype"></param>
        /// <param name="amount"></param>
        /// <param name="attach"></param>
        /// <param name="ip"></param>
        /// <param name="callbackurl"></param>
        /// <param name="notifyurl"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public async Task<UnifiedorderReturn> Unifiedorder(string mchid, string orderid, string body, int paytype, string amount, string attach, string ip, string callbackurl, string notifyurl)
        {


            UnifiedorderReturn r = new UnifiedorderReturn();

            //if (mchid != DB.MchId)
            //{
            //    //r.Type = PayReturnType.Err;
            //    //r.Content = "商户号不存在";
            //    //return r;
            //}


            decimal fee = 0;
            decimal.TryParse(amount, out fee);

            if (fee <= 0)
            {
                r.Type = PayReturnType.Err;
                r.Content = "支付金额必须大于0";
                return r;
            }
            Pay_mch m = null;
            try
            {
                m = OnlinePay.MchList.FindAll(pp => pp.Nullity == false && ("" + pp.Open_time + ",").Contains("," + DateTime.Now.Hour.ToString() + ",")
                    && ("," + pp.Open_pay_type_list + ",").Contains("," + paytype + ",")
                    && ("," + pp.Pay_money_list + ",").Contains("," + amount + ",")).OrderBy(i => Guid.NewGuid()).First();

            }
            catch (Exception ex)
            {
                string b = ex.ToString();
            }

            if (m == null)
            {
                r.Type = PayReturnType.Err;

                r.Content = "平台没有可用的支付渠道";
                return r;
            }

            Pay_plat p = OnlinePay.GetPlat(m.Plat_id);
            if (p == null)
            {
                r.Type = PayReturnType.Err;
                r.Content = "平台支付渠道有误";
                return r;
            }

            if (DB.Context.Exists<Pay_order>(o => o.Order_id == orderid))
            {
                r.Type = PayReturnType.Err;
                r.Content = "订单号已经存在";
                return r;
            }

            Pay_order order = new Pay_order();
            order.Order_id = orderid;
            order.Mch_id = m.Id;
            order.Order_amount = fee;
            order.Pay_amount = 0;
            order.Pay_type = paytype;
            order.Status = 0;
            order.Callback_url = callbackurl;
            order.Notify_url = notifyurl;
            order.Create_time = DateTime.Now.ToTimeStamp();
            order.Update_time = order.Create_time;
            order.Finish_time = order.Update_time;
            order.Notify_status = 0;
            order.Notify_lasttime = order.Update_time;
            order.Notify_times = 0;
            order.Attach = attach;
            order.Attach(EntityState.Added);
            OnlinePay onlinepay = null;
            try
            {
                string vDllName = "PayProject";
                //System.Reflection.Assembly tempAssembly = System.Reflection.Assembly.LoadFrom(vDllName);
                System.Reflection.Assembly tempAssembly = System.Reflection.Assembly.Load(vDllName);
                //Type _type = Type.GetType("PayProject.Pay." + p.Plat_class);
                Type _type = tempAssembly.GetType("PayProject.Pay." + p.Plat_class);
                onlinepay = (OnlinePay)Activator.CreateInstance(_type);
                onlinepay.setInfo(p.Plat_id, m.Mch_id);
                //onlinepay = (OnlinePay)tempAssembly.CreateInstance("PayProject.Pay." + p.Plat_class);
                // onlinepay = (OnlinePay)Activator.CreateInstance(typeof(plat_class), new object[] { p.Plat_id, m.Mch_id });
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }


            r = await onlinepay.Unifiedorder(orderid, paytype.ToString(), fee, ip, body, attach);

            if (r.Type != 0)
            {
                order.Plat_order_id = r.SerialNumber;
                order.Pay_amount = decimal.Parse(r.RealPrice);
            }

            DB.Context.Save(order);
            return r;
        }
        /// <summary>
        /// 查询接口
        /// </summary>
        /// <param name="mchid"></param>
        /// <param name="orderid"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public async Task<QueryReturn> Query(string mchid, string orderid)
        {
            QueryReturn r = new QueryReturn();




            if (mchid != DB.MchId)
            {
                r.ReturnMsg = "商户号不存在";
                return r;
            }


            Pay_order order = DB.Context.From<Pay_order>().Where(p => p.Order_id == orderid).ToFirstDefault();

            if (order == null || string.IsNullOrEmpty(order.Order_id))
            {
                r.ReturnMsg = "订单不存在";
                return r;
            }



            if (order.Status == 1)
            {
                r.ReturnMsg = "ok";
                r.IsPay = true;
                r.OrderNumber = order.Order_id;
                r.SerialNumber = order.Plat_order_id;
                r.Totalfee = order.Pay_amount;
                r.Attach = order.Attach;
                return r;
            }
            else
            {

                Pay_mch mch = OnlinePay.GetMch(order.Mch_id);

                if (mch == null)
                {
                    r.ReturnMsg = "平台商户信息错误";
                    return r;
                }

                Pay_plat plat = OnlinePay.GetPlat(mch.Plat_id);
                if (plat == null)
                {
                    r.ReturnMsg = "平台渠道信息错误";
                    return r;
                }

                OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(plat.Plat_class), plat, mch);


                r = await onlinepay.OrderQuery(order.Order_id);

                if (r.ReturnMsg == "ok" && r.IsPay)
                {
                    order.Status = 1;
                    if (r.Totalfee > 0)
                        order.Pay_amount = r.Totalfee;

                    order.Finish_time = DateTime.Now.ToTimeStamp();

                    DB.Context.Save(order);
                }

                return r;
            }


        }
        /// <summary>
        /// 回调接口
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="mid"></param>
        /// <param name="Request"></param>
        /// <param name="Response"></param>
        /// <returns></returns>
        public async Task<NotifyReturn> CallBack(int pid, int mid, Microsoft.AspNetCore.Http.HttpRequest Request, Microsoft.AspNetCore.Http.HttpResponse Response)
        {
            Pay_plat p = OnlinePay.GetPlat(pid);
            Pay_mch m = OnlinePay.GetMch(mid);
            OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);

            NotifyReturn r = await onlinepay.CallBack(Request);
            if (r.IsCheck)
            {
                if (r.IsPay)
                {
                    Pay_order order = DB.Context.From<Pay_order>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                    if (order != null && string.IsNullOrEmpty(order.Order_id))
                    {
                        if (order.Status == 0)
                        {
                            order.Status = 1;
                            order.Finish_time = DateTime.Now.ToTimeStamp();
                            order.Pay_amount = r.Totalfee;
                            order.Notify_status = 0;
                            order.Notify_times = 0;
                            order.Notify_lasttime = DateTime.Now.ToTimeStamp();
                            DB.Context.Save(order);
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(r.OrderNumber))
            {
                Pay_order order = DB.Context.From<Pay_order>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                if (order != null && !string.IsNullOrEmpty(order.Order_id) && !string.IsNullOrEmpty(order.Callback_url))
                {
                    SortedDictionary<string, string> para = new SortedDictionary<string, string>();

                    para.Add("mchid", DB.MchId);
                    para.Add("orderid", order.Order_id);
                    para.Add("serialid", order.Plat_order_id);
                    para.Add("amount", order.Pay_amount.ToString());
                    para.Add("attach", order.Attach);
                    para.Add("status", order.Status.ToString());

                    string sign = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), DB.MchKey);
                    sign = Dos.Common.EncryptHelper.MD5EncryptWeChat(sign, "utf-8");

                    para.Add("sign", sign);

                    Response.Redirect(string.Format("{0}?{1}", order.Callback_url, OnlinePay.GetParamSrc(para)));
                }
            }
            return r;

        }
        /// <summary>
        /// 通知接口
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="mid"></param>
        /// <param name="Request"></param>
        /// <returns></returns>
        public async Task<NotifyReturn> Notify(int pid, int mid, Microsoft.AspNetCore.Http.HttpRequest Request)
        {
            Pay_plat p = OnlinePay.GetPlat(pid);
            Pay_mch m = OnlinePay.GetMch(mid);
            OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);

            NotifyReturn r = await onlinepay.Notify(Request);

            if (r.IsCheck)
            {
                if (r.IsPay)
                {
                    Pay_order order = DB.Context.From<Pay_order>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                    if (order != null && !string.IsNullOrEmpty(order.Order_id))
                    {
                        if (order.Status == 0)
                        {
                            order.Status = 1;
                            order.Finish_time = DateTime.Now.ToTimeStamp();
                            order.Pay_amount = r.Totalfee;
                            order.Notify_status = 0;
                            order.Notify_times = 0;
                            order.Notify_lasttime = DateTime.Now.ToTimeStamp();
                            DB.Context.Save(order);
                        }
                    }
                }
                return r;
            }
            else
            {
                return r;
            }
        }

        public async Task<string> SendNotify(string orderid)
        {
            Pay_order o = DB.Context.From<Pay_order>().Where(p => p.Order_id == orderid).First();
            if (o == null || o.Order_id != orderid)
            {
                return "订单不存在";
            }
            if (o.Notify_url.Length < 7)
            {
                return "订单通知地址不误";
            }
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("mchid", DB.MchId);
            para.Add("orderid", o.Order_id);
            para.Add("serialid", o.Plat_order_id);
            para.Add("amount", o.Pay_amount.ToString());
            para.Add("attach", o.Attach);
            para.Add("status", o.Status.ToString());

            string sign = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), DB.MchKey);
            sign = Dos.Common.EncryptHelper.MD5EncryptWeChat(sign, "utf-8");

            para.Add("sign", sign);

            string msg =
                 Task.Run(() =>
                 {
                     string r;
                     try
                     {
                         r = Dos.Common.HttpHelper.Post(
                            new Dos.Common.HttpParam
                            {
                                Url = o.Notify_url,
                                Encoding = System.Text.Encoding.UTF8,
                                ParamType = Dos.Common.EnumHelper.HttpParamType.Form,
                                GetParam = para
                            }
                         );
                     }
                     catch (Exception ee)
                     {
                         r = ee.ToString();
                     }
                     return r;
                 }).Result;


            if (o.Notify_status < 2)
            {
                if (msg == "ok")
                {
                    o.Notify_status = 2;
                }
                else
                {
                    o.Notify_status = 1;
                }
                if (o.Notify_times == null) { o.Notify_times = 0; }

                o.Notify_times = o.Notify_times + 1;
                o.Notify_lasttime = DateTime.Now.ToTimeStamp();
                if (o.Notify_status != 2)
                {
                    switch (o.Notify_times)
                    {
                        case 1: Publish(DB.MchId, o.Order_id, 60); break;   //1分钟后再次通知
                        case 2: Publish(DB.MchId, o.Order_id, 300); break;   //5分钟后再次通知
                        case 3: Publish(DB.MchId, o.Order_id, 900); break;  //15分钟后再次通知
                        case 4: Publish(DB.MchId, o.Order_id, 7200); break;   //2小时后再次通知
                        case 5: Publish(DB.MchId, o.Order_id, 21600); break;   //6小时后再次通知
                        default: break;
                    }
                }
                DB.Context.Save(o);
            }

            return msg;

        }



        public void Publish(string mchid, string orderid, int ttl = 0)
        {
            var msg = new PayOrderNotify { mchid = mchid, orderid = orderid };
            if (ttl <= 0)
            {
                DB.RabbiBus.PublishAsync(msg);
            }
            else
            {
                //通过死信发送延迟消息
                var channel = DB.RabbiBus.Advanced;
                var exchange = channel.ExchangeDeclare("OrderNotify.Delay.Exchange", ExchangeType.Direct);
                string key = string.Format("Pay.OrderNotify.Delay.Ttl_{0}", ttl);
                var queue = channel.QueueDeclare(key, deadLetterExchange: "Pay.OrderNotify", deadLetterRoutingKey: "#", perQueueMessageTtl: ttl * 1000);
                var binding = channel.Bind(exchange, queue, key);
                var message = new Message<Mq.Messages.PayOrderNotify>(msg);
                channel.Publish(exchange, key, false, message);
            }
        }
    }
}

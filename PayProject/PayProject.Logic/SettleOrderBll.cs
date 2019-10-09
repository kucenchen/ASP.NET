using Dos.ORM;
using PayProject.Common;
using PayProject.Common.Util;
using PayProject.Core;
using PayProject.DTO;
using PayProject.Entity;
using PayProject.Extensions;
using PayProject.Logic.Settle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Logic
{
    public class SettleOrderBll : LogicBase<SettleOrder>
    {
        private static SettleOrderBll bll;
        public static SettleOrderBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new SettleOrderBll();
                }
                return bll;
            }
        }

        public async Task<ApiResult<Page<SettleOrder>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<SettleOrder>>();
            try
            {
                var query = DbContext._.Db.From<SettleOrder>()
                    .Where((Where<SettleOrder>)parm.whereClip)
                    .OrderBy((OrderByClip)parm.orderByClip)
                    .ToPageAsync<SettleOrder>(parm.page, parm.limit);
                res.success = true;
                res.message = "获取成功！";
                res.data = await query;
            }
            catch (Exception ex)
            {
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
                res.statusCode = (int)ApiEnum.Error;
            }
            return await Task.Run(() => res);
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
        public async Task<UnifiedOrderReturnModel> Unifiedorder(string appid,string mchid, string orderid, string Bank_name, string Bank_branch, string Bank_card_number, string Bank_account, string amount, string attach, string ip, string callbackurl, string notifyurl)
        {


            UnifiedOrderReturnModel r = new UnifiedOrderReturnModel();

            if (appid != WebConfig.MchId)
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "约定的appid错误";
                return r;
            }


            decimal fee = 0;
            decimal.TryParse(amount, out fee);

            if (fee <= 0)
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "打款金额必须大于0";
                return r;
            }

            //SettleMch m = OnlineSettle.MchList.FindAll(pp => pp.Nullity == false && ("" + pp.BankList + ",").Contains("," + Bank_name.Trim() + ",")
            // && (pp.Max_money == 0 || pp.Max_money >= fee) && (pp.Min_money == 0 || pp.Min_money <= fee)).OrderBy(i => Guid.NewGuid()).FirstOrDefault();
            SettleMch m = OnlineSettle.MchList.FindAll(pp => pp.Id == Convert.ToInt32(mchid) && pp.Nullity == false && ("," + pp.BankList + ",").Contains("," + Bank_name.Trim() + ",")
            && (pp.Max_money >= fee) && (pp.Min_money <= fee)).OrderBy(i => Guid.NewGuid()).FirstOrDefault();

            if (m == null)
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "平台没有可用的打款渠道";
                return r;
            }

            SettlePlat p = OnlineSettle.GetPlat(m.Plat_id);
            if (p == null)
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "平台支付渠道有误";
                return r;
            }

            if (DbContext._.Db.Exists<SettleOrder>(o => o.Order_id == orderid))
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "订单号已经存在";
                return r;
            }

            SettleOrder order = new SettleOrder();
            order.Order_id = orderid;
            order.Plat_order_id = "";
            order.Mch_id = m.Id;
            order.Order_amount = fee;
            order.Pay_amount = 0;
            order.Bank_name = Bank_name.Trim();
            order.Bank_branch = Bank_branch.Trim();
            order.Bank_card_number = Bank_card_number.Trim();
            order.Bank_account = Bank_account.Trim();
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

            bool isSuccess = false;
            try
            {
                isSuccess = DbContext._.Db.Insert<SettleOrder>(order) > 0;
            }
            catch (Exception e)
            {
                string err = e.Message;
                throw;
            }

            OnlineSettle onlinepay = (OnlineSettle)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);


            r = await onlinepay.Unifiedorder(orderid, Bank_name, Bank_branch, Bank_card_number, Bank_account, fee, ip, attach);

            if (r.Type != 0)
            {
                order.Plat_order_id = r.SerialNumber;
                order.Pay_amount = decimal.Parse(r.RealPrice);
                order.Returnmsg = r.Content;
            }
            return r;
        }
        /// <summary>
        /// 查询接口
        /// </summary>
        /// <param name="mchid"></param>
        /// <param name="orderid"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public async Task<QueryReturnModel> Query(string mchid, string orderid)
        {
            QueryReturnModel r = new QueryReturnModel();

            if (mchid != WebConfig.MchId)
            {
                r.ReturnMsg = "商户号不存在";
                return r;
            }

            SettleOrder order = DbContext._.Db.From<SettleOrder>().Where(p => p.Order_id == orderid).ToFirstDefault();

            if (order == null || string.IsNullOrEmpty(order.Order_id))
            {
                r.ReturnMsg = "订单不存在";
                return r;
            }

            if (order.Status == 1)
            {
                r.ReturnMsg = "ok";
                r.IsPay = 1;
                r.OrderNumber = order.Order_id;
                r.SerialNumber = order.Plat_order_id;
                r.Totalfee = order.Pay_amount;
                r.Attach = order.Attach;
                return r;
            }
            else
            {

                SettleMch mch = OnlineSettle.GetMch(order.Mch_id);

                if (mch == null)
                {
                    r.ReturnMsg = "平台商户信息错误";
                    return r;
                }

                SettlePlat plat = OnlineSettle.GetPlat(mch.Plat_id);
                if (plat == null)
                {
                    r.ReturnMsg = "平台渠道信息错误";
                    return r;
                }

                OnlineSettle onlinepay = (OnlineSettle)Activator.CreateInstance(Type.GetType(plat.Plat_class), plat, mch);


                r = await onlinepay.OrderQuery(order.Order_id);

                if (r.ReturnMsg == "ok" && r.IsPay == 1)
                {
                    order.Attach(EntityState.Modified);
                    order.Status = 1;
                    if (r.Totalfee > 0)
                        order.Pay_amount = r.Totalfee;

                    order.Finish_time = DateTime.Now.ToTimeStamp();
                    order.Returnmsg = r.ReturnMsg;
                    DbContext._.Db.Save(order);
                }
                else
                {
                    order.Attach(EntityState.Modified);
                    order.Returnmsg = r.ReturnMsg;
                    DbContext._.Db.Save(order);
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
        public async Task<NotifyReturnModel> CallBack(int pid, int mid, Microsoft.AspNetCore.Http.HttpRequest Request, Microsoft.AspNetCore.Http.HttpResponse Response)
        {
            SettlePlat p = OnlineSettle.GetPlat(pid);
            SettleMch m = OnlineSettle.GetMch(mid);
            OnlineSettle onlinepay = (OnlineSettle)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);

            NotifyReturnModel r = await onlinepay.CallBack(Request);
            if (r.IsCheck)
            {
                if (r.IsPay == 1)
                {
                    SettleOrder order = DbContext._.Db.From<SettleOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                    if (order != null && string.IsNullOrEmpty(order.Order_id))
                    {
                        if (order.Status == 0)
                        {
                            order.Attach(EntityState.Modified);
                            order.Status = 1;
                            order.Finish_time = DateTime.Now.ToTimeStamp();
                            order.Pay_amount = r.Totalfee;
                            order.Notify_status = 0;
                            order.Notify_times = 0;
                            order.Notify_lasttime = DateTime.Now.ToTimeStamp();
                            order.Returnmsg = r.ReturnMsg;
                            DbContext._.Db.Save(order);
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(r.OrderNumber))
            {
                SettleOrder order = DbContext._.Db.From<SettleOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                if (order != null && !string.IsNullOrEmpty(order.Order_id) && !string.IsNullOrEmpty(order.Callback_url))
                {
                    SortedDictionary<string, string> para = new SortedDictionary<string, string>();

                    para.Add("mchid", WebConfig.MchId);
                    para.Add("orderid", order.Order_id);
                    para.Add("serialid", order.Plat_order_id);
                    para.Add("amount", order.Pay_amount.ToString());
                    para.Add("attach", order.Attach);
                    para.Add("status", order.Status.ToString());

                    string sign = string.Format("{0}&key={1}", OnlineSettle.GetParamSrc(para), WebConfig.MchKey);
                    sign = Dos.Common.EncryptHelper.MD5EncryptWeChat(sign, "utf-8");

                    para.Add("sign", sign);

                    Response.Redirect(string.Format("{0}?{1}", order.Callback_url, OnlineSettle.GetParamSrc(para)));
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
        public async Task<NotifyReturnModel> Notify(int pid, int mid, Microsoft.AspNetCore.Http.HttpRequest Request)
        {
            SettlePlat p = OnlineSettle.GetPlat(pid);
            SettleMch m = OnlineSettle.GetMch(mid);
            OnlineSettle onlinepay = (OnlineSettle)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);

            NotifyReturnModel r = await onlinepay.Notify(Request);

            if (r.IsCheck)
            {
                if (r.IsPay == 1)
                {
                    SettleOrder order = DbContext._.Db.From<SettleOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                    if (order != null && !string.IsNullOrEmpty(order.Order_id))
                    {
                        if (order.Status == 0)
                        {
                            order.Attach(EntityState.Modified);
                            order.Status = 1;
                            order.Finish_time = DateTime.Now.ToTimeStamp();
                            order.Pay_amount = r.Totalfee;
                            order.Notify_status = 0;
                            order.Notify_times = 0;
                            order.Notify_lasttime = DateTime.Now.ToTimeStamp();
                            order.Plat_order_id = r.SerialNumber;
                            order.Returnmsg = r.ReturnMsg;
                            DbContext._.Db.Save(order);
                        }
                    }
                }
                else
                {
                    SettleOrder order = DbContext._.Db.From<SettleOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                    if (order != null && !string.IsNullOrEmpty(order.Order_id))
                    {
                        if (order.Status == 0)
                        {
                            order.Attach(EntityState.Modified);
                            order.Returnmsg = r.ReturnMsg;
                            DbContext._.Db.Save(order);
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

        public async Task<string> SendNotify(string orderid, bool isSystem = true, bool isAsyn = true)
        {
            SettleOrder o = DbContext._.Db.From<SettleOrder>().Where(p => p.Order_id == orderid).First();
            if (o == null || o.Order_id != orderid)
            {
                return "订单不存在";
            }
            if (o.Status != 1)
            {
                return "订单状态还未成功";
            }
            if (o.Notify_status == 1)
            {
                return "订单异步通知已成功";
            }
            if (o.Notify_url.Length < 7)
            {
                return "订单通知地址不误";
            }
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("mchid", WebConfig.MchId);
            para.Add("orderid", o.Order_id);
            para.Add("serialid", o.Plat_order_id);
            para.Add("amount", o.Pay_amount.ToString());
            para.Add("attach", o.Attach);
            para.Add("msg", o.Returnmsg);
            para.Add("status", o.Status.ToString());

            string sign = string.Format("{0}&key={1}", OnlineSettle.GetParamSrc(para), WebConfig.MchKey);
            sign = Dos.Common.EncryptHelper.MD5EncryptWeChat(sign, "utf-8");

            para.Add("sign", sign);

            string msg = "异步通知发送中...";
            if (isAsyn)
            {
                msg =
                 Task.Run(() =>
                 {
                     string r;
                     try
                     {

                         r = WebUtils.Post(o.Notify_url, WebUtils.BuildQuery(para, "utf-8"));
                     }
                     catch (Exception ee)
                     {
                         r = ee.ToString();
                     }

                     if (o.Notify_status != 1)
                     {
                         o.Attach(EntityState.Modified);
                         if (r == "ok")
                         {
                             o.Notify_status = 1;
                         }
                         else
                         {
                             o.Notify_status = 2;
                         }
                         if (o.Notify_times == null) { o.Notify_times = 0; }

                         o.Notify_times = o.Notify_times + 1;
                         o.Notify_lasttime = DateTime.Now.ToTimeStamp();
                         if (isSystem)
                         {
                             if (o.Notify_status != 1)
                             {
                                 switch (o.Notify_times)
                                 {
                                     case 1: Publish(WebConfig.MchId, o.Order_id, 60); break;   //1分钟后再次通知
                                     case 2: Publish(WebConfig.MchId, o.Order_id, 300); break;   //5分钟后再次通知
                                     case 3: Publish(WebConfig.MchId, o.Order_id, 900); break;  //15分钟后再次通知
                                     case 4: Publish(WebConfig.MchId, o.Order_id, 7200); break;   //2小时后再次通知
                                     case 5: Publish(WebConfig.MchId, o.Order_id, 21600); break;   //6小时后再次通知
                                     default: break;
                                 }
                             }
                         }
                         DbContext._.Db.Save(o);
                     }
                     return r;
                 }).Result;
                return msg;
            }
            else
            {
                string r;
                try
                {
                    r = WebUtils.Post(o.Notify_url, WebUtils.BuildQuery(para, "utf-8"));
                }
                catch (Exception ee)
                {
                    r = ee.ToString();
                }

                if (o.Notify_status != 1)
                {
                    o.Attach(EntityState.Modified);
                    if (r == "ok")
                    {
                        o.Notify_status = 1;
                    }
                    else
                    {
                        o.Notify_status = 2;
                    }
                    if (o.Notify_times == null) { o.Notify_times = 0; }

                    o.Notify_times = o.Notify_times + 1;
                    o.Notify_lasttime = DateTime.Now.ToTimeStamp();
                    if (isSystem)
                    {
                        if (o.Notify_status != 1)
                        {
                            switch (o.Notify_times)
                            {
                                case 1: Publish(WebConfig.MchId, o.Order_id, 60); break;   //1分钟后再次通知
                                case 2: Publish(WebConfig.MchId, o.Order_id, 300); break;   //5分钟后再次通知
                                case 3: Publish(WebConfig.MchId, o.Order_id, 900); break;  //15分钟后再次通知
                                case 4: Publish(WebConfig.MchId, o.Order_id, 7200); break;   //2小时后再次通知
                                case 5: Publish(WebConfig.MchId, o.Order_id, 21600); break;   //6小时后再次通知
                                default: break;
                            }
                        }
                    }
                    DbContext._.Db.Save(o);
                }
                return r;
            }
            
        }



        public void Publish(string mchid, string orderid, int ttl = 0)
        {
            SettleOrderNotifyMsg msg = new SettleOrderNotifyMsg
            {
                mchid = mchid,
                orderid = orderid
            };

            //var msg = new SettleOrderNotifyModel { mchid = mchid, orderid = orderid };
            //if (ttl <= 0)
            //{
            //    DB.RabbiBus.PublishAsync(msg);
            //}
            //else
            //{
            //    //通过死信发送延迟消息
            //    var channel = DB.RabbiBus.Advanced;
            //    var exchange = channel.ExchangeDeclare("OrderNotify.Delay.Exchange", ExchangeType.Direct);
            //    string key = string.Format("Settle.OrderNotify.Delay.Ttl_{0}", ttl);
            //    var queue = channel.QueueDeclare(key, deadLetterExchange: "Settle.OrderNotify", deadLetterRoutingKey: "#", perQueueMessageTtl: ttl * 1000);
            //    var binding = channel.Bind(exchange, queue, key);
            //    var message = new Message<Mq.Messages.SettleOrderNotify>(msg);
            //    channel.Publish(exchange, key, false, message);
            //}
        }
    }
}

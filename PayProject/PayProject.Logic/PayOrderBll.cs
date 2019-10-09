using PayProject.Core;
using PayProject.Entity;
using PayProject.Extensions;
using PayProject.Logic.Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayProject.Common;
using Dos.ORM;
using PayProject.Logic.MQ.Publisher;
using PayProject.DTO;
using PayProject.Common.Util;

namespace PayProject.Logic
{
    public class PayOrderBll : LogicBase<PayOrder>
    {
        private static PayOrderBll bll;
        public static PayOrderBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new PayOrderBll();
                }
                return bll;
            }
        }
        public async Task<ApiResult<Page<PayOrder>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<PayOrder>>();
            try
            {
                var query = DbContext._.Db.From<PayOrder>()
                    .Where((Where<PayOrder>)parm.whereClip)
                    .OrderBy((OrderByClip)parm.orderByClip)
                    .ToPageAsync<PayOrder>(parm.page, parm.limit);
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
        public async Task<UnifiedOrderReturnModel> Unifiedorder(string mchid, string orderid, string body, int paytype, string amount, string attach, string ip, string callbackurl, string notifyurl)
        {
            UnifiedOrderReturnModel r = new UnifiedOrderReturnModel();
            //if (mchid != WebConfig.MchId)
            //{
            //    Dos.Common.LogHelper.Debug("商户号不存在");
            //    r.Type = PayReturnTypeEnum.Err;
            //    r.Content = "商户号不存在";
            //    return r;
            //}

            decimal fee = 0;
            decimal.TryParse(amount, out fee);

            if (fee <= 0)
            {
                Dos.Common.LogHelper.Debug("支付金额必须大于0");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "支付金额必须大于0";
                return r;
            }

            PayMch payMchModel = OnlinePay.MchList.FindAll(pp => pp.Nullity == false && ("," + pp.Open_time + ",").Contains("," + DateTime.Now.Hour.ToString() + ",") && ("," + pp.Open_pay_type_list + ",").Contains("," + paytype + ",") && ("," + pp.Pay_money_list + ",").Contains("," + amount + ",")).OrderBy(i => Guid.NewGuid()).FirstOrDefault();

            if (payMchModel == null)
            {
                Dos.Common.LogHelper.Debug("平台没有可用的支付渠道");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "平台没有可用的支付渠道";
                return r;
            }
            //1:随机加减0-9分 2:随机加减0-9元
            if (payMchModel.Israndom == 1)
            {
                int randomNum = new Random().Next(-9, 10);
                if (randomNum != 0)
                {
                    fee += Convert.ToDecimal(randomNum) / 100;
                }
            }
            else if (payMchModel.Israndom == 2)
            {
                int randomNum = new Random().Next(-9, 10);
                if (randomNum != 0)
                {
                    fee += Convert.ToDecimal(randomNum);
                }
            }

            if (fee <= 0)
            {
                Dos.Common.LogHelper.Debug("支付金额必须大于0  2");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "支付金额必须大于0";
                return r;
            }

            PayPlat payPlatModel = OnlinePay.GetPlat(payMchModel.Plat_id);
            if (payPlatModel == null)
            {
                Dos.Common.LogHelper.Debug("平台支付渠道有误");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "平台支付渠道有误";
                return r;
            }

            if (DbContext._.Db.Exists<PayOrder>(d => d.Order_id == orderid.SqlFilters()))
            {
                Dos.Common.LogHelper.Debug("订单号已经存在");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "订单号已经存在";
                return r;
            }

            PayOrder order = new PayOrder();
            order.Order_id = orderid;
            order.Plat_order_id = "";
            order.Mch_id = payMchModel.Id;
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
            bool isSuccess = false;
            try
            {
                isSuccess = DbContext._.Db.Insert<PayOrder>(order) > 0;
            }
            catch (Exception e)
            {
                Dos.Common.LogHelper.Debug("创建订单失败：" + e.Message);
                string err = e.Message;
                throw;
            }

            if (!isSuccess)
            {
                Dos.Common.LogHelper.Debug("创建订单失败02");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "创建订单失败";
                return r;
            }

            try
            {
                OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(payPlatModel.Plat_class), payPlatModel, payMchModel);
                r = await onlinepay.Unifiedorder(orderid, paytype.ToString(), fee, ip, body, attach);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Dos.Common.LogHelper.Debug("选用支付API接口失败：" + err);
                r.Type = PayReturnTypeEnum.Err;
                r.Content = err;
                return r;
            }

            if (r.Type != 0)
            {
                order.Plat_order_id = r.SerialNumber;
                order.Pay_amount = decimal.Parse(r.RealPrice);
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
                Dos.Common.LogHelper.Debug("商户号不存在");
                r.ReturnMsg = "商户号不存在";
                return r;
            }

            PayOrder order = DbContext._.Db.From<PayOrder>().Where(p => p.Order_id == orderid.SqlFilters()).ToFirstDefault();
            if (order == null || string.IsNullOrEmpty(order.Order_id))
            {
                Dos.Common.LogHelper.Debug("订单不存在");
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
                PayMch mch = OnlinePay.GetMch(order.Mch_id);

                if (mch == null)
                {
                    Dos.Common.LogHelper.Debug("平台商户信息错误");
                    r.ReturnMsg = "平台商户信息错误";
                    return r;
                }

                PayPlat plat = OnlinePay.GetPlat(mch.Plat_id);
                if (plat == null)
                {
                    Dos.Common.LogHelper.Debug("平台渠道信息错误");
                    r.ReturnMsg = "平台渠道信息错误";
                    return r;
                }
                try
                {
                    OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(plat.Plat_class), plat, mch);

                    r = await onlinepay.OrderQuery(order.Order_id);
                }
                catch (Exception ex)
                {
                    Dos.Common.LogHelper.Debug("第三方查询下单失败1：" + ex.Message);
                    throw ex;
                }

                try
                {
                    if (r.ReturnMsg == "ok" && r.IsPay)
                    {
                        order.Attach(EntityState.Modified);
                        order.Status = 1;
                        if (r.Totalfee > 0)
                            order.Pay_amount = r.Totalfee;

                        order.Finish_time = DateTime.Now.ToTimeStamp();
                        DbContext._.Db.Save(order);
                    }
                    else
                    {
                        Dos.Common.LogHelper.Debug("第三方查询结果：ReturnMsg " + r.ReturnMsg + "## IsPay " + r.IsPay);
                    }
                }
                catch (Exception ex)
                {
                    Dos.Common.LogHelper.Debug("第三方查询下单失败2：" + ex.Message);
                    throw ex;
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
            PayPlat p = OnlinePay.GetPlat(pid);
            PayMch m = OnlinePay.GetMch(mid);
            OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);

            NotifyReturnModel r = await onlinepay.CallBack(Request);
            if (r.IsCheck)
            {
                if (r.IsPay)
                {
                    PayOrder order = DbContext._.Db.From<PayOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

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
                            DbContext._.Db.Save(order);
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(r.OrderNumber))
            {
                PayOrder order = DbContext._.Db.From<PayOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

                if (order != null && !string.IsNullOrEmpty(order.Order_id) && !string.IsNullOrEmpty(order.Callback_url))
                {
                    SortedDictionary<string, string> para = new SortedDictionary<string, string>();

                    para.Add("mchid", WebConfig.MchId);
                    para.Add("orderid", order.Order_id);
                    para.Add("serialid", order.Plat_order_id);
                    para.Add("amount", order.Pay_amount.ToString());
                    para.Add("attach", order.Attach);
                    para.Add("status", order.Status.ToString());

                    string sign = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), WebConfig.MchKey);
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
        public async Task<NotifyReturnModel> Notify(int pid, int mid, Microsoft.AspNetCore.Http.HttpRequest Request)
        {
            NotifyReturnModel r = null;

            try
            {
                PayPlat p = OnlinePay.GetPlat(pid);
                PayMch m = OnlinePay.GetMch(mid);
                OnlinePay onlinepay = (OnlinePay)Activator.CreateInstance(Type.GetType(p.Plat_class), p, m);
                r = await onlinepay.Notify(Request);
            }
            catch (Exception ex)
            {
                Dos.Common.LogHelper.Debug("第三方回调初始化失败：" + ex.Message);
                throw ex;
            }
             

            if (r.IsCheck)
            {
                if (r.IsPay)
                {
                    PayOrder order = DbContext._.Db.From<PayOrder>().Where(o => o.Order_id == r.OrderNumber).ToFirstDefault();

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
                            int res = DbContext._.Db.Save(order);
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

        /// <summary>
        /// 发送通知
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="isSystem"></param>
        /// <returns></returns>
        public async Task<string> SendNotify(string orderid, bool isSystem = true, bool isAsyn = true)
        {
            PayOrder o = DbContext._.Db.From<PayOrder>().Where(p => p.Order_id == orderid).First();
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
            //AopDictionary para = new AopDictionary();
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("mchid", WebConfig.MchId);
            para.Add("orderid", o.Order_id);
            para.Add("serialid", o.Plat_order_id);
            para.Add("amount", o.Pay_amount.ToString());
            para.Add("attach", o.Attach);
            para.Add("status", o.Status.ToString());

            string sign = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), WebConfig.MchKey);
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



            #region
            //if (o.Notify_status != 1)
            //{
            //    o.Attach(EntityState.Modified);
            //    if (msg == "ok")
            //    {
            //        o.Notify_status = 1;
            //    }
            //    else
            //    {
            //        o.Notify_status = 2;
            //    }
            //    if (o.Notify_times == null) { o.Notify_times = 0; }

            //    o.Notify_times = o.Notify_times + 1;
            //    o.Notify_lasttime = DateTime.Now.ToTimeStamp();
            //    if (isSystem)
            //    {
            //        if (o.Notify_status != 1)
            //        {
            //            switch (o.Notify_times)
            //            {
            //                case 1: Publish(WebConfig.MchId, o.Order_id, 60); break;   //1分钟后再次通知
            //                case 2: Publish(WebConfig.MchId, o.Order_id, 300); break;   //5分钟后再次通知
            //                case 3: Publish(WebConfig.MchId, o.Order_id, 900); break;  //15分钟后再次通知
            //                case 4: Publish(WebConfig.MchId, o.Order_id, 7200); break;   //2小时后再次通知
            //                case 5: Publish(WebConfig.MchId, o.Order_id, 21600); break;   //6小时后再次通知
            //                default: break;
            //            }
            //        }
            //    }
            //    DbContext._.Db.Save(o);
            //}
            #endregion

        }



        public void Publish(string mchid, string orderid, int ttl = 0)
        {
            PayOrderNotifyMsg msg = new PayOrderNotifyMsg
            {
                mchid = mchid,
                orderid = orderid
            };
            new PayOrderNotify().PublishMessage(msg, ttl);

            //var msg = new PayOrderNotifyModel { mchid = mchid, orderid = orderid };
            //if (ttl <= 0)
            //{
            //    DB.RabbiBus.PublishAsync(msg);
            //}
            //else
            //{
            //    //通过死信发送延迟消息
            //    var channel = DB.RabbiBus.Advanced;
            //    var exchange = channel.ExchangeDeclare("OrderNotify.Delay.Exchange", ExchangeType.Direct);
            //    string key = string.Format("Pay.OrderNotify.Delay.Ttl_{0}", ttl);
            //    var queue = channel.QueueDeclare(key, deadLetterExchange: "Pay.OrderNotify", deadLetterRoutingKey: "#", perQueueMessageTtl: ttl * 1000);
            //    var binding = channel.Bind(exchange, queue, key);
            //    var message = new Message<Mq.Messages.PayOrderNotify>(msg);
            //    channel.Publish(exchange, key, false, message);
            //}

        }
    }
}

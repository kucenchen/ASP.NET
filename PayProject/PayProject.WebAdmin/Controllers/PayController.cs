using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dos.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayProject.Common;
using PayProject.DTO;
using PayProject.Entity;
using PayProject.Extensions;
using PayProject.Logic;
using PayProject.Logic.Pay;
using PayProject.WebAdmin.Models;

namespace PayProject.WebAdmin.Controllers
{
    [Produces("application/json")]
    [Route("pay")]
    [AllowAnonymous]
    public class PayController : Controller
    {
        /// <summary>
        /// 统一下单接口
        /// </summary>
        /// <param name="payOrder"></param>
        /// <returns></returns>
        [HttpPost("unifiedorder"), LogAttribute("入款统一下单")]
        public async Task<UnifiedOrderReturnModel> Unifiedorder([FromForm]PayOrderModel payOrder)
        {
            //string mchid, string orderid, string body, int paytype, string amount, string attach, string ip, string callbackurl, string notifyurl, string sign
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();
            para.Add("mchid", payOrder.MchId);
            para.Add("orderid", payOrder.OrderId);
            para.Add("body", payOrder.Body);
            para.Add("paytype", payOrder.PayType.ToString());
            para.Add("amount", payOrder.Amount);
            para.Add("attach", payOrder.Attach);
            para.Add("ip", payOrder.Ip);
            para.Add("callbackurl", payOrder.CallBackUrl);
            para.Add("notifyurl", payOrder.NotifyUrl);

            string temp = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), WebConfig.MchKey);
            Dos.Common.LogHelper.Debug(temp);

            UnifiedOrderReturnModel r = new UnifiedOrderReturnModel();
            if (payOrder.MchId != WebConfig.MchId)
            {
                Dos.Common.LogHelper.Debug("商户号不存在");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "商户号不存在";
                return r;
            }
            string cusSign = Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");
            if (cusSign.ToLower() != payOrder.Sign.ToLower())
            {
                Dos.Common.LogHelper.Debug("签名错误");
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "签名错误";
                return r;
            }
            return await PayOrderBll._.Unifiedorder(payOrder.MchId, payOrder.OrderId, payOrder.Body, payOrder.PayType, payOrder.Amount, payOrder.Attach, payOrder.Ip, payOrder.CallBackUrl, payOrder.NotifyUrl);
        }
       
        [HttpPost("query"), LogAttribute("入款订单查询")]
        public async Task<QueryReturnModel> Query(string mchid, string orderid, string sign)
        {
            QueryReturnModel r = new QueryReturnModel();
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();
            para.Add("mchid", mchid);
            para.Add("orderid", orderid);

            string temp = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), WebConfig.MchKey);
            Dos.Common.LogHelper.Debug(temp);

            if (mchid != WebConfig.MchId)
            {
                Dos.Common.LogHelper.Debug(" Query 商户号不存在");
                r.ReturnMsg = "商户号不存在";
                return r;
            }

            string cusSign = Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");

            if (cusSign.ToLower() != sign.ToLower())
            {
                Dos.Common.LogHelper.Debug(" Query 签名错误");
                r.ReturnMsg = "签名错误";
                return r;
            }

            return await PayOrderBll._.Query(mchid, orderid);
        }
        /// <summary>
        /// 回调接口
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        [Produces("text/plain")]
        [HttpGet("callback_{pid}_{mid}.do")]
        public async Task<string> CallBack(int pid, int mid)
        {
            NotifyReturnModel n = await PayOrderBll._.CallBack(pid, mid, Request, Response);
            if (n.IsCheck && n.IsPay)
            {
                //_bus.PublishAsync(new PayOrderNotify { mchid = DB.MchId, orderid = n.OrderNumber });
            }
            return n.ReturnMsg;
        }
        /// <summary>
        /// 通知接口
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        [Produces("text/plain")]
     //   [HttpGet("notify_{pid}_{mid}.do"), LogAttribute("入款异步通知")]
        [HttpPost("notify_{pid}_{mid}.do"), LogAttribute("入款异步通知")]
        public async Task<string> Notify(int pid, int mid)
        {
            NotifyReturnModel n = null;
            try
            {
                n = await PayOrderBll._.Notify(pid, mid, Request);
            }
            catch (Exception ex)
            {
                Dos.Common.LogHelper.Debug(" Notify 回调异常：" + ex.Message);
                throw ex;
            }

            if (n.IsCheck && n.IsPay)
            {
                try
                {
                    PayOrderBll._.SendNotify(n.OrderNumber);
                }
                catch (Exception ex)
                {
                    Dos.Common.LogHelper.Debug("回调入库异常：" + ex.Message);
                    throw ex;
                }

                //Settle_OrderBll.Instance.Publish(DB.MchId, n.OrderNumber);
                //PayOrderBll._.Publish(WebConfig.MchId, n.OrderNumber);
                //PayOrderNotifyMsg msg = new PayOrderNotifyMsg {
                //    mchid=WebConfig.MchId,
                //    orderid=n.OrderNumber
                //};
                //new PayOrderNotify().PublishMessage(msg, 20);
            }
            return n.ReturnMsg;
        }

        /// <summary>
        /// 测试充值成功(正式环境删除)
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("testnotify_{orderId}.do")]
        public async Task<string> TestNotify(string orderId)
        {
            var orderModel = PayOrderBll._.GetModelAsync(d => d.Order_id == orderId.SqlFilters()).Result.data;
            Dictionary<Field, object> model = new Dictionary<Field, object>();
            model.Add(PayOrder._.Status, 1);
            model.Add(PayOrder._.Pay_amount, orderModel.Order_amount);
            await PayOrderBll._.UpdateAsync(model, d => d.Order_id == orderId);
            PayOrderBll._.SendNotify(orderId);
            return await Task.Run(() => "恭喜您,支付成功!");
        }
    }
}
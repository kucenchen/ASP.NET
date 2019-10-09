using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayProject.Common;
using PayProject.Extensions;
using PayProject.Logic;
using PayProject.Logic.Settle;
using PayProject.WebAdmin.Models;

namespace PayProject.WebAdmin.Controllers
{
    [Produces("application/json")]
    [Route("settle")]
    [AllowAnonymous]
    public class SettleController : Controller
    {
        [HttpGet("tt/{id}_{dd}.html")]
        public async Task<JsonResult> tt(string id, int dd)
        {
            //var res = await _urlService.GetPagesAsync(parm);
            return Json(new { code = 0, msg = "success", id = id, dd = dd });
        }
        [HttpPost("unifiedorder"), LogAttribute("出款统一下单")]
        public async Task<UnifiedOrderReturnModel> Unifiedorder([FromForm]SettleOrderModel settleOrder)
        {
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("appid", settleOrder.AppId);//约定好的id
            para.Add("mchid", settleOrder.MchId);//传输过来的商户标识ID
            para.Add("orderid", settleOrder.OrderId);
            para.Add("bank_name", settleOrder.Bank_Name);
            para.Add("bank_branch", settleOrder.Bank_Branch);
            para.Add("bank_card_number", settleOrder.Bank_Card_Number);
            para.Add("bank_account", settleOrder.Bank_Account);
            para.Add("amount", settleOrder.Amount);
            para.Add("attach", settleOrder.Attach);
            para.Add("ip", settleOrder.Ip);
            para.Add("callbackurl", settleOrder.CallBackUrl);
            para.Add("notifyurl", settleOrder.NotifyUrl);

            string temp = string.Format("{0}&key={1}", OnlineSettle.GetParamSrc(para), WebConfig.MchKey);

            Dos.Common.LogHelper.Debug(temp);

            UnifiedOrderReturnModel r = new UnifiedOrderReturnModel();

            if (settleOrder.AppId != WebConfig.MchId)
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "商户号不存在";
                return r;
            }

            string cusSign = Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");

            if (cusSign.ToLower() != settleOrder.Sign.ToLower())
            {
                r.Type = PayReturnTypeEnum.Err;
                r.Content = "签名错误";
                return r;
            }

            return await SettleOrderBll._.Unifiedorder(settleOrder.AppId, settleOrder.MchId, settleOrder.OrderId, settleOrder.Bank_Name, settleOrder.Bank_Branch, settleOrder.Bank_Card_Number, settleOrder.Bank_Account, settleOrder.Amount, settleOrder.Attach, settleOrder.Ip, settleOrder.CallBackUrl, settleOrder.NotifyUrl);
        }
        
        [HttpPost("query"), LogAttribute("出款订单查询")]
        public async Task<QueryReturnModel> Query(string mchid, string orderid, string sign)
        {
            QueryReturnModel r = new QueryReturnModel();

            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("mchid", mchid);
            para.Add("orderid", orderid);

            string temp = string.Format("{0}&key={1}", OnlineSettle.GetParamSrc(para), WebConfig.MchKey);

            Dos.Common.LogHelper.Debug(temp);

            if (mchid != WebConfig.MchId)
            {
                r.ReturnMsg = "商户号不存在";
                return r;
            }

            temp = Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");

            if (temp.ToLower() != sign.ToLower())
            {
                r.ReturnMsg = "签名错误";
                return r;
            }

            return await SettleOrderBll._.Query(mchid, orderid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("text/plain")]
        [HttpGet("callback_{pid}_{mid}.do")]
        public async Task<string> CallBack(int pid, int mid)
        {
            NotifyReturnModel n = await SettleOrderBll._.CallBack(pid, mid, Request, Response);
            if (n.IsCheck && n.IsPay == 1)
            {
                //_bus.PublishAsync(new PayOrderNotify { mchid = DB.MchId, orderid = n.OrderNumber });
            }
            return n.ReturnMsg;
        }
        [Produces("text/plain")]
        [HttpGet("notify_{pid}_{mid}.do"), LogAttribute("出款订单通知")]
        public async Task<string> Notify(int pid, int mid)
        {
            NotifyReturnModel n = await SettleOrderBll._.CallBack(pid, mid, Request, Response);
            if (n.IsCheck && n.IsPay == 1)
            {
                SettleOrderBll._.Publish(WebConfig.MchId, n.OrderNumber);
            }
            return n.ReturnMsg;
        }
    }
}
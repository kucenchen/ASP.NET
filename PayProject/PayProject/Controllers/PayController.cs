using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayProject.Pay;
using Microsoft.AspNetCore.Mvc;
using PayProject.Model;
using PayProject.Common;
using EasyNetQ;
using PayProject.Bll;
using PayProject.Mq.Messages;
using EasyNetQ.Topology;

namespace PayProject.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class PayController : Controller
    {
        
     
        public PayController()
        {
           
        }

        [HttpPost("tt/my.html"), PayLogAttribute("测试1")]
        public async Task<JsonResult> tt(string id,int dd)
        {
            //var res = await _urlService.GetPagesAsync(parm);
            return Json(new { code = 0, msg = "success", id=id,dd=dd });
        }
        [HttpPost("unifiedorder")]
        public async Task<UnifiedorderReturn> Unifiedorder(string mchid,string orderid,string body,int paytype, string amount,string attach,string ip,string callbackurl,string notifyurl,string sign)
        {
            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("mchid", mchid);
            para.Add("orderid", orderid);
            para.Add("body", body);
            para.Add("paytype", paytype.ToString());
            para.Add("amount", amount);
            para.Add("attach", attach);
            para.Add("ip", ip);
            para.Add("callbackurl", callbackurl);
            para.Add("notifyurl", notifyurl);

            string temp = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), DB.MchKey);

            Dos.Common.LogHelper.Debug(temp);

            UnifiedorderReturn r = new UnifiedorderReturn();

            if (mchid != DB.MchId)
            {
                r.Type = PayReturnType.Err;
                r.Content = "商户号不存在";
                return r;
            }


            temp = Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");

            if (temp != sign)
            {
                r.Type = PayReturnType.Err;
                r.Content = "签名错误";
                return r;
            }


            return await Pay_OrderBll.Instance.Unifiedorder(mchid, orderid, body, paytype, amount, attach, ip, callbackurl, notifyurl);
        }
        [HttpPost("query")]
        public async Task<QueryReturn> Query(string mchid, string orderid, string sign) {
            QueryReturn r = new QueryReturn();

            SortedDictionary<string, string> para = new SortedDictionary<string, string>();

            para.Add("mchid", mchid);
            para.Add("orderid", orderid);
         
            string temp = string.Format("{0}&key={1}", OnlinePay.GetParamSrc(para), DB.MchKey);

            Dos.Common.LogHelper.Debug(temp);

        

            if (mchid != DB.MchId)
            {
                r.ReturnMsg = "商户号不存在";
                return r;
            }


            temp = Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");

            if (temp != sign)
            {             
                r.ReturnMsg = "签名错误";
                return r;
            }


            return await Pay_OrderBll.Instance.Query(mchid, orderid);


            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("callback_{pid}_{mid}.do")]
        public async Task<string> CallBack(int pid,int mid) {
            NotifyReturn n = await Pay_OrderBll.Instance.CallBack(pid, mid, Request, Response);
            if (n.IsCheck && n.IsPay) {
                //_bus.PublishAsync(new PayOrderNotify { mchid = DB.MchId, orderid = n.OrderNumber });
            }
            return n.ReturnMsg;
        }
        [HttpGet("notify_{pid}_{mid}.do")]
        public async Task<string> Notify(int pid, int mid)
        {
            NotifyReturn n = await Pay_OrderBll.Instance.CallBack(pid, mid, Request, Response);
            if (n.IsCheck && n.IsPay)
            {
                Settle_OrderBll.Instance.Publish(DB.MchId, n.OrderNumber);
            }
            return n.ReturnMsg;
        }
    }
}
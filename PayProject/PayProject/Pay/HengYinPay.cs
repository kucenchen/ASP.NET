using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PayProject.Common;
using PayProject.Model;

namespace PayProject.Pay
{
    public class HengYinPay : OnlinePay
    {
        public HengYinPay()
        {

        }
        public HengYinPay(int plat, string mchid) : base(plat, mchid)
        {

        }
        public HengYinPay(Pay_plat p, Pay_mch m) : base(p, m)
        {

        }
        public override Task<NotifyReturn> CallBack(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<NotifyReturn> Notify(HttpRequest request)
        {
            NotifyReturn notifyReturn = new NotifyReturn();
            var body = request.Body;
            string content = string.Empty;
            using (StreamReader dRead = new StreamReader(body, Encoding.UTF8))
            {
                content = dRead.ReadToEnd();
            }
            hyNotify j = JsonConvert.DeserializeObject<hyNotify>(content);
            string krid = j.krid;
            string money = j.money;
            string order_sn = j.order_sn;
            string out_order_sn = j.out_order_sn;
            string status = j.status;
            data data = j.data;
            string kts = j.kts;
            string sign = j.sign;
            string signstr = string.Format("krid={0}&money={1}&order_sn={2}&out_order_sn={3}&status={4}&kts={5}", krid, money, order_sn, out_order_sn, status, kts);

            string _sign = PayHelper.Md5Hash4(signstr);
            _sign = PayHelper.Md5Hash4(_sign + this.MchKey);
            if (status == "success" && _sign.ToLower() == sign.ToLower())
            {
                notifyReturn.MchID = this.MchID;
                notifyReturn.IsCheck = true;
            }
            else
            {
                notifyReturn.MchID = this.MchID;
                notifyReturn.IsCheck = false;
            }
            return new Task<NotifyReturn>(() => notifyReturn);
        }

        public override Task<QueryReturn> OrderQuery(string OrderNumber)
        {
            QueryReturn queryReturn = new QueryReturn();
            IDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("rid", this.MchID);
            dic.Add("order_sn", OrderNumber);
            string response = HttpHelper.PostJosn(this.Plat.Req_gateway, JsonConvert.SerializeObject(dic));
            dynamic m = JsonConvert.DeserializeObject(response);
            string errno = m["errno"];
            string msg = m["msg"];
            if (errno == "0")
            {
                queryReturn.ReturnMsg = "支付成功";
                queryReturn.Attach = queryReturn.ReturnMsg;
                queryReturn.OrderNumber = OrderNumber;
                queryReturn.SerialNumber = OrderNumber;
                decimal amount = m["data"]["money"];
                queryReturn.Totalfee = amount / 1m;
                queryReturn.IsPay = true;
            }
            else
            {
                queryReturn.ReturnMsg = "未支付";
                queryReturn.Attach = queryReturn.ReturnMsg;
                queryReturn.OrderNumber = OrderNumber;
                queryReturn.SerialNumber = OrderNumber;
                decimal amount = m["data"]["money"];
                queryReturn.Totalfee = amount / 1m;
                queryReturn.IsPay = false;
            }
            return new Task<QueryReturn>(() => queryReturn);
        }

        public override Task<UnifiedorderReturn> Unifiedorder(string OrderId, string Paytype, decimal Totalfee, string Ip, string Body, string Attach)
        {
            UnifiedorderReturn unifiedorderReturn = new UnifiedorderReturn();
            IDictionary<string, string> dic = new SortedDictionary<string, string>();
            string channel = "alipay";
            switch (Paytype)
            {
                case "1"://网银
                    channel = "unipay";
                    break;
                case "2"://支付宝
                    channel = "aliToCard";// "alipay";
                    break;
                case "3"://微信支付
                    channel = "wxpay";
                    break;
                case "4"://云闪付
                    channel = "unipay";
                    break;
                default:
                    channel = "unipay";
                    break;
            }
            dic.Add("rid", this.MchID);
            dic.Add("channel", channel);
            dic.Add("price", Totalfee.ToString("F2"));
            dic.Add("user_id", new Random().Next(1000, 9999).ToString());
            dic.Add("notify_url", this.NotifyUrl);
            dic.Add("out_order_sn", OrderId);
            string signstr = PayHelper.GetParamSrc(dic);
            signstr = string.Format("krid={0}&{1}&kts={2}", this.MchID, signstr, PayHelper.GenerateTimeStamp());
            string sign = PayHelper.Md5Hash4(signstr);
            sign = PayHelper.Md5Hash4(sign + this.MchKey);
            dic.Add("sign", sign);
            dic.Add("kts", PayHelper.GenerateTimeStamp());
            dic.Add("krid", this.MchID);
            string response = HttpHelper.PostJosn(this.Plat.Pay_gateway, JsonConvert.SerializeObject(dic));
            dynamic jo = JsonConvert.DeserializeObject(response);
            string resCode = jo["errno"];
            if (resCode == "0")
            {
                string url = jo["data"]["pay_link"];
                unifiedorderReturn.Type = PayReturnType.Url;
                unifiedorderReturn.Content = url;
                unifiedorderReturn.OrderNumber = OrderId;
                unifiedorderReturn.SerialNumber = OrderId;
                unifiedorderReturn.RealPrice = Totalfee.ToString("F2");

            }
            else
            {
                unifiedorderReturn.Type = PayReturnType.Err;
                unifiedorderReturn.Content = "第三方下单失败";
                unifiedorderReturn.OrderNumber = OrderId;
                unifiedorderReturn.SerialNumber = OrderId;
                unifiedorderReturn.RealPrice = Totalfee.ToString("F2");
            }
            return Task.FromResult<UnifiedorderReturn>(unifiedorderReturn); 
            //return new Task<UnifiedorderReturn>(() => unifiedorderReturn);
        }

        private class hyNotify
        {
            public string krid { get; set; }
            public string money { get; set; }
            public string order_sn { get; set; }
            public string out_order_sn { get; set; }
            public string status { get; set; }
            public string kts { get; set; }
            public data data { get; set; }
            public string sign { get; set; }
        }
        private class data
        {
            public string Paytime { get; set; }
            public string PayStatements { get; set; }
            public string Paystatus { get; set; }
            public string Paytype { get; set; }
            public string Paydiscount { get; set; }
            public string Payreal { get; set; }
            public string Payamount { get; set; }
            public string PayWay { get; set; }
            public string PayNum { get; set; }
            public string Orderid { get; set; }
            public string Terminalid { get; set; }
            public string Bid { get; set; }
            public string Paydate { get; set; }
            public string Usermessage { get; set; }
        }
    }
}

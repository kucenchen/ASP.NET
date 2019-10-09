using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PayProject.Common;

namespace PayProject.Pay
{
    public class LemeiPay : OnlinePay
    {
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
            string P_UserId = j.P_UserId;
            string P_OrderId = j.P_OrderId;
            string P_FaceValue = j.P_FaceValue;
            string P_Notic = j.P_Notic;
            string P_Return = j.P_Return;
            string P_ErrCode = j.P_ErrCode;
            string P_SuccTime = j.P_SuccTime;
            string P_PostKey = j.P_PostKey;

            string signstr = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", P_UserId, P_OrderId, P_FaceValue, P_Notic, P_Return, P_ErrCode, P_SuccTime, this.MchKey2);

            string _sign = PayHelper.MD5Hash2(signstr);
            if (P_Return == "1" && _sign.ToLower() == P_PostKey.ToLower())
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
            return new Task<QueryReturn>(() => queryReturn);
        }

        public override Task<UnifiedorderReturn> Unifiedorder(string OrderId, string Paytype, decimal Totalfee, string Ip, string Body, string Attach)
        {
            UnifiedorderReturn unifiedorderReturn = new UnifiedorderReturn();
            IDictionary<string, string> dic = new Dictionary<string, string>();
            string channel = "1000";
            switch (Paytype)
            {
                case "1"://B2C網銀
                    channel = "5000";
                    break;
                case "2"://支付宝H5
                    channel = "1000";
                    break;
                case "3"://微信H5
                    channel = "2000";
                    break;
                default:
                    channel = "1000";
                    break;
            }
            dic.Add("P_UserId", this.MchID);
            dic.Add("P_OrderId", OrderId);
            dic.Add("P_CardId", "");
            dic.Add("P_CardPass", "");
            dic.Add("P_FaceValue", Totalfee.ToString("F2"));
            dic.Add("P_ChannelId", channel);

            string signstr = PayHelper.GetParamSrc2(dic,"|");
            string sign = PayHelper.MD5Hash1(signstr + this.MchKey).ToLower();
            dic.Add("P_PostKey", sign);
            dic.Add("P_Subject", "");
            dic.Add("P_Price", "0");
            dic.Add("P_Quantity", "0");
            dic.Add("P_Description", "");
            dic.Add("P_Notic", "");
            dic.Add("P_Result_URL", this.CallbackUrl);
            dic.Add("P_Notify_URL", this.NotifyUrl);
            dic.Add("ResultType", "1");
            string response = HttpHelper.Post(this.Plat.Pay_gateway, PayHelper.GetParamSrc(dic));
            dynamic jo = JsonConvert.DeserializeObject(response);
            string resCode = jo["Result_code"];
            if (resCode == "0")
            {
                string url = jo["PayUrl"];
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
            //return new Task<UnifiedorderReturn>(() => unifiedorderReturn);
            return Task.FromResult<UnifiedorderReturn>(unifiedorderReturn);
        }

        private class hyNotify
        {
            public string P_UserId { get; set; }
            public string P_OrderId { get; set; }
            public string P_FaceValue { get; set; }
            public string P_Notic { get; set; }
            public string P_Return { get; set; }
            public string P_ErrCode { get; set; }
            public string P_SuccTime { get; set; }
            public string P_PostKey { get; set; }
        }
    }
}
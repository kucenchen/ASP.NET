using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Dos.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using PayProject.Entity;
using PayProject.Logic.common;

namespace PayProject.Logic.Pay
{
    public class HengYinPay : OnlinePay
    {
        public HengYinPay()
        {

        }
        public HengYinPay(int plat, string mchid) : base(plat, mchid)
        {

        }
        public HengYinPay(PayPlat p, PayMch m) : base(p, m)
        {

        }
        public override Task<NotifyReturnModel> CallBack(HttpRequest request)
        {
            return Task.FromResult<NotifyReturnModel>(new NotifyReturnModel());
        }

        public override Task<NotifyReturnModel> Notify(HttpRequest request)
        {
           
            NotifyReturnModel notifyReturn = new NotifyReturnModel();
            string content = string.Empty;
            #region MyRegion
            long contentLen = request.ContentLength == null ? 0 : request.ContentLength.Value;
            if (contentLen > 0)
            {
                // 读取请求体中所有内容
                System.IO.Stream stream = request.Body;
                request.Body.Position = 0;
                byte[] buffer = new byte[contentLen];
                stream.Read(buffer, 0, buffer.Length);
                // 转化为字符串
                content = System.Text.Encoding.UTF8.GetString(buffer);
            }
            #endregion


            //var body = request.Body; 
            //using (StreamReader dRead = new StreamReader(body, Encoding.UTF8))
            //{
            //    content = dRead.ReadToEnd();
            //}
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
                notifyReturn.ReturnMsg = "ok";
                notifyReturn.IsPay = true;
                notifyReturn.MchID = this.MchID;
                notifyReturn.IsCheck = true;
            }
            else
            {
                notifyReturn.ReturnMsg = "支付失败";
                notifyReturn.IsPay = false;
                notifyReturn.MchID = this.MchID;
                notifyReturn.IsCheck = false;
            }
            return Task.FromResult<NotifyReturnModel>(notifyReturn);
        }

        public override Task<QueryReturnModel> OrderQuery(string OrderNumber)
        {
            QueryReturnModel queryReturn = new QueryReturnModel();
            queryReturn.ReturnMsg = "暂无接口";
            queryReturn.IsPay = false;
            return Task.FromResult<QueryReturnModel>(queryReturn);
            IDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("rid", this.MchID);
            dic.Add("order_sn", OrderNumber);
            string response = HttpHelper.Post(this.Plat.Req_gateway, JsonConvert.SerializeObject(dic));
            Dos.Common.LogHelper.Debug("第三方查询结果：" + response);
            dynamic m = JsonConvert.DeserializeObject(response);
            string errno = m["errno"];
            string msg = m["msg"];
            if (errno == "0")
            {
                bool isPaid = m["data"]["isPaid"];
                if (isPaid)
                {
                    decimal amount = 0;
                    string money = m["data"]["money"];
                    queryReturn.ReturnMsg = "支付成功";
                    queryReturn.Attach = queryReturn.ReturnMsg;
                    queryReturn.OrderNumber = OrderNumber;
                    queryReturn.SerialNumber = OrderNumber;
                    decimal.TryParse(money, out amount);
                    queryReturn.Totalfee = amount / 1m;
                    queryReturn.IsPay = true;
                    return Task.FromResult<QueryReturnModel>(queryReturn);
                }

            }
            queryReturn.ReturnMsg = "未支付";
            queryReturn.Attach = queryReturn.ReturnMsg;
            queryReturn.OrderNumber = OrderNumber;
            queryReturn.SerialNumber = OrderNumber;
            queryReturn.Totalfee = 0;
            queryReturn.IsPay = false;

            return Task.FromResult<QueryReturnModel>(queryReturn);
        }

        public override Task<UnifiedOrderReturnModel> Unifiedorder(string OrderId, string Paytype, decimal Totalfee, string Ip, string Body, string Attach)
        {
            UnifiedOrderReturnModel unifiedorderReturn = new UnifiedOrderReturnModel();
            IDictionary<string, string> dic = new SortedDictionary<string, string>();
            string channel = "alipay";
            switch (Paytype)
            { 
                case "1"://网银
                    channel = "unipay";
                    break;
                case "21"://支付宝转卡
                    channel = "aliToCard";// "alipay";
                    break;  
                case "14"://支付宝扫码
                    channel = "bmAlipay";
                    break;
                case "2"://支付宝H5
                    channel = "alipay";
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
            string response = HttpHelper.Post(this.Plat.Pay_gateway, JsonConvert.SerializeObject(dic));
            dynamic jo = JsonConvert.DeserializeObject(response);
            string resCode = jo["errno"];
            if (resCode == "0")
            {
                string url = jo["data"]["pay_link"];
                unifiedorderReturn.Type = PayReturnTypeEnum.Url;
                unifiedorderReturn.Content = url;
                unifiedorderReturn.OrderNumber = OrderId;
                unifiedorderReturn.SerialNumber = OrderId;
                unifiedorderReturn.RealPrice = Totalfee.ToString("F2");

            }
            else
            {
                unifiedorderReturn.Type = PayReturnTypeEnum.Err;
                unifiedorderReturn.Content = "第三方下单失败";
                unifiedorderReturn.OrderNumber = OrderId;
                unifiedorderReturn.SerialNumber = OrderId;
                unifiedorderReturn.RealPrice = Totalfee.ToString("F2");
            }
            return Task.FromResult<UnifiedOrderReturnModel>(unifiedorderReturn);
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

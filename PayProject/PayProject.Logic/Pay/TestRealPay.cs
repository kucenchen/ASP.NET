using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PayProject.Entity;
using PayProject.Extensions;

namespace PayProject.Logic.Pay
{
    public class TestRealPay : OnlinePay
    {
        
        public TestRealPay(PayPlat p, PayMch m) : base(p, m)
        {
            
        }
        public override Task<NotifyReturnModel> CallBack(HttpRequest request)
        {
            NotifyReturnModel returnModel = new NotifyReturnModel();
            returnModel.IsCheck = true;
            returnModel.IsPay = true;
            returnModel.OrderNumber = "M20190522001";
            return Task.Run(() => returnModel);
        }

        public override Task<NotifyReturnModel> Notify(HttpRequest request)
        {
            NotifyReturnModel returnModel = new NotifyReturnModel();
            returnModel.IsCheck = true;
            returnModel.IsPay = true;
            returnModel.OrderNumber = request.Query["orderid"].ToString();
            returnModel.SerialNumber = Guid.NewGuid().ToString("N");
            return Task.Run(() => returnModel);
        }

        public override Task<QueryReturnModel> OrderQuery(string OrderNumber)
        {
            QueryReturnModel returnModel = new QueryReturnModel();
            returnModel.ReturnMsg = "ok";
            returnModel.IsPay = true;
            return Task.Run(() => returnModel);
        }

        public override Task<UnifiedOrderReturnModel> Unifiedorder(string OrderId, string Paytype, decimal Totalfee, string Ip, string Body, string Attach)
        {
            UnifiedOrderReturnModel returnModel = new UnifiedOrderReturnModel();
            returnModel.Type = PayReturnTypeEnum.QRcodeUrl;
            returnModel.Content = WebConfig.testPayUrl + string.Format("/web/pay/testpaysuccess_{0}.do", OrderId);
            returnModel.OrderNumber = OrderId;
            returnModel.SerialNumber = Guid.NewGuid().ToString("N");
            returnModel.RealPrice = Totalfee.ToString();
            return Task.Run(() => returnModel);
        }
    }
}

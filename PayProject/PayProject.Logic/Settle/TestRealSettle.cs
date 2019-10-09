using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PayProject.Entity;

namespace PayProject.Logic.Settle
{
    public class TestRealSettle : OnlineSettle
    {
        public TestRealSettle(SettlePlat p, SettleMch m) : base(p, m)
        {

        }
        public override Task<NotifyReturnModel> CallBack(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<NotifyReturnModel> Notify(HttpRequest request)
        {
            NotifyReturnModel returnModel = new NotifyReturnModel();
            returnModel.IsCheck = true;
            returnModel.IsPay = 1;
            returnModel.OrderNumber = request.Query["orderid"].ToString();
            returnModel.SerialNumber = Guid.NewGuid().ToString("N");
            return Task.Run(() => returnModel);
        }

        public override Task<QueryReturnModel> OrderQuery(string OrderNumber)
        {
            QueryReturnModel returnModel = new QueryReturnModel();
            returnModel.ReturnMsg = "ok";
            returnModel.IsPay = 1;
            return Task.Run(() => returnModel);
        }

        public override Task<UnifiedOrderReturnModel> Unifiedorder(string OrderId, string Bank_name, string Bank_branch, string Bank_card_number, string Bank_account, decimal Totalfee, string Ip, string Attach)
        {
            UnifiedOrderReturnModel returnModel = new UnifiedOrderReturnModel();
            returnModel.Type = PayReturnTypeEnum.Url;
            returnModel.SerialNumber = Guid.NewGuid().ToString("N");
            returnModel.RealPrice = Totalfee.ToString();
            return Task.Run(() => returnModel);
        }
    }
}

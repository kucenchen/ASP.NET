using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Logic.Pay
{
    public class QueryReturnModel
    {
        public string ReturnMsg;//接口返回信息  ok 表示查询成功
        public string Attach; //附加信息
        public string OrderNumber;//商户订单号
        public string SerialNumber;//支付平台流水号
        public decimal Totalfee;//支付成功总金额
        public bool IsPay;//是否付款成功
    }
}

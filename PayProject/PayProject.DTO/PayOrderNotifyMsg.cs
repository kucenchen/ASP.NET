using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.DTO
{
    [Serializable]
    public class PayOrderNotifyMsg
    {
        //public int code;//处理状态 0 失败 1 成功
        public string mchid;//商户号
        //public string msg;//接口返回信息  ok 表示查询成功
        //public string attach; //附加信息
        public string orderid;//商户订单号
        //public string serialid;//支付平台流水号
        //public decimal totalfee;//支付成功总金额
        //public int ispay;//是否付款成功
    }
}

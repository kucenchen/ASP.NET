using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayProject.WebAdmin.Models
{
    /// <summary>
    /// 提交支付订单模型
    /// </summary>
    public class PayOrderModel
    {
        public string MchId { get; set; }
        public string OrderId { get; set; }
        public string Body { get; set; }
  
        public int PayType { get; set; }
        public string Amount { get; set; }
        public string Attach { get; set; }
        public string Ip { get; set; }
        public string CallBackUrl { get; set; }
        public string NotifyUrl { get; set; }
        public string Sign { get; set; }
    }
}

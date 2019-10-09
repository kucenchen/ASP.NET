using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayProject.WebAdmin.Models
{
    /// <summary>
    /// 提交代付订单模型
    /// </summary>
    public class SettleOrderModel
    {
        public string AppId { get; set; }
        public string MchId { get; set; }
        public string OrderId { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Branch { get; set; }
        public string Bank_Card_Number { get; set; }
        public string Bank_Account { get; set; }
        public string Amount { get; set; }
        public string Attach { get; set; }
        public string Ip { get; set; }
        public string CallBackUrl { get; set; }
        public string NotifyUrl { get; set; }
        public string Sign { get; set; }
    }
}

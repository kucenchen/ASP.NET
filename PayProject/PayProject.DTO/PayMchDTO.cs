using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.DTO
{
    public class PayMchDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Id { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public System.String Mch_id { get; set; }

        /// <summary>
        /// 商户名称 自定义 管理名称
        /// </summary>
        public System.String Mch_name { get; set; }

        /// <summary>
        /// 商户密钥
        /// </summary>
        public System.String Mch_key { get; set; }

        /// <summary>
        /// 商户密钥2
        /// </summary>
        public System.String Mch_key2 { get; set; }

        /// <summary>
        /// 是否开启
        /// </summary>
        public System.Boolean Nullity { get; set; }

        /// <summary>
        /// 平台标识
        /// </summary>
        public System.Int32 Plat_id { get; set; }

        /// <summary>
        /// 费率千分比
        /// </summary>
        public System.Int32 Rate { get; set; }

        /// <summary>
        /// 开放时间点，多个用逗号分隔
        /// </summary>
        public System.String Open_time { get; set; }

        /// <summary>
        /// 开放面值 多个用逗号分隔
        /// </summary>
        public System.String Pay_money_list { get; set; }

        /// <summary>
        /// 回调主机名
        /// </summary>
        public System.String Callback_host { get; set; }

        /// <summary>
        /// 开放支付类型
        /// </summary>
        public System.String Open_pay_type_list { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Create_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Update_time { get; set; }

        /// <summary>
        /// 是否首次（废弃）
        /// </summary>
        public System.Int32? Forfist { get; set; }
    }
}

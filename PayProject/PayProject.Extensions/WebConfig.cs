using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Extensions
{
    public class WebConfig
    {
        public static readonly string MchId = ConfigExtensions.Configuration["PayConfig:MchId"].ToString();
        public static readonly string MchKey = ConfigExtensions.Configuration["PayConfig:MchKey"].ToString();
        public static readonly string rabbitMqConnection = ConfigExtensions.Configuration["DBConnection:RabbitMqConnection"];
        public static readonly string testPayUrl = ConfigExtensions.Configuration["TestPay:Url"];
    }
}

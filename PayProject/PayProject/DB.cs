using Dos.ORM;
using EasyNetQ;
using PayProject.Extensions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace PayProject
{
    public class DB
    {
        private static readonly string conn = ConfigExtensions.Configuration["DBConnection:MySqlConnectionString"].ToString();
        public static readonly string MchId = ConfigExtensions.Configuration["PayConfig:MchId"].ToString();
        public static readonly string MchKey = ConfigExtensions.Configuration["PayConfig:MchKey"].ToString();
        //private static readonly string rabbitMqConnection = null;// ConfigExtensions.Configuration["DBConnection:RabbitMqConnection"];
        private static readonly string rabbitMqConnection = ConfigExtensions.Configuration["DBConnection:RabbitMqConnection"];
        public static readonly DbSession Context = new DbSession(DatabaseType.MySql, conn);
        //public static readonly IBus RabbiBus = null;// RabbitHutch.CreateBus(rabbitMqConnection);
        public static readonly IBus RabbiBus = RabbitHutch.CreateBus(rabbitMqConnection);


    }

}

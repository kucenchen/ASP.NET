using Dos.ORM;
using EasyNetQ;
using PayProject.Common;
using PayProject.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Core
{
    public class DbContext
    {
        private static readonly string conn = ConfigExtensions.Configuration["DBConnection:MySqlConnectionString"].ToString();
        public static readonly string MchId = ConfigExtensions.Configuration["PayConfig:MchId"].ToString();
        public static readonly string MchKey = ConfigExtensions.Configuration["PayConfig:MchKey"].ToString();
        //private static readonly string rabbitMqConnection = ConfigExtensions.Configuration["DBConnection:RabbitMqConnection"];
        //public static readonly DbSession Db= new DbSession(DatabaseType.MySql, conn);
        public DbSession Db;
        //public static readonly IBus RabbiBus = RabbitHutch.CreateBus(rabbitMqConnection);
        private static DbContext _DbContext = null;
        private DbContext()
        {
            Db = new DbSession(DatabaseType.MySql, conn);
            if (Convert.ToBoolean(ConfigExtensions.Configuration["Sqllog:IsWriteLog"]))
            {
                Db.RegisterSqlLogger(database_OnLog);
            }
        }

        public static DbContext _
        {
            get
            {
                if (_DbContext == null)
                {
                    _DbContext = new DbContext();
                }
                return _DbContext;
            }
        }

        void database_OnLog(string logMsg)
        {
            string path = System.IO.Path.Combine(AppContext.BaseDirectory, "SQL_OnLog");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileFullPath = System.IO.Path.Combine(path, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            string str = logMsg + "\r\n";
            str += string.Format("IP:{0}, DateTime:{1} \r\n", Utils.GetIp(), DateTime.Now.ToString());
            str += "-----------------------------------------------------------\r\n\r\n";
            System.IO.File.AppendAllText(fileFullPath, str);
        }
    }
}

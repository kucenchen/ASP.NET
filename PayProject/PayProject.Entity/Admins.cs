using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Entity
{
    public class Admins
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string RealName { get; set; }
        public int RoleId { get; set; }
        //public Roles Roles { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIp { get; set; }
        public int ErrNum { get; set; }
        public bool Enable { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

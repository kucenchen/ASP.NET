﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://ITdos.com/Dos/ORM/Index.html
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Dos.ORM;

namespace PayProject.Entity
{
    /// <summary>
    /// 实体类SysAdmin。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("sys_admin")]
    [Serializable]
    [DataContract]
    public partial class SysAdmin : Dos.ORM.Entity
    {
        #region Model
        private string _Guid;
        private string _RoleGuid;
        private string _DepartmentName;
        private string _DepartmentGuid;
        private string _DepartmentGuidList;
        private string _LoginName;
        private string _LoginPwd;
        private string _TrueName;
        private string _Number;
        private string _HeadPic;
        private string _Sex;
        private string _Mobile;
        private bool _Status;
        private string _Email;
        private string _Summary;
        private DateTime _AddDate;
        private DateTime? _LoginDate;
        private DateTime? _UpLoginDate;

        /// <summary>
        /// 唯一标识
        /// </summary>
        [Field("Guid")]
        [DataMember]
        public string Guid
        {
            get { return _Guid; }
            set
            {
                this.OnPropertyValueChange("Guid");
                this._Guid = value;
            }
        }
        /// <summary>
        /// 角色标识
        /// </summary>
        [Field("RoleGuid")]
        [DataMember]
        public string RoleGuid
        {
            get { return _RoleGuid; }
            set
            {
                this.OnPropertyValueChange("RoleGuid");
                this._RoleGuid = value;
            }
        }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Field("DepartmentName")]
        [DataMember]
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set
            {
                this.OnPropertyValueChange("DepartmentName");
                this._DepartmentName = value;
            }
        }
        /// <summary>
        /// 部门标识
        /// </summary>
        [Field("DepartmentGuid")]
        [DataMember]
        public string DepartmentGuid
        {
            get { return _DepartmentGuid; }
            set
            {
                this.OnPropertyValueChange("DepartmentGuid");
                this._DepartmentGuid = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("DepartmentGuidList")]
        [DataMember]
        public string DepartmentGuidList
        {
            get { return _DepartmentGuidList; }
            set
            {
                this.OnPropertyValueChange("DepartmentGuidList");
                this._DepartmentGuidList = value;
            }
        }
        /// <summary>
        /// 登录账号
        /// </summary>
        [Field("LoginName")]
        [DataMember]
        public string LoginName
        {
            get { return _LoginName; }
            set
            {
                this.OnPropertyValueChange("LoginName");
                this._LoginName = value;
            }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Field("LoginPwd")]
        [DataMember]
        public string LoginPwd
        {
            get { return _LoginPwd; }
            set
            {
                this.OnPropertyValueChange("LoginPwd");
                this._LoginPwd = value;
            }
        }
        /// <summary>
        /// 真是姓名
        /// </summary>
        [Field("TrueName")]
        [DataMember]
        public string TrueName
        {
            get { return _TrueName; }
            set
            {
                this.OnPropertyValueChange("TrueName");
                this._TrueName = value;
            }
        }
        /// <summary>
        /// 编号
        /// </summary>
        [Field("Number")]
        [DataMember]
        public string Number
        {
            get { return _Number; }
            set
            {
                this.OnPropertyValueChange("Number");
                this._Number = value;
            }
        }
        /// <summary>
        /// 头像
        /// </summary>
        [Field("HeadPic")]
        [DataMember]
        public string HeadPic
        {
            get { return _HeadPic; }
            set
            {
                this.OnPropertyValueChange("HeadPic");
                this._HeadPic = value;
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        [Field("Sex")]
        [DataMember]
        public string Sex
        {
            get { return _Sex; }
            set
            {
                this.OnPropertyValueChange("Sex");
                this._Sex = value;
            }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Field("Mobile")]
        [DataMember]
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                this.OnPropertyValueChange("Mobile");
                this._Mobile = value;
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        [Field("Status")]
        [DataMember]
        public bool Status
        {
            get { return _Status; }
            set
            {
                this.OnPropertyValueChange("Status");
                this._Status = value;
            }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Field("Email")]
        [DataMember]
        public string Email
        {
            get { return _Email; }
            set
            {
                this.OnPropertyValueChange("Email");
                this._Email = value;
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        [Field("Summary")]
        [DataMember]
        public string Summary
        {
            get { return _Summary; }
            set
            {
                this.OnPropertyValueChange("Summary");
                this._Summary = value;
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Field("AddDate")]
        [DataMember]
        public DateTime AddDate
        {
            get { return _AddDate; }
            set
            {
                this.OnPropertyValueChange("AddDate");
                this._AddDate = value;
            }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        [Field("LoginDate")]
        [DataMember]
        public DateTime? LoginDate
        {
            get { return _LoginDate; }
            set
            {
                this.OnPropertyValueChange("LoginDate");
                this._LoginDate = value;
            }
        }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Field("UpLoginDate")]
        [DataMember]
        public DateTime? UpLoginDate
        {
            get { return _UpLoginDate; }
            set
            {
                this.OnPropertyValueChange("UpLoginDate");
                this._UpLoginDate = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
                _.Guid,
            };
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
                _.Guid,
                _.RoleGuid,
                _.DepartmentName,
                _.DepartmentGuid,
                _.DepartmentGuidList,
                _.LoginName,
                _.LoginPwd,
                _.TrueName,
                _.Number,
                _.HeadPic,
                _.Sex,
                _.Mobile,
                _.Status,
                _.Email,
                _.Summary,
                _.AddDate,
                _.LoginDate,
                _.UpLoginDate,
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._Guid,
                this._RoleGuid,
                this._DepartmentName,
                this._DepartmentGuid,
                this._DepartmentGuidList,
                this._LoginName,
                this._LoginPwd,
                this._TrueName,
                this._Number,
                this._HeadPic,
                this._Sex,
                this._Mobile,
                this._Status,
                this._Email,
                this._Summary,
                this._AddDate,
                this._LoginDate,
                this._UpLoginDate,
            };
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "sys_admin");
            /// <summary>
			/// 唯一标识
			/// </summary>
			public readonly static Field Guid = new Field("Guid", "sys_admin", "唯一标识");
            /// <summary>
			/// 角色标识
			/// </summary>
			public readonly static Field RoleGuid = new Field("RoleGuid", "sys_admin", "角色标识");
            /// <summary>
			/// 部门名称
			/// </summary>
			public readonly static Field DepartmentName = new Field("DepartmentName", "sys_admin", "部门名称");
            /// <summary>
			/// 部门标识
			/// </summary>
			public readonly static Field DepartmentGuid = new Field("DepartmentGuid", "sys_admin", "部门标识");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field DepartmentGuidList = new Field("DepartmentGuidList", "sys_admin", "");
            /// <summary>
			/// 登录账号
			/// </summary>
			public readonly static Field LoginName = new Field("LoginName", "sys_admin", "登录账号");
            /// <summary>
			/// 登录密码
			/// </summary>
			public readonly static Field LoginPwd = new Field("LoginPwd", "sys_admin", "登录密码");
            /// <summary>
			/// 真是姓名
			/// </summary>
			public readonly static Field TrueName = new Field("TrueName", "sys_admin", "真是姓名");
            /// <summary>
			/// 编号
			/// </summary>
			public readonly static Field Number = new Field("Number", "sys_admin", "编号");
            /// <summary>
			/// 头像
			/// </summary>
			public readonly static Field HeadPic = new Field("HeadPic", "sys_admin", "头像");
            /// <summary>
			/// 性别
			/// </summary>
			public readonly static Field Sex = new Field("Sex", "sys_admin", "性别");
            /// <summary>
			/// 手机号码
			/// </summary>
			public readonly static Field Mobile = new Field("Mobile", "sys_admin", "手机号码");
            /// <summary>
			/// 状态
			/// </summary>
			public readonly static Field Status = new Field("Status", "sys_admin", "状态");
            /// <summary>
			/// 邮箱
			/// </summary>
			public readonly static Field Email = new Field("Email", "sys_admin", "邮箱");
            /// <summary>
			/// 描述
			/// </summary>
			public readonly static Field Summary = new Field("Summary", "sys_admin", "描述");
            /// <summary>
			/// 添加时间
			/// </summary>
			public readonly static Field AddDate = new Field("AddDate", "sys_admin", "添加时间");
            /// <summary>
			/// 登录时间
			/// </summary>
			public readonly static Field LoginDate = new Field("LoginDate", "sys_admin", "登录时间");
            /// <summary>
			/// 上次登录时间
			/// </summary>
			public readonly static Field UpLoginDate = new Field("UpLoginDate", "sys_admin", "上次登录时间");
        }
        #endregion
    }

}

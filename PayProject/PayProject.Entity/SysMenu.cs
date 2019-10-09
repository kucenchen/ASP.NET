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
    /// 实体类Sys_menu。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("sys_menu")]
    [Serializable]
    [DataContract]
    public partial class SysMenu : Dos.ORM.Entity
    {
        #region Model
        private string _Guid;
        private string _SiteGuid;
        private string _ParentGuid;
        private string _ParentName;
        private string _Name;
        private string _NameCode;
        private string _ParentGuidList;
        private int _Layer;
        private string _Urls;
        private string _Icon;
        private int _Sort;
        private bool _Status;
        private DateTime _EditTime;
        private DateTime _AddTIme;

        /// <summary>
        /// 唯一标识Guid
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
        /// 所属站点或公司菜单
        /// </summary>
        [Field("SiteGuid")]
        [DataMember]
        public string SiteGuid
        {
            get { return _SiteGuid; }
            set
            {
                this.OnPropertyValueChange("SiteGuid");
                this._SiteGuid = value;
            }
        }
        /// <summary>
        /// 菜单父级Guid
        /// </summary>
        [Field("ParentGuid")]
        [DataMember]
        public string ParentGuid
        {
            get { return _ParentGuid; }
            set
            {
                this.OnPropertyValueChange("ParentGuid");
                this._ParentGuid = value;
            }
        }
        /// <summary>
        /// 父级菜单名称
        /// </summary>
        [Field("ParentName")]
        [DataMember]
        public string ParentName
        {
            get { return _ParentName; }
            set
            {
                this.OnPropertyValueChange("ParentName");
                this._ParentName = value;
            }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Field("Name")]
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                this.OnPropertyValueChange("Name");
                this._Name = value;
            }
        }
        /// <summary>
        /// 菜单名称标识
        /// </summary>
        [Field("NameCode")]
        [DataMember]
        public string NameCode
        {
            get { return _NameCode; }
            set
            {
                this.OnPropertyValueChange("NameCode");
                this._NameCode = value;
            }
        }
        /// <summary>
        /// 所属父级的集合
        /// </summary>
        [Field("ParentGuidList")]
        [DataMember]
        public string ParentGuidList
        {
            get { return _ParentGuidList; }
            set
            {
                this.OnPropertyValueChange("ParentGuidList");
                this._ParentGuidList = value;
            }
        }
        /// <summary>
        /// 菜单深度
        /// </summary>
        [Field("Layer")]
        [DataMember]
        public int Layer
        {
            get { return _Layer; }
            set
            {
                this.OnPropertyValueChange("Layer");
                this._Layer = value;
            }
        }
        /// <summary>
        /// 菜单Url
        /// </summary>
        [Field("Urls")]
        [DataMember]
        public string Urls
        {
            get { return _Urls; }
            set
            {
                this.OnPropertyValueChange("Urls");
                this._Urls = value;
            }
        }
        /// <summary>
        /// 菜单图标Class
        /// </summary>
        [Field("Icon")]
        [DataMember]
        public string Icon
        {
            get { return _Icon; }
            set
            {
                this.OnPropertyValueChange("Icon");
                this._Icon = value;
            }
        }
        /// <summary>
        /// 菜单排序
        /// </summary>
        [Field("Sort")]
        [DataMember]
        public int Sort
        {
            get { return _Sort; }
            set
            {
                this.OnPropertyValueChange("Sort");
                this._Sort = value;
            }
        }
        /// <summary>
        /// 菜单状态 true=正常 false=不显示
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
        /// 修改时间
        /// </summary>
        [Field("EditTime")]
        [DataMember]
        public DateTime EditTime
        {
            get { return _EditTime; }
            set
            {
                this.OnPropertyValueChange("EditTime");
                this._EditTime = value;
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Field("AddTIme")]
        [DataMember]
        public DateTime AddTIme
        {
            get { return _AddTIme; }
            set
            {
                this.OnPropertyValueChange("AddTIme");
                this._AddTIme = value;
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
                _.SiteGuid,
                _.ParentGuid,
                _.ParentName,
                _.Name,
                _.NameCode,
                _.ParentGuidList,
                _.Layer,
                _.Urls,
                _.Icon,
                _.Sort,
                _.Status,
                _.EditTime,
                _.AddTIme,
            };
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
                this._Guid,
                this._SiteGuid,
                this._ParentGuid,
                this._ParentName,
                this._Name,
                this._NameCode,
                this._ParentGuidList,
                this._Layer,
                this._Urls,
                this._Icon,
                this._Sort,
                this._Status,
                this._EditTime,
                this._AddTIme,
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
            public readonly static Field All = new Field("*", "sys_menu");
            /// <summary>
			/// 唯一标识Guid
			/// </summary>
			public readonly static Field Guid = new Field("Guid", "sys_menu", "唯一标识Guid");
            /// <summary>
			/// 所属站点或公司菜单
			/// </summary>
			public readonly static Field SiteGuid = new Field("SiteGuid", "sys_menu", "所属站点或公司菜单");
            /// <summary>
			/// 菜单父级Guid
			/// </summary>
			public readonly static Field ParentGuid = new Field("ParentGuid", "sys_menu", "菜单父级Guid");
            /// <summary>
			/// 父级菜单名称
			/// </summary>
			public readonly static Field ParentName = new Field("ParentName", "sys_menu", "父级菜单名称");
            /// <summary>
			/// 菜单名称
			/// </summary>
			public readonly static Field Name = new Field("Name", "sys_menu", "菜单名称");
            /// <summary>
			/// 菜单名称标识
			/// </summary>
			public readonly static Field NameCode = new Field("NameCode", "sys_menu", "菜单名称标识");
            /// <summary>
			/// 所属父级的集合
			/// </summary>
			public readonly static Field ParentGuidList = new Field("ParentGuidList", "sys_menu", "所属父级的集合");
            /// <summary>
			/// 菜单深度
			/// </summary>
			public readonly static Field Layer = new Field("Layer", "sys_menu", "菜单深度");
            /// <summary>
			/// 菜单Url
			/// </summary>
			public readonly static Field Urls = new Field("Urls", "sys_menu", "菜单Url");
            /// <summary>
			/// 菜单图标Class
			/// </summary>
			public readonly static Field Icon = new Field("Icon", "sys_menu", "菜单图标Class");
            /// <summary>
			/// 菜单排序
			/// </summary>
			public readonly static Field Sort = new Field("Sort", "sys_menu", "菜单排序");
            /// <summary>
			/// 菜单状态 true=正常 false=不显示
			/// </summary>
			public readonly static Field Status = new Field("Status", "sys_menu", "菜单状态 true=正常 false=不显示");
            /// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field EditTime = new Field("EditTime", "sys_menu", "修改时间");
            /// <summary>
			/// 添加时间
			/// </summary>
			public readonly static Field AddTIme = new Field("AddTIme", "sys_menu", "添加时间");
        }
        #endregion
    }

}
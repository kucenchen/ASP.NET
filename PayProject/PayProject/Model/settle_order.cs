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
using Dos.ORM;

namespace PayProject.Model
{
    /// <summary>
    /// 实体类Settle_order。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("settle_order")]
    [Serializable]
    public partial class Settle_order : Entity
    {
        #region Model
		private int _Id;
		private string _Order_id;
		private string _Plat_order_id;
		private string _Bank_name;
		private string _Bank_branch;
		private string _Bank_card_number;
		private string _Bank_account;
		private int _Mch_id;
		private decimal _Order_amount;
		private decimal _Pay_amount;
		private int _Create_time;
		private int _Update_time;
		private int _Finish_time;
		private int _Status;
		private string _Returnmsg;
		private string _Callback_url;
		private string _Notify_url;
		private int? _Notify_status;
		private int? _Notify_times;
		private int? _Notify_lasttime;
		private string _Attach;

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get{ return _Id; }
			set
			{
				this.OnPropertyValueChange(_.Id, _Id, value);
				this._Id = value;
			}
		}
		/// <summary>
		/// 订单号
		/// </summary>
		public string Order_id
		{
			get{ return _Order_id; }
			set
			{
				this.OnPropertyValueChange(_.Order_id, _Order_id, value);
				this._Order_id = value;
			}
		}
		/// <summary>
		/// 订单平台流水号
		/// </summary>
		public string Plat_order_id
		{
			get{ return _Plat_order_id; }
			set
			{
				this.OnPropertyValueChange(_.Plat_order_id, _Plat_order_id, value);
				this._Plat_order_id = value;
			}
		}
		/// <summary>
		/// 银行名称
		/// </summary>
		public string Bank_name
		{
			get{ return _Bank_name; }
			set
			{
				this.OnPropertyValueChange(_.Bank_name, _Bank_name, value);
				this._Bank_name = value;
			}
		}
		/// <summary>
		/// 开户支行
		/// </summary>
		public string Bank_branch
		{
			get{ return _Bank_branch; }
			set
			{
				this.OnPropertyValueChange(_.Bank_branch, _Bank_branch, value);
				this._Bank_branch = value;
			}
		}
		/// <summary>
		/// 银行卡号
		/// </summary>
		public string Bank_card_number
		{
			get{ return _Bank_card_number; }
			set
			{
				this.OnPropertyValueChange(_.Bank_card_number, _Bank_card_number, value);
				this._Bank_card_number = value;
			}
		}
		/// <summary>
		/// 银行帐户名
		/// </summary>
		public string Bank_account
		{
			get{ return _Bank_account; }
			set
			{
				this.OnPropertyValueChange(_.Bank_account, _Bank_account, value);
				this._Bank_account = value;
			}
		}
		/// <summary>
		/// 商户号
		/// </summary>
		public int Mch_id
		{
			get{ return _Mch_id; }
			set
			{
				this.OnPropertyValueChange(_.Mch_id, _Mch_id, value);
				this._Mch_id = value;
			}
		}
		/// <summary>
		/// 订单金额
		/// </summary>
		public decimal Order_amount
		{
			get{ return _Order_amount; }
			set
			{
				this.OnPropertyValueChange(_.Order_amount, _Order_amount, value);
				this._Order_amount = value;
			}
		}
		/// <summary>
		/// 实际打款金额
		/// </summary>
		public decimal Pay_amount
		{
			get{ return _Pay_amount; }
			set
			{
				this.OnPropertyValueChange(_.Pay_amount, _Pay_amount, value);
				this._Pay_amount = value;
			}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public int Create_time
		{
			get{ return _Create_time; }
			set
			{
				this.OnPropertyValueChange(_.Create_time, _Create_time, value);
				this._Create_time = value;
			}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public int Update_time
		{
			get{ return _Update_time; }
			set
			{
				this.OnPropertyValueChange(_.Update_time, _Update_time, value);
				this._Update_time = value;
			}
		}
		/// <summary>
		/// 订单完成时间
		/// </summary>
		public int Finish_time
		{
			get{ return _Finish_time; }
			set
			{
				this.OnPropertyValueChange(_.Finish_time, _Finish_time, value);
				this._Finish_time = value;
			}
		}
		/// <summary>
		/// 订单状态   0  未支付   1   支付成功
		/// </summary>
		public int Status
		{
			get{ return _Status; }
			set
			{
				this.OnPropertyValueChange(_.Status, _Status, value);
				this._Status = value;
			}
		}
		/// <summary>
		/// 代付接口返回信息
		/// </summary>
		public string Returnmsg
		{
			get{ return _Returnmsg; }
			set
			{
				this.OnPropertyValueChange(_.Returnmsg, _Returnmsg, value);
				this._Returnmsg = value;
			}
		}
		/// <summary>
		/// 订单同步回调Url
		/// </summary>
		public string Callback_url
		{
			get{ return _Callback_url; }
			set
			{
				this.OnPropertyValueChange(_.Callback_url, _Callback_url, value);
				this._Callback_url = value;
			}
		}
		/// <summary>
		/// 订单异步通知Url
		/// </summary>
		public string Notify_url
		{
			get{ return _Notify_url; }
			set
			{
				this.OnPropertyValueChange(_.Notify_url, _Notify_url, value);
				this._Notify_url = value;
			}
		}
		/// <summary>
		/// 异步通知状态
		/// </summary>
		public int? Notify_status
		{
			get{ return _Notify_status; }
			set
			{
				this.OnPropertyValueChange(_.Notify_status, _Notify_status, value);
				this._Notify_status = value;
			}
		}
		/// <summary>
		/// 通知次数
		/// </summary>
		public int? Notify_times
		{
			get{ return _Notify_times; }
			set
			{
				this.OnPropertyValueChange(_.Notify_times, _Notify_times, value);
				this._Notify_times = value;
			}
		}
		/// <summary>
		/// 最后通知时间
		/// </summary>
		public int? Notify_lasttime
		{
			get{ return _Notify_lasttime; }
			set
			{
				this.OnPropertyValueChange(_.Notify_lasttime, _Notify_lasttime, value);
				this._Notify_lasttime = value;
			}
		}
		/// <summary>
		/// 附加参数
		/// </summary>
		public string Attach
		{
			get{ return _Attach; }
			set
			{
				this.OnPropertyValueChange(_.Attach, _Attach, value);
				this._Attach = value;
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
				_.Id,
			};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.Id,
				_.Order_id,
				_.Plat_order_id,
				_.Bank_name,
				_.Bank_branch,
				_.Bank_card_number,
				_.Bank_account,
				_.Mch_id,
				_.Order_amount,
				_.Pay_amount,
				_.Create_time,
				_.Update_time,
				_.Finish_time,
				_.Status,
				_.Returnmsg,
				_.Callback_url,
				_.Notify_url,
				_.Notify_status,
				_.Notify_times,
				_.Notify_lasttime,
				_.Attach,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._Order_id,
				this._Plat_order_id,
				this._Bank_name,
				this._Bank_branch,
				this._Bank_card_number,
				this._Bank_account,
				this._Mch_id,
				this._Order_amount,
				this._Pay_amount,
				this._Create_time,
				this._Update_time,
				this._Finish_time,
				this._Status,
				this._Returnmsg,
				this._Callback_url,
				this._Notify_url,
				this._Notify_status,
				this._Notify_times,
				this._Notify_lasttime,
				this._Attach,
			};
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
			public readonly static Field All = new Field("*", "settle_order");
            /// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("id", "settle_order", "");
            /// <summary>
			/// 订单号
			/// </summary>
			public readonly static Field Order_id = new Field("order_id", "settle_order", "订单号");
            /// <summary>
			/// 订单平台流水号
			/// </summary>
			public readonly static Field Plat_order_id = new Field("plat_order_id", "settle_order", "订单平台流水号");
            /// <summary>
			/// 银行名称
			/// </summary>
			public readonly static Field Bank_name = new Field("bank_name", "settle_order", "银行名称");
            /// <summary>
			/// 开户支行
			/// </summary>
			public readonly static Field Bank_branch = new Field("bank_branch", "settle_order", "开户支行");
            /// <summary>
			/// 银行卡号
			/// </summary>
			public readonly static Field Bank_card_number = new Field("bank_card_number", "settle_order", "银行卡号");
            /// <summary>
			/// 银行帐户名
			/// </summary>
			public readonly static Field Bank_account = new Field("bank_account", "settle_order", "银行帐户名");
            /// <summary>
			/// 商户号
			/// </summary>
			public readonly static Field Mch_id = new Field("mch_id", "settle_order", "商户号");
            /// <summary>
			/// 订单金额
			/// </summary>
			public readonly static Field Order_amount = new Field("order_amount", "settle_order", "订单金额");
            /// <summary>
			/// 实际打款金额
			/// </summary>
			public readonly static Field Pay_amount = new Field("pay_amount", "settle_order", "实际打款金额");
            /// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field Create_time = new Field("create_time", "settle_order", "创建时间");
            /// <summary>
			/// 更新时间
			/// </summary>
			public readonly static Field Update_time = new Field("update_time", "settle_order", "更新时间");
            /// <summary>
			/// 订单完成时间
			/// </summary>
			public readonly static Field Finish_time = new Field("finish_time", "settle_order", "订单完成时间");
            /// <summary>
			/// 订单状态   0  未支付   1   支付成功
			/// </summary>
			public readonly static Field Status = new Field("status", "settle_order", "订单状态   0  未支付   1   支付成功");
            /// <summary>
			/// 代付接口返回信息
			/// </summary>
			public readonly static Field Returnmsg = new Field("returnmsg", "settle_order", "代付接口返回信息");
            /// <summary>
			/// 订单同步回调Url
			/// </summary>
			public readonly static Field Callback_url = new Field("callback_url", "settle_order", "订单同步回调Url");
            /// <summary>
			/// 订单异步通知Url
			/// </summary>
			public readonly static Field Notify_url = new Field("notify_url", "settle_order", "订单异步通知Url");
            /// <summary>
			/// 异步通知状态
			/// </summary>
			public readonly static Field Notify_status = new Field("notify_status", "settle_order", "异步通知状态");
            /// <summary>
			/// 通知次数
			/// </summary>
			public readonly static Field Notify_times = new Field("notify_times", "settle_order", "通知次数");
            /// <summary>
			/// 最后通知时间
			/// </summary>
			public readonly static Field Notify_lasttime = new Field("notify_lasttime", "settle_order", "最后通知时间");
            /// <summary>
			/// 附加参数
			/// </summary>
			public readonly static Field Attach = new Field("attach", "settle_order", "附加参数");
        }
        #endregion
	}
}
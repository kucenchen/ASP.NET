using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common
{
    public enum UserRecordTypeEnum
    {
        /// <summary>
        /// 冻结
        /// </summary>
        Lock = 0,
        /// <summary>
        /// 解冻
        /// </summary>
        Unlock = 1,
        /// <summary>
        /// 转账设置
        /// </summary>
        TransConrol = 2,
        /// <summary>
        /// 昵称变更
        /// </summary>
        NickNameModify = 3,
        /// <summary>
        /// 节点设置
        /// </summary>
        IpSet = 4,
        /// <summary>
        /// 靓号赠送
        /// </summary>
        GivePrettyId = 5
    }
    /// <summary>
    /// 短信类型
    /// </summary>
    public enum ShortMessageTypeEnum
    {
        /// <summary>
        /// 注册
        /// </summary>
        Register = 0,
        /// <summary>
        /// 登录
        /// </summary>
        Login = 1,
        /// <summary>
        /// 绑定手机
        /// </summary>
        BindPhone = 2,
        /// <summary>
        /// 找回登录密码
        /// </summary>
        ReceiveLoginPwd = 3,
        /// <summary>
        /// 找回保险箱密码
        /// </summary>
        ReceiveSafeBoxPwd = 4
    }
}
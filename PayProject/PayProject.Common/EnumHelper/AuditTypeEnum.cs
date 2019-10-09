using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common
{
    /// <summary>
    /// 客户端显示提现交易状态(银行订单表) 1-成功 2-处理中 3-取消 4-冻结
    /// </summary>
    public enum TransStatusEnum
    {
        /// <summary>
        /// 交易成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 交易处理中
        /// </summary>
        Processing = 2,
        /// <summary>
        /// 交易关闭
        /// </summary>
        Closed = 3,
        /// <summary>
        /// 交易冻结
        /// </summary>
        Locked = 4
    }
    /// <summary>
    /// 交易场景(银行订单表)
    /// </summary>
    //public enum TransSceneTypeEnum
    //{
    //    大厅 = 0,
    //    网站 = 1,
    //    其他 = 2
    //}
    /// <summary>
    /// 客服/财务审核状态
    /// </summary>
    public enum AuditStatusEnum
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        CreateOrder = -1,
        /// <summary>
        /// 未审核
        /// </summary>
        Unaudited = 0,
        /// <summary>
        /// 审核中
        /// </summary>
        Auditing = 1,
        /// <summary>
        /// 通过
        /// </summary>
        Pass = 2,
        /// <summary>
        /// 冻结
        /// </summary>
        Locked = 3,
        /// <summary>
        /// 拒绝
        /// </summary>
        Closed = 4,
        /// <summary>
        /// 打款中
        /// </summary>
        Paymenting = 5,
        /// <summary>
        /// 打款失败
        /// </summary>
        PaymentFail = 6,
        /// <summary>
        /// 打款完成
        /// </summary>
        PaymentSuccess = 7
    }
    /// <summary>
    /// 提现订单审核状态
    /// </summary>
    public enum TxAuditStatusEnum
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        CreateOrder = -1,
        /// <summary>
        /// 客服待审核
        /// </summary>
        AwaitCSDAudit = 0,
        /// <summary>
        /// 客服审核中
        /// </summary>
        CSDAuditing = 1,
        /// <summary>
        /// 客服冻结
        /// </summary>
        CSDLocked = 2,
        /// <summary>
        /// 客服拒绝
        /// </summary>
        CSDClosed = 3,
        /// <summary>
        /// 客服通过
        /// </summary>
        CSDPass = 4,
        /// <summary>
        /// 财务待审核
        /// </summary>
        AwaitFDAudit = 5,
        /// <summary>
        /// 财务审核中
        /// </summary>
        FDAuditing = 6,
        /// <summary>
        /// 财务冻结
        /// </summary>
        FDLocked = 7,
        /// <summary>
        /// 财务拒绝
        /// </summary>
        FDClosed = 8,
        /// <summary>
        /// 财务通过
        /// </summary>
        FDPass = 9,
        /// <summary>
        /// 等待打款
        /// </summary>
        AwaitPayment = 10,
        /// <summary>
        /// 打款中
        /// </summary>
        Paymenting = 11,
        /// <summary>
        /// 打款失败
        /// </summary>
        PaymentFail = 12,
        /// <summary>
        /// 打款完成
        /// </summary>
        PaymentSuccess = 13
    }
    /// <summary>
    /// 完成状态
    /// </summary>
    public enum CompletionStatusEnum
    {
        /// <summary>
        /// 未完成
        /// </summary>
        UnFinish = 0,
        /// <summary>
        /// 完成
        /// </summary>
        Finish = 1
    }
    /// <summary>
    /// 打款银行类型
    /// </summary>
    public enum PayBankTypeEnum
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        Alipay = 2,
        /// <summary>
        /// 银行卡
        /// </summary>
        BankCard = 1
    }
    /// <summary>
    /// 付款平台
    /// </summary>
    public enum PaymentPlatformEnum
    {
        /// <summary>
        /// 人工打款
        /// </summary>
        ManualPayment,
        /// <summary>
        /// 代付平台1
        /// </summary>
        PaymentPlatform1,
        /// <summary>
        /// 代付平台2
        /// </summary>
        PaymentPlatform2
    }
    public enum SysConfigEnum
    {
        /// <summary>
        /// 提现控制
        /// </summary>
        CashOutControl = 4,
        /// <summary>
        /// 提现税率
        /// </summary>
        CashOutRate = 5,
        /// <summary>
        /// 保险箱转账税率
        /// </summary>
        SafeBoxTransRate = 6,
        /// <summary>
        /// 提现最低限额
        /// </summary>
        CashOutMinGold = 7
    }
}
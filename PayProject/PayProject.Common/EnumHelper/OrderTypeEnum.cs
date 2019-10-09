using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common.EnumHelper
{
    public enum OrderTypeEnum
    {
        /// <summary>
        /// 存取
        /// </summary>
        Access = 0,
        /// <summary>
        /// 充值
        /// </summary>
        Recharge = 1,
        /// <summary>
        /// 转账
        /// </summary>
        Transfer = 2,
        /// <summary>
        /// 提现
        /// </summary>
        CashOut = 3,
        /// <summary>
        /// 奖励
        /// </summary>
        Reward = 4,
        /// <summary>
        /// 划拨
        /// </summary>
        Allocation = 5,
        /// <summary>
        /// 代理领取
        /// </summary>
        AgentReceive = 6
    }
}
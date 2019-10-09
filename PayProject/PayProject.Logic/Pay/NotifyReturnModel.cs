using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Logic.Pay
{
    public class NotifyReturnModel : QueryReturnModel
    {
        public string MchID;//商户号
        public bool IsCheck;//是否验证通过
    }
}

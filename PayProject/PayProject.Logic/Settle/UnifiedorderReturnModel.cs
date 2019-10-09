using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Logic.Settle
{
    public class UnifiedOrderReturnModel
    {
        public PayReturnTypeEnum Type;//0 失败,1 html,2 url,3 ImgUrl,4 ImgBase64,5 QRcodeUrl,6 AppJson,7 手机端扫码
        public string Content;//如果调用失败，返回接口的错误信息，否则按类型返回信息
        public string OrderNumber;
        public string SerialNumber;
        public string RealPrice;
    }
}

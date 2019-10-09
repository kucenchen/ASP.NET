using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Logic.Pay
{
    public enum PayReturnTypeEnum
    {
        Err = 0,
        Html = 1,
        Url = 2,
        ImgUrl = 3,
        ImgBase64 = 4,
        QRcodeUrl = 5,
        AppJson = 6
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common
{
    /// <summary>
    /// 缓存Key工具类
    /// </summary>
    public class CacheKey
    {
        /// <summary>
        /// 网站站点
        /// </summary>
        public static string WEBCMSSITE = "FYT_WEBCMSSITE";

        /// <summary>
        /// 网站栏目
        /// </summary>
        public static string WEBCMSCOLUMN = "FYT_WEBCMSCOLUMN";

        /// <summary>
        /// 网站广告位
        /// </summary>
        public static string WEBCMSADV = "FYT_WEBCMSADV";

        #region GAME API
        /// <summary>
        /// RSA
        /// </summary>
        public static string GameRSA = "WEBAPI_GameRSA_";
        public static string GameToken = "WEBAPI_GameToken_";
        /// <summary>
        /// 短信类型 key+短信类型+手机号
        /// </summary>
        public static string GameShortMessage = "WEBAPI_GameShortMessage_{0}_{1}";
        #endregion
    }
}

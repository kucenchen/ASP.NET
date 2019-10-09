using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common.Util
{
    public class GameAPPUtils
    {
        private static string appid = "appid001";
        private static string token = "token8888888";

        public static string SignRequest(IDictionary<string, string> parameters, string charset = "utf-8")
        {
            parameters.Add("appid", appid);
            parameters.Add("timestamp", DateTime.Now.ToTimeStamp().ToString());
            string signContent = GetSignContent(parameters) + token;
            return Md5Crypt.Encrypt(signContent);
        }
        private static string GetSignContent(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(value).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }
        public static bool ValidateSign(IDictionary<string, string> parameters)
        {
            string _sign = parameters["sign"].ToString();
            string _appid = parameters["appid"].ToString();
            if (_appid != appid)
            {
                return false;
            }
            try
            {
                parameters.Remove("sign");
            }
            catch (Exception ex)
            {
            }
            DateTime dtTimestamp = Convert.ToInt32(parameters["timestamp"].ToString()).ToDateTime();
            DateTime dtCur = DateTime.Now;
            if (dtTimestamp.AddMinutes(15) > dtCur)
            {
                return false;
            }

            string signContent = GetSignContent(parameters) + token;
            string rightSign = Md5Crypt.Encrypt(signContent);
            if (_sign.Equals(rightSign, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
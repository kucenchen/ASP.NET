using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Common
{
    public static class PayHelper
    {
        public static string MD5Hash1(string md5Str)
        {
            string result3 = string.Empty;
            //32位大写
            using (var md5 = MD5.Create())
            {
                try
                {
                    var result = md5.ComputeHash(Encoding.UTF8.GetBytes(md5Str));
                    var strResult = BitConverter.ToString(result);
                    result3 = strResult.Replace("-", "");
                }
                catch (Exception ex)
                {
                    result3 = "";// ex.ToString();
                }
            }
            return result3;
        }
        public static string MD5Hash2(string md5Str)
        {
            string result3 = string.Empty;
            using (var md5 = MD5.Create())
            {
                try
                {
                    var data = md5.ComputeHash(Encoding.UTF8.GetBytes(md5Str));
                    StringBuilder builder = new StringBuilder();
                    // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("X2"));
                    }
                    result3 = builder.ToString();
                }
                catch (Exception ex)
                {
                    result3 = "";// ex.ToString();
                }
            }
            return result3;
        }
        /// <summary>
        /// 使用MD5CryptoServiceProvider 类
        /// </summary>
        /// <param name="md5Str"></param>
        /// <returns></returns>
        public static string MD5Hash3(string md5Str)
        {
            string result3 = string.Empty;
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(md5Str);
                string result = BitConverter.ToString(md5.ComputeHash(bytes));
                result3 = result.Replace("-", "");
            }
            catch (Exception ex)
            {
                result3 = "";// ex.ToString();
            }
            return result3;
        }
        public static string Md5Hash4(string MD5Str, string sEncoding = "UTF-8")
        {
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider(); 
            byte[] byteData = md5csp.ComputeHash(Encoding.GetEncoding(sEncoding).GetBytes(MD5Str));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteData.Length; i++)
            {
                sb.Append(byteData[i].ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 在32位基础上取中间16位：
        /// </summary>
        /// <param name="md5Str"></param>
        /// <returns></returns>
        public static string MD5Hash4(string md5Str)
        {
            string result3 = string.Empty;
            using (var md5 = MD5.Create())
            {
                try
                {
                    var data = md5.ComputeHash(Encoding.UTF8.GetBytes(md5Str));
                    StringBuilder builder = new StringBuilder();
                    // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串 
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("X2"));
                    }
                    result3 = builder.ToString().Substring(8, 16);
                }
                catch (Exception ex)
                {
                    result3 = "";// ex.ToString();
                }
            }
            return result3;
        }
        public static string GetParamSrc(IDictionary<string, string> paramsMap)
        {

            StringBuilder str = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in paramsMap)
            {
                string pkey = kv.Key;
                string pvalue = kv.Value;
                str.Append(pkey + "=" + pvalue + "&");
            }

            String result = str.ToString().Substring(0, str.ToString().Length - 1);
            return result.ToString();
        }

        public static string GetParamSrc2(IDictionary<string, string> paramsMap, string part)
        {

            StringBuilder str = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in paramsMap)
            {
                string pkey = kv.Key;
                string pvalue = kv.Value;
                str.Append(pvalue + part);
            }

            return str.ToString();
        }
        /**
     * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
      * @return 时间戳
     */
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        
    }
}

using Dos.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SetOrder();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public static void SetOrder()
        {
            string MchKey = "5rtQ98kxaeRq0n09oBknrtLUJwITV9IfFmIzbzWv4gqDGDF8Q5XIpe5q42513mU393A1Pbw5p5RyGRd09bgdw94g4ug2jCLEufvW4g2vndHB5grmoxahEhI4VPaaDPM4K2r6oteFzFc3K7gyFqVHIOonxDeg1i4EjwiZXKw0bTCz6smyX9PJ8hymZ0vWCjNQjGGxHD3IA9VmKD8vMVm8YeoGrvZDCEVaxDYbiq64QVK0cJ2CoIcFtC2niTrraVX9";
            //string url = "http://p.boximould.com/pay/unifiedorder";
            //SortedDictionary<string, string> para = new SortedDictionary<string, string>();
            //para.Add("mchid", "10000");
            //para.Add("orderid", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //para.Add("body", "body");
            //para.Add("paytype", "14");
            //para.Add("amount", "100");
            //para.Add("attach", "attach");
            //para.Add("ip", "192.168.1.1");
            //para.Add("callbackurl", "https://www.baidu.com/");
            //para.Add("notifyurl", "https://www.baidu.com/");

            //string temp = string.Format("{0}&key={1}", GetParamSrc(para), MchKey); 
            //string cusSign = MD5EncryptWeChat(temp, "utf-8");
            //para.Add("Sign", cusSign);
            //var res =Dos.Common.HttpHelper.Post(url, GetParamSrc(para));
            //Console.WriteLine(res);

            //{"type":2,"content":"http://api.banmapays.com/aapay/gREl1h122e0fIOJBFOWcykRQA.do?order_no=C927857743045209",
            //"orderNumber":"20190927200251","serialNumber":"20190927200251","realPrice":"100.00"}

            string queryurl = "http://p.boximould.com/pay/query";
            IDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("mchid", "10000");
            dic.Add("orderid", "20190927200251");
            string temp = string.Format("{0}&key={1}", GetParamSrc(dic), MchKey);
            string cusSign =Dos.Common.EncryptHelper.MD5EncryptWeChat(temp, "utf-8");
            dic.Add("sign", cusSign);
            string response = HttpHelper.Post(queryurl, dic);
            Console.WriteLine(response);

        }

        private static string GetParamSrc(IDictionary<string, string> paramsMap)
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


        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset">默认值：utf-8</param>
        /// <returns></returns>
        private static string MD5EncryptWeChat(string encypStr, string charset = "")
        {
            var m5 = new MD5CryptoServiceProvider();
            //创建md5对象
            byte[] inputBye;
            //使用GB2312编码方式把字符串转化为字节数组．
            if (!string.IsNullOrWhiteSpace(charset))
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            else
            {
                inputBye = Encoding.GetEncoding("utf-8").GetBytes(encypStr);
            }
            var outputBye = m5.ComputeHash(inputBye);
            var retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }


        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

    }
}

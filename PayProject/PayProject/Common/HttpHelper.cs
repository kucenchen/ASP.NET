using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Common
{
    public class HttpHelper
    {

        public static string Get(string url, string encoding = "UTF-8", int timeout = 1000) {
            return HttpResponse(url, "GET", "", "", timeout, "", null, encoding, null);
        }
        public static string Post(string url,string data, string encoding = "UTF-8", int timeout = 1000)
        {
            return HttpResponse(url, "POST", "application/x-www-form-urlencoded", data, timeout, "", null, encoding, null);
        }
        public static string PostJosn(string url, string data, string encoding = "UTF-8", int timeout = 1000)
        {
            return HttpResponse(url, "POST", "application/json", data, timeout, "", null, encoding, null);
        }

        public static string HttpResponse(string url,string Method,string contentType, string body, int? timeout, string userAgent, Dictionary<string, string> headers, string encoding, CookieCollection cookies)
        {
            string value = "";
            string res = "";
            var requestEncoding = Encoding.GetEncoding(encoding);
            var Stopwatch = new Stopwatch();
            
            Stopwatch.Start();
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("url");
                }
                if (requestEncoding == null)
                {
                    throw new ArgumentNullException("requestEncoding");
                }
                HttpWebRequest request = null;
                
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = WebRequest.Create(url) as HttpWebRequest;
                }
                request.Method = Method; //"POST";
                if (!string.IsNullOrEmpty(contentType)) {
                    request.ContentType = contentType; //"application/x-www-form-urlencoded";
                }
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        request.Headers.Add(h.Key, h.Value);
                    }
                }
                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (cookies != null)
                {
                    request.CookieContainer = new CookieContainer();
                    request.CookieContainer.Add(cookies);
                }
                //如果需要POST数据  
                if (!string.IsNullOrEmpty(body))
                {
                    byte[] data = requestEncoding.GetBytes(body);
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), requestEncoding);
                value = sr.ReadToEnd();
                response.Close();
                res = value;
            }
            catch (Exception ex)
            {
                //ex.ToString();
                res = ex.ToString();
                value = "";               
            }
            Stopwatch.Stop();

            Console.WriteLine(
                $"\n时间：{DateTime.Now.ToString("yy-MM-dd HH:mm:ss.fff")} \n " +
                $"地址：{url} \n " +
                $"方式：{Method} \n " +
                $"类型：{contentType} \n " +
                $"请求体：{body} \n " +
                $"结果：{res}\n " +
                $"耗时：{Stopwatch.Elapsed.TotalMilliseconds} 毫秒");

            return value;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
    }



}

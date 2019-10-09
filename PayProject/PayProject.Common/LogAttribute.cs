using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace PayProject.Common
{
    public class LogAttribute : ActionFilterAttribute
    {
        private string LogFlag { get; set; }
        private string ActionArguments { get; set; }

        /// <summary>
        /// 请求体中的所有值
        /// </summary>
        private string RequestBody { get; set; }

        private Stopwatch Stopwatch { get; set; }

        public LogAttribute(string logFlag)
        {
            LogFlag = logFlag;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //Request.EnableRewind();
            context.HttpContext.Request.EnableRewind();
            //  context.HttpContext.Request.EnableBuffering();
            // 后续添加了获取请求的请求体，如果在实际项目中不需要删除即可
            long contentLen = context.HttpContext.Request.ContentLength == null ? 0 : context.HttpContext.Request.ContentLength.Value;

            var ContentType = context.HttpContext.Request.ContentType;
            if (ContentType == "application/json" && context.HttpContext.Request.Method == "POST")
            {
                if (contentLen > 0)
                {
                    // 读取请求体中所有内容
                    System.IO.Stream stream = context.HttpContext.Request.Body;
                    context.HttpContext.Request.Body.Position = 0;
                    byte[] buffer = new byte[contentLen];
                    stream.Read(buffer, 0, buffer.Length);
                    // 转化为字符串
                    RequestBody = System.Text.Encoding.UTF8.GetString(buffer); 
                }

            }
            else
            {
                if (context.HttpContext.Request.Method == "POST" && string.IsNullOrEmpty(RequestBody.Replace("\0", "").Trim()))
                {
                    System.Text.StringBuilder temp = new System.Text.StringBuilder();
                    foreach (var f in context.HttpContext.Request.Form)
                    {
                        temp.AppendFormat("{0}={1}&", f.Key, f.Value);
                    }
                    RequestBody = temp.ToString();
                }
            }
            ActionArguments = Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionArguments);
            Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            Stopwatch.Stop();

            string url = context.HttpContext.Request.Host + context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
            string method = context.HttpContext.Request.Method;

            string qs = ActionArguments;

            dynamic result = context.Result.GetType().Name == "EmptyResult" ? new { Value = "无返回结果" } : context.Result as dynamic;

            string res = "在返回结果前发生了异常";
            try
            {
                if (result != null)
                {
                    res = Newtonsoft.Json.JsonConvert.SerializeObject(result.Value);
                }
            }
            catch (System.Exception)
            {
                res = "日志未获取到结果，返回的数据无法序列化";
            }


            Logger.Default.Info(
                $"\n时间：{DateTime.Now.ToString("yy-MM-dd HH:mm:ss.fff")} \n " +
                $"方法：{LogFlag} \n " +
                $"地址：{url} \n " +
                $"方式：{method} \n " +
                $"请求体：{RequestBody} \n " +
                $"参数：{qs}\n " +
                $"结果：{res}\n " +
                $"耗时：{Stopwatch.Elapsed.TotalMilliseconds} 毫秒");

        }
    }
}

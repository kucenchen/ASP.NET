using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dos.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayProject.Common;
using PayProject.DTO;
using PayProject.Entity;
using PayProject.Extensions;
using PayProject.Logic;

namespace PayProject.WebAdmin.Controllers
{
    [Produces("application/json")]
    [Route("payorder")]
    [Authorize]
    public class PayOrderController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            PayOrder model = PayOrderBll._.GetModelAsync(d => d.Id == id).Result.data;
            return View(model);
        }

        [HttpGet("/api/payorder/getpages")]
        public async Task<JsonResult> GetPages(PageParm parm)
        {
            var where = new Where<PayOrder>();
            where.And(d => 1 == 1);
            string order_id = Request.Query["order_id"].FirstOrDefault();
            string plat_order_id = Request.Query["plat_order_id"].FirstOrDefault();
            string mch_id = Request.Query["mch_id"].FirstOrDefault();
            string status = Request.Query["status"].FirstOrDefault();
            string notify_status = Request.Query["notify_status"].FirstOrDefault();
            string create_time = Request.Query["create_time"].FirstOrDefault();
            string field = Request.Query["field"].FirstOrDefault();
            string order = Request.Query["order"].FirstOrDefault();

            if (!string.IsNullOrEmpty(order_id))
            {
                where.And(d => d.Order_id == order_id.SqlFilters());
            }
            if (!string.IsNullOrEmpty(plat_order_id))
            {
                where.And(d => d.Plat_order_id == plat_order_id.SqlFilters());
            }
            if (!string.IsNullOrEmpty(status))
            {
                where.And(d => d.Status == Convert.ToInt32(status));
            }
            if (!string.IsNullOrEmpty(mch_id))
            {
                where.And(d => d.Mch_id == Convert.ToInt32(mch_id));
            }
            if (!string.IsNullOrEmpty(notify_status))
            {
                where.And(d => d.Notify_status == Convert.ToInt32(notify_status));
            }
            if (!string.IsNullOrEmpty(create_time))
            {
                string[] date = create_time.Split("-");
                int dtStart = MyParse.ParseTime(date[0]).ToTimeStamp();
                int dtEnd = MyParse.ParseTime(date[1]).ToTimeStamp();
                where.And(d => d.Create_time >= dtStart && d.Create_time <= dtEnd);
            }
            parm.whereClip = where;

            OrderByClip orderClip = new OrderByClip("id", OrderByOperater.DESC);
            if (!string.IsNullOrEmpty(field))
            {
                if (order.ToLower() == "asc")
                {
                    orderClip = new OrderByClip(field.SqlFilters(), OrderByOperater.ASC);
                }
                else
                {
                    orderClip = new OrderByClip(field.SqlFilters(), OrderByOperater.DESC);
                }
            }
            parm.orderByClip = orderClip;

            var res = await PayOrderBll._.GetPagesAsync(parm);
            return Json(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }

        [HttpPost("/api/payorder/sendnotify")]
        public async Task<ApiResult<string>> SendNotify(PayOrder parm)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Status };
            res.message = PayOrderBll._.SendNotify(parm.Order_id.SqlFilters(), false, false).Result;
            return await Task.Run(() => res);
        }

        [HttpPost("/api/payorder/replaynotify")]
        public async Task<ApiResult<string>> ReplayNotify(string parm)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Status };
            var list = Utils.StrToListString(parm);
            foreach (var item in list)
            {
                PayOrderBll._.SendNotify(item.SqlFilters(), false, true);
            }
            return await Task.Run(() => res);
        }

        [HttpPost("/api/payorder/query")]
        public async Task<ApiResult<string>> Query(PayOrder parm)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Status };
            res.message = PayOrderBll._.Query(WebConfig.MchId, parm.Order_id).Result.ReturnMsg;
            if (res.message == "ok")
            {
                PayOrderBll._.SendNotify(parm.Order_id.SqlFilters());
            }
            return await Task.Run(() => res);
        }

        [HttpPost("/api/payorder/batchquery")]
        public async Task<ApiResult<string>> BatchQuery(string parm)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Status };
            var list = Utils.StrToListString(parm);
            foreach (var item in list)
            {
                PayOrderBll._.Query(WebConfig.MchId, item.SqlFilters());
            }
            return await Task.Run(() => res);
        }
    }
}
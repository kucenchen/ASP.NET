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
using PayProject.Logic;

namespace PayProject.WebAdmin.Controllers
{
    [Produces("application/json")]
    [Route("paymch")]
    [Authorize]
    public class PayMchController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            PayMch model = PayMchBll._.GetModelAsync(d => d.Id == id).Result.data;
            return View(model);
        }

        [HttpGet("/api/paymch/getpages")]
        public async Task<JsonResult> GetPages(PageParm parm)
        {
            var where = new Where<PayMch>();
            where.And(d => 1 == 1);
            string mch_id = Request.Query["mch_id"].FirstOrDefault();
            string mch_name = Request.Query["mch_name"].FirstOrDefault();
            string plat_id = Request.Query["plat_id"].FirstOrDefault();
            string field = Request.Query["field"].FirstOrDefault();
            string order = Request.Query["order"].FirstOrDefault();
            if (!string.IsNullOrEmpty(mch_id))
            {
                where.And(d => d.Mch_id == mch_id);
            }
            if (!string.IsNullOrEmpty(mch_name))
            {
                where.And(d => d.Mch_name.Like(mch_name.SqlFilters()));
            }
            if (!string.IsNullOrEmpty(plat_id) && plat_id != "0")
            {
                where.And(d => d.Plat_id == Convert.ToInt32(plat_id));
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

            var res = await PayMchBll._.GetPagesAsync(parm);
            return Json(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }

        [HttpPost("/api/paymch/add")]
        public async Task<ApiResult<string>> Add(PayMch parm)
        {
            var queryModel = PayMchBll._.GetModelAsync(d => (d.Plat_id == parm.Plat_id && d.Mch_id == parm.Mch_id.SqlFilters()) || (d.Plat_id == parm.Plat_id && d.Mch_name == parm.Mch_name.SqlFilters())).Result.data;
            if (!string.IsNullOrEmpty(queryModel.Mch_id) || !string.IsNullOrEmpty(queryModel.Mch_name))
            {
                if (queryModel.Mch_id == parm.Mch_id)
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在同渠道商户号'{0}'", parm.Mch_id) };
                }
                else
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在同渠道商户名称'{0}'", parm.Mch_name) };
                }
            }
            Dos.Common.CacheHelper.Remove("pay_mch_list");
            int curTimeStamp = DateTime.Now.ToTimeStamp();
            parm.Mch_key2 = parm.Mch_key2 ?? "";
            parm.Update_time = curTimeStamp;
            parm.Create_time = curTimeStamp;
            return await PayMchBll._.AddAsync(parm);
        }

        [HttpPost("/api/paymch/delete")]
        public async Task<ApiResult<string>> DeletePayMchInfo(string parm)
        {
            Dos.Common.CacheHelper.Remove("pay_mch_list");
            var list = Utils.StrToListInt(parm);
            return await PayMchBll._.DeleteAsync(d => d.Id.In(list));
        }

        [HttpPost("/api/paymch/edit")]
        public async Task<ApiResult<string>> ModifyPayMch(PayMch parm)
        {
            var queryModel = PayMchBll._.GetModelAsync(d => d.Id != parm.Id && ((d.Plat_id == parm.Plat_id && d.Mch_id == parm.Mch_id.SqlFilters()) || (d.Plat_id == parm.Plat_id && d.Mch_name == parm.Mch_name.SqlFilters()))).Result.data;
            if (!string.IsNullOrEmpty(queryModel.Mch_id) || !string.IsNullOrEmpty(queryModel.Mch_name))
            {
                if (queryModel.Mch_id == parm.Mch_id)
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在同渠道商户号'{0}'", parm.Mch_id) };
                }
                else
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在同渠道商户名称'{0}'", parm.Mch_name) };
                }
            }
            Dos.Common.CacheHelper.Remove("pay_mch_list");
            Dictionary<Field, object> model = new Dictionary<Field, object>();
            model.Add(PayMch._.Mch_id, parm.Mch_id.SqlFilters());
            model.Add(PayMch._.Mch_name, parm.Mch_name.SqlFilters() ?? "");
            model.Add(PayMch._.Mch_key, parm.Mch_key.SqlFilters() ?? "");
            model.Add(PayMch._.Mch_key2, parm.Mch_key2.SqlFilters() ?? "");
            model.Add(PayMch._.Nullity, parm.Nullity);
            model.Add(PayMch._.Plat_id, parm.Plat_id);
            model.Add(PayMch._.Rate, parm.Rate);
            model.Add(PayMch._.Open_time, parm.Open_time.SqlFilters() ?? "");
            model.Add(PayMch._.Pay_money_list, parm.Pay_money_list.SqlFilters() ?? "");
            model.Add(PayMch._.Callback_host, parm.Callback_host.SqlFilters() ?? "");
            model.Add(PayMch._.Open_pay_type_list, parm.Open_pay_type_list.SqlFilters() ?? "");
            model.Add(PayMch._.Update_time, DateTime.Now.ToTimeStamp());
            model.Add(PayMch._.Israndom, parm.Israndom);
            return await PayMchBll._.UpdateAsync(model, d => d.Id == parm.Id);
        }
    }
}
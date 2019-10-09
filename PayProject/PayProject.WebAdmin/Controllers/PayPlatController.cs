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
    [Route("payplat")]
    [Authorize]
    public class PayPlatController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            PayPlat model = PayPlatBll._.GetModelAsync(d => d.Plat_id == id).Result.data;
            return View(model);
        }

        [HttpGet("/api/payplat/getpages")]
        public async Task<JsonResult> GetPages(PageParm parm)
        {
            var where = new Where<PayPlat>();
            where.And(d => 1 == 1);
            string platname = Request.Query["platname"].FirstOrDefault();
            string platclass = Request.Query["platclass"].FirstOrDefault();
            string field = Request.Query["field"].FirstOrDefault();
            string order = Request.Query["order"].FirstOrDefault();
            if (!string.IsNullOrEmpty(platname))
            {
                where.And(d => d.Plat_name.Like(platname.SqlFilters()));
            }
            if (!string.IsNullOrEmpty(platclass))
            {
                where.And(d => d.Plat_class.Like(platclass.SqlFilters()));
            }
            parm.whereClip = where;

            OrderByClip orderClip = new OrderByClip("plat_id", OrderByOperater.DESC);
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
            var res = await PayPlatBll._.GetPagesAsync(parm);

            return Json(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }
        [HttpGet("/api/payplat/all")]
        public async Task<ApiResult<List<PayPlat>>> GetAllList()
        {
            return await PayPlatBll._.GetListAsync();
        }

        [HttpPost("/api/payplat/add")]
        public async Task<ApiResult<string>> Add(PayPlat parm)
        {
            var queryModel = PayPlatBll._.GetModelAsync(d =>d.Plat_name == parm.Plat_name.SqlFilters() || d.Plat_class == parm.Plat_class.SqlFilters()).Result.data;
            if (!string.IsNullOrEmpty(queryModel.Plat_name) || !string.IsNullOrEmpty(queryModel.Plat_class))
            {
                if (queryModel.Plat_name == parm.Plat_name)
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在渠道名称'{0}'", parm.Plat_name) };
                }
                else
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在渠道类名'{0}'", parm.Plat_class) };
                }
            }
            parm.Plat_name = parm.Plat_name ?? "";
            parm.Plat_class = parm.Plat_class ?? "";
            parm.Req_gateway = parm.Req_gateway ?? "";
            parm.Pay_gateway = parm.Pay_gateway ?? "";
            parm.Pay_type_list = parm.Pay_type_list ?? "";
            return await PayPlatBll._.AddAsync(parm);
        }

        [HttpPost("/api/payplat/delete")]
        public async Task<ApiResult<string>> DeletePayMchInfo(string parm)
        {
            var list = Utils.StrToListInt(parm);
            return await PayPlatBll._.DeleteAsync(d => d.Plat_id.In(list));
        }

        [HttpPost("/api/payplat/edit")]
        public async Task<ApiResult<string>> ModifyPayMch(PayPlat parm)
        {
            var queryModel = PayPlatBll._.GetModelAsync(d => d.Plat_id != parm.Plat_id && (d.Plat_name == parm.Plat_name.SqlFilters() || d.Plat_class == parm.Plat_class.SqlFilters())).Result.data;
            if (!string.IsNullOrEmpty(queryModel.Plat_name) || !string.IsNullOrEmpty(queryModel.Plat_class))
            {
                if (queryModel.Plat_name == parm.Plat_name)
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在渠道名称'{0}'", parm.Plat_name) };
                }
                else
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在渠道类名'{0}'", parm.Plat_class) };
                }
            }

            Dictionary<Field, object> model = new Dictionary<Field, object>();
            model.Add(PayPlat._.Plat_name, parm.Plat_name.SqlFilters() ?? "");
            model.Add(PayPlat._.Plat_class, parm.Plat_class.SqlFilters() ?? "");
            model.Add(PayPlat._.Req_gateway, parm.Req_gateway.SqlFilters() ?? "");
            model.Add(PayPlat._.Pay_gateway, parm.Pay_gateway.SqlFilters() ?? "");
            model.Add(PayPlat._.Pay_type_list, parm.Pay_type_list.SqlFilters() ?? "");
            return await PayPlatBll._.UpdateAsync(model, d => d.Plat_id == parm.Plat_id);
        }
    }
}
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
    [Route("settleplat")]
    [Authorize]
    public class SettlePlatController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            SettlePlat model = SettlePlatBll._.GetModelAsync(d => d.Plat_id == id).Result.data;
            return View(model);
        }

        [HttpGet("/api/settleplat/getpages")]
        public async Task<JsonResult> GetPages(PageParm parm)
        {
            var where = new Where<SettlePlat>();
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

            var res = await SettlePlatBll._.GetPagesAsync(parm);
            return Json(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }
        [HttpGet("/api/settleplat/all")]
        public async Task<ApiResult<List<SettlePlat>>> GetAllList()
        {
            return await SettlePlatBll._.GetListAsync();
        }

        [HttpPost("/api/settleplat/add")]
        public async Task<ApiResult<string>> Add(SettlePlat parm)
        {
            parm.Plat_name = parm.Plat_name ?? "";
            parm.Plat_class = parm.Plat_class ?? "";
            parm.Req_gateway = parm.Req_gateway ?? "";
            parm.Pay_gateway = parm.Pay_gateway ?? "";
            return await SettlePlatBll._.AddAsync(parm);
        }

        [HttpPost("/api/settleplat/delete")]
        public async Task<ApiResult<string>> DeletePayMchInfo(string parm)
        {
            var list = Utils.StrToListInt(parm);
            return await SettlePlatBll._.DeleteAsync(d => d.Plat_id.In(list));
        }

        [HttpPost("/api/settleplat/edit")]
        public async Task<ApiResult<string>> ModifyPayMch(SettlePlat parm)
        {
            Dictionary<Field, object> model = new Dictionary<Field, object>();
            model.Add(SettlePlat._.Plat_name, parm.Plat_name.SqlFilters() ?? "");
            model.Add(SettlePlat._.Plat_class, parm.Plat_class.SqlFilters() ?? "");
            model.Add(SettlePlat._.Req_gateway, parm.Req_gateway.SqlFilters() ?? "");
            model.Add(SettlePlat._.Pay_gateway, parm.Pay_gateway.SqlFilters() ?? "");
            model.Add(SettlePlat._.Banklist, parm.Banklist.SqlFilters() ?? "");
            model.Add(SettlePlat._.Min_money, parm.Min_money);
            model.Add(SettlePlat._.Max_money, parm.Max_money);
            return await SettlePlatBll._.UpdateAsync(model, d => d.Plat_id == parm.Plat_id);
        }
    }
}
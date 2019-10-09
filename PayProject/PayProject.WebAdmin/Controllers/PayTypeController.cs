using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dos.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayProject.Common;
using PayProject.Entity;
using PayProject.Logic;

namespace PayProject.WebAdmin.Controllers
{
    [Produces("application/json")]
    [Route("paytype")]
    [Authorize]
    public class PayTypeController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            PayType model = PayTypeBll._.GetModelAsync(d => d.Type_id == id).Result.data;
            return View(model);
        }

        [HttpGet("/api/paytype/getapipages")]
        public async Task<JsonResult> GetAllPayList()
        {
            var res = await PayTypeBll._.GetListAsync();
            return Json(new { code = 0, msg = "success", data = res.data });
        }
        [HttpPost("/api/paytype/add")]
        public async Task<ApiResult<string>> Add(PayType parm)
        {
            int curTimeStamp = DateTime.Now.ToTimeStamp();
            parm.Type_name = parm.Type_name ?? "";
            parm.Type_alias = parm.Type_alias ?? "";
            parm.Type_note = parm.Type_note ?? "";
            parm.Update_time = curTimeStamp;
            parm.Create_time = curTimeStamp;
            var res = await PayTypeBll._.IsExist(d => d.Type_alias == parm.Type_alias);
            if (res.statusCode == 200)
            {
                if (res.success)
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已经存在{0}的支付类型", parm.Type_alias) };
                }
                else
                {
                    return await PayTypeBll._.AddAsync(parm);
                }
            }
            else
            {
                return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = "唯一性检测出错" };
            }
        }

        [HttpPost("/api/paytype/delete")]
        public async Task<ApiResult<string>> DeletePayMchInfo(string parm)
        {
            var list = Utils.StrToListInt(parm);
            return await PayTypeBll._.DeleteAsync(d => d.Type_id.In(list));
        }

        [HttpPost("/api/paytype/edit")]
        public async Task<ApiResult<string>> ModifyPayMch(PayType parm)
        {
            var res = await PayTypeBll._.IsExist(d => d.Type_id != parm.Type_id && d.Type_alias == parm.Type_alias);
            if (res.statusCode == 200)
            {
                if (res.success)
                {
                    return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已经存在{0}的支付类型", parm.Type_alias) };
                }
            }
            else
            {
                return new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = "唯一性检测出错" };
            }
            Dictionary<Field, object> model = new Dictionary<Field, object>();
            model.Add(PayType._.Type_name, parm.Type_name.SqlFilters() ?? "");
            model.Add(PayType._.Type_alias, parm.Type_alias.SqlFilters() ?? "");
            model.Add(PayType._.Type_note, parm.Type_note.SqlFilters() ?? "");
            model.Add(PayType._.Update_time, DateTime.Now.ToTimeStamp());
            return await PayTypeBll._.UpdateAsync(model, d => d.Type_id == parm.Type_id);
        }
    }
}
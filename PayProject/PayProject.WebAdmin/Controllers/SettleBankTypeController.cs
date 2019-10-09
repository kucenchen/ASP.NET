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
    [Route("settlebanktype")]
    [Authorize]
    public class SettleBankTypeController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            SettleBankType model = SettleBankTypeBll._.GetModelAsync(d => d.Type_id == id).Result.data;
            return View(model);
        }

        [HttpGet("/api/settlebanktype/getapipages")]
        public async Task<JsonResult> GetAllPayList()
        {
            var res = await SettleBankTypeBll._.GetListAsync();
            return Json(new { code = 0, msg = "success", data = res.data });
        }
        [HttpPost("/api/settlebanktype/add")]
        public async Task<ApiResult<string>> Add(SettleBankType parm)
        {
            SettleBankType model = SettleBankTypeBll._.GetModelAsync(d => d.Type_alias == parm.Type_alias.SqlFilters() || d.Type_name == parm.Type_name.SqlFilters()).Result.data;
            if (!string.IsNullOrEmpty(model.Type_alias) || !string.IsNullOrEmpty(model.Type_name))
            {
                if (model.Type_alias == parm.Type_alias)
                {
                    var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在银行缩写'{0}'", parm.Type_alias) };
                    return await Task.Run(() => res);
                }
                else
                {
                    var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在银行名称'{0}'", parm.Type_name) };
                    return await Task.Run(() => res);
                }
               
            }
            int curTimeStamp = DateTime.Now.ToTimeStamp();
            parm.Type_name = parm.Type_name ?? "";
            parm.Type_alias = parm.Type_alias ?? "";
            parm.Type_note = parm.Type_note ?? "";
            parm.Sort_id = parm.Sort_id;
            parm.Update_time = curTimeStamp;
            parm.Create_time = curTimeStamp;
            return await SettleBankTypeBll._.AddAsync(parm);
        }

        [HttpPost("/api/settlebanktype/delete")]
        public async Task<ApiResult<string>> DeletePayMchInfo(string parm)
        {
            var list = Utils.StrToListInt(parm);
            return await SettleBankTypeBll._.DeleteAsync(d => d.Type_id.In(list));
        }

        [HttpPost("/api/settlebanktype/edit")]
        public async Task<ApiResult<string>> ModifyPayMch(SettleBankType parm)
        {
            SettleBankType queryModel = SettleBankTypeBll._.GetModelAsync(d => parm.Type_id != parm.Type_id && (d.Type_alias == parm.Type_alias.SqlFilters() || d.Type_name == parm.Type_name.SqlFilters())).Result.data;
            if (!string.IsNullOrEmpty(queryModel.Type_alias) || !string.IsNullOrEmpty(queryModel.Type_name))
            {
                if (queryModel.Type_alias == parm.Type_alias)
                {
                    var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在银行缩写'{0}'", parm.Type_alias) };
                    return await Task.Run(() => res);
                }
                else
                {
                    var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error, message = string.Format("已存在银行名称'{0}'", parm.Type_name) };
                    return await Task.Run(() => res);
                }
            }

            Dictionary<Field, object> model = new Dictionary<Field, object>();
            model.Add(SettleBankType._.Type_name, parm.Type_name.SqlFilters() ?? "");
            model.Add(SettleBankType._.Type_alias, parm.Type_alias.SqlFilters() ?? "");
            model.Add(SettleBankType._.Type_note, parm.Type_note.SqlFilters() ?? "");
            model.Add(SettleBankType._.Update_time, DateTime.Now.ToTimeStamp());
            model.Add(SettleBankType._.Sort_id, parm.Sort_id);
            return await SettleBankTypeBll._.UpdateAsync(model, d => d.Type_id == parm.Type_id);
        }
    }
}
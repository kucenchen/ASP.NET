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

namespace PayProject.Controllers
{
    [Produces("application/json")]
    [Route("paytest")]
    [Authorize]
    public class PaytestController : Controller
    {

        [HttpGet("edit")]
        public IActionResult Edit()
        {
            // IEnumerable<PayMch> models = PayMchBll._.GetListAsync().Result.data;
            PayMch model = PayMchBll._.GetModelAsync(d => d.Id > 0).Result.data;
            return View(model);
        }

        [HttpPost("/api/paytest/pay")]
        public async Task<ApiResult<string>> pay(string Platid,string Money,string Userid,string Paytype)
        { 
            
            var mchModel = PayMchBll._.GetModelAsync(d => d.Plat_id == Convert.ToInt32(Platid)).Result.data;
            // ,string body,int paytype, string amount,string attach,string ip,string callbackurl,string notifyurl,string sign
            string mchid = mchModel.Mch_id;
            string orderid = "Paytest" + DateTime.Now.ToString("yyyyMMddHHmmss");


            //Dictionary<Field, object> model = new Dictionary<Field, object>();
            //model.Add(PayMch._.Mch_id, parm.Mch_id.SqlFilters());
            //model.Add(PayMch._.Mch_name, parm.Mch_name.SqlFilters() ?? "");
            //model.Add(PayMch._.Mch_key, parm.Mch_key.SqlFilters() ?? "");
            //model.Add(PayMch._.Mch_key2, parm.Mch_key2.SqlFilters() ?? "");
            //model.Add(PayMch._.Nullity, parm.Nullity);
            //model.Add(PayMch._.Plat_id, parm.Plat_id);
            //model.Add(PayMch._.Rate, parm.Rate);
            //model.Add(PayMch._.Open_time, parm.Open_time.SqlFilters() ?? "");
            //model.Add(PayMch._.Pay_money_list, parm.Pay_money_list.SqlFilters() ?? "");
            //model.Add(PayMch._.Callback_host, parm.Callback_host.SqlFilters() ?? "");
            //model.Add(PayMch._.Open_pay_type_list, parm.Open_pay_type_list.SqlFilters() ?? "");
            //model.Add(PayMch._.Update_time, DateTime.Now.ToTimeStamp());
            //model.Add(PayMch._.Israndom, parm.Israndom);
            return await PayMchBll._.UpdateAsync(model, d => d.Id == parm.Id);
        }
    }
}
}
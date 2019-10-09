using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayProject.Entity;
using PayProject.Logic;
using PayProject.Logic.Pay;

namespace PayProject.WebAdmin.Controllers
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
        public async Task<UnifiedOrderReturnModel> PayUnifiedorder(string Platid, string Money, string Userid, string Paytype)
        {  
            //Response.Redirect("//www.baidu.com",true);
            var mchModel = PayMchBll._.GetModelAsync(d => d.Plat_id == Convert.ToInt32(Platid)).Result.data;
            var platModel = PayPlatBll._.GetModelAsync(p => p.Plat_id == Convert.ToInt32(Platid)).Result.data;
            string mchid = mchModel.Mch_id;
            //string orderid = "Paytest" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string orderid = DateTime.Now.ToString("yyyyMMddHHmmss");
            UnifiedOrderReturnModel r = new UnifiedOrderReturnModel();
            r = await PayOrderBll._.Unifiedorder(mchid, orderid, "body", Convert.ToInt32(Paytype), Money, "attach", "ip", "callbackurl", "callbackurl");
            //HttpContext.Response.Redirect(r.Content,true);
            return r;

        }
    }
}

using Dos.ORM;
using PayProject.Common;
using PayProject.Core;
using PayProject.DTO;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Logic
{
    public class PayPlatBll : LogicBase<PayPlat>
    {
        private static PayPlatBll bll;
        public static PayPlatBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new PayPlatBll();
                }
                return bll;
            }
        }
        public async Task<ApiResult<Page<PayPlat>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<PayPlat>>();
            try
            {
                var query = DbContext._.Db.From<PayPlat>()
                    .Where((Where<PayPlat>)parm.whereClip)
                    .OrderBy((OrderByClip)parm.orderByClip)
                    .ToPageAsync<PayPlat>(parm.page, parm.limit);
                res.success = true;
                res.message = "获取成功！";
                res.data = await query;
            }
            catch (Exception ex)
            {
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
                res.statusCode = (int)ApiEnum.Error;
            }
            return await Task.Run(() => res);
        }
    }
}

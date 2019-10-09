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
    public class SettleMchBll : LogicBase<SettleMch>
    {
        private static SettleMchBll bll;
        public static SettleMchBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new SettleMchBll();
                }
                return bll;
            }
        }

        public async Task<ApiResult<Page<SettleMch>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<SettleMch>>();
            try
            {
                var query = DbContext._.Db.From<SettleMch>()
                    .Where((Where<SettleMch>)parm.whereClip)
                    .OrderBy((OrderByClip)parm.orderByClip)
                    .ToPageAsync<SettleMch>(parm.page, parm.limit);
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

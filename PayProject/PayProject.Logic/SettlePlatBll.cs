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
    public class SettlePlatBll : LogicBase<SettlePlat>
    {
        private static SettlePlatBll bll;
        public static SettlePlatBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new SettlePlatBll();
                }
                return bll;
            }
        }
        public async Task<ApiResult<Page<SettlePlat>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<SettlePlat>>();
            try
            {
                var query = DbContext._.Db.From<SettlePlat>()
                    .Where((Where<SettlePlat>)parm.whereClip)
                    .OrderBy((OrderByClip)parm.orderByClip)
                    .ToPageAsync<SettlePlat>(parm.page, parm.limit);
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
using PayProject.Common;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayProject.DTO;
using PayProject.Core;
using Dos.ORM;

namespace PayProject.Logic
{
    public class PayMchBll : LogicBase<PayMch>
    {
        private static PayMchBll bll;
        public static PayMchBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new PayMchBll();
                }
                return bll;
            }
        }
        public async Task<ApiResult<Page<PayMch>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<PayMch>>();
            try
            {
                var query = DbContext._.Db.From<PayMch>()
                    .Where((Where<PayMch>)parm.whereClip)
                    .OrderBy((OrderByClip)parm.orderByClip)
                    .ToPageAsync<PayMch>(parm.page, parm.limit);
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
        /// <summary>
        /// 获取商户列表
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult<List<PayMch>>> GetPayMchListAsync()
        {
            var res = new ApiResult<List<PayMch>>();
            try
            {
                var query = DbContext._.Db.From<PayMch>().Select().ToList<PayMch>();
                res.success = true;
                res.message = "获取成功！";
                res.data = query;
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

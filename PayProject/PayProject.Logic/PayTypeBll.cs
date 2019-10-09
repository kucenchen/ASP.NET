using PayProject.Common;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayProject.Core;

namespace PayProject.Logic
{
    public class PayTypeBll : LogicBase<PayType>
    {
        private static PayTypeBll bll;
        public static PayTypeBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new PayTypeBll();
                }
                return bll;
            }
        }
        public new async Task<ApiResult<List<PayType>>> GetListAsync()
        {
            var res = new ApiResult<List<PayType>>();
            try
            {
                var query = DbContext._.Db.From<PayType>().Select().ToList();
                //var query = Db.Queryable<T>()
                //        .Where(where)
                //        .OrderByIF((int)orderEnum == 1, order, SqlSugar.OrderByType.Asc)
                //        .OrderByIF((int)orderEnum == 2, order, SqlSugar.OrderByType.Desc)
                //        .ToList();
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

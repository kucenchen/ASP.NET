using PayProject.Common;
using PayProject.Core;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Logic
{
    public class SettleBankTypeBll : LogicBase<SettleBankType>
    {
        private static SettleBankTypeBll bll;
        public static SettleBankTypeBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new SettleBankTypeBll();
                }
                return bll;
            }
        }
        public new async Task<ApiResult<List<SettleBankType>>> GetListAsync()
        {
            var res = new ApiResult<List<SettleBankType>>();
            try
            {
                var query = DbContext._.Db.From<SettleBankType>().Select().ToList();
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

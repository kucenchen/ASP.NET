using Dos.ORM;
using PayProject.Common;
using PayProject.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Logic
{
    public class LogicBase<T> where T : Dos.ORM.Entity, new()
    {
        public async Task<ApiResult<T>> IsExist(Expression<Func<T, bool>> lambdaWhere)
        {
            var result = DbContext._.Db.From<T>().Where(lambdaWhere).First<T>();
            var res = new ApiResult<T>
            {
                statusCode = 200,
                success = (result != null)
            };
            return await Task.Run(() => res);
        }
        public async Task<ApiResult<T>> GetModelAsync(Expression<Func<T, bool>> lambdaWhere)
        {
            var model = DbContext._.Db.From<T>().Where(lambdaWhere).ToFirstDefault();
            var res = new ApiResult<T>
            {
                statusCode = 200,
                data = model
            };
            return await Task.Run(() => res);
        }
        public async Task<ApiResult<List<T>>> GetListAsync()
        {
            var res = new ApiResult<List<T>>();
            try
            {
                var query = DbContext._.Db.From<T>().Select().ToList<T>();
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

        public async Task<ApiResult<string>> AddAsync(T parm)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error };
            try
            {
                var dbres = DbContext._.Db.Insert<T>(parm);
                if (0 >= dbres)
                {
                    res.message = "插入数据失败~";
                }
                else
                {
                    res.statusCode = (int)ApiEnum.Status;
                }
            }
            catch (Exception ex)
            {
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
            }
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<string>> DeleteAsync(Expression<Func<T, bool>> lambdaWhere)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error };
            try
            {
                var dbres = DbContext._.Db.Delete<T>(lambdaWhere); 
                if (0 >= dbres)
                {
                    res.message = "删除数据失败~";
                }
                else
                {
                    res.statusCode = (int)ApiEnum.Status;
                }
            }
            catch (Exception ex)
            {
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
            }
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<string>> UpdateAsync(Dictionary<Field, object> dic, Expression<Func<T, bool>> lambdaWhere)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error };
            try
            {
                var dbres = DbContext._.Db.Update<T>(dic, lambdaWhere);
                if (0 >= dbres)
                {
                    res.message = "修改数据失败~";
                }
                else
                {
                    res.statusCode = (int)ApiEnum.Status;
                }
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
            }
            return await Task.Run(() => res);
        }
    }
}

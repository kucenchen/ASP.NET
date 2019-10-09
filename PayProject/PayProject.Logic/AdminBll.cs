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
    public class AdminBll
    {
        private static AdminBll bll;
        public static AdminBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new AdminBll();
                }
                return bll;
            }
        }
        /// <summary>
        /// 用户登录实现
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public async Task<ApiResult<SysAdmin>> LoginAsync(SysAdminLogin parm)
        {
            var res = new ApiResult<SysAdmin>();
            try
            {
                parm.password = DES3Encrypt.EncryptString(parm.password);

                var model = DbContext._.Db.From<SysAdmin>().Where(d => d.LoginName == parm.loginname).ToFirstDefault();
                if (model != null)
                {
                    if (!model.Status)
                    {
                        res.success = false;
                        res.statusCode = (int)ApiEnum.Error;
                        res.message = "账号冻结~";
                    }
                    else
                    {
                        if (model.LoginPwd.Equals(parm.password))
                        {
                            //修改登录时间
                            model.LoginDate = DateTime.Now;
                            model.UpLoginDate = model.LoginDate;
                            //SysAdminDb.Update(model);
                            DbContext._.Db.Update<SysAdmin>(model, d => d.Guid == model.Guid);

                            #region 保存操作日志
                            //var logModel = new SysLog()
                            //{
                            //    Guid = Guid.NewGuid().ToString(),
                            //    LoginName = model.LoginName,
                            //    DepartName = model.DepartmentName,
                            //    OptionTable = "SysAdmin",
                            //    Summary = "登录操作",
                            //    IP = Utils.GetIp(),
                            //    LogType = (int)LogEnum.Login,
                            //    Urls = Utils.GetUrl(),
                            //    AddTime = DateTime.Now
                            //};
                            //SysLogDb.Insert(logModel);
                            #endregion

                            res.success = true;
                            res.message = "获取成功！";
                            res.data = model;
                        }
                        else
                        {
                            res.success = false;
                            res.statusCode = (int)ApiEnum.Error;
                            res.message = "密码错误~";
                        }
                    }
                }
                else
                {
                    res.success = false;
                    res.statusCode = (int)ApiEnum.Error;
                    res.message = "账号错误~";
                }
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

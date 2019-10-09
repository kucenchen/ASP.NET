using PayProject.Common;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayProject.Core;
using PayProject.DTO;
using System.Linq;
using Dos.ORM;

namespace PayProject.Logic
{
    public class SysMenuBll
    {
        private static SysMenuBll bll;
        public static SysMenuBll _
        {
            get
            {
                if (bll == null)
                {
                    bll = new SysMenuBll();
                }
                return bll;
            }
        }
        public async Task<ApiResult<List<SysMenu>>> GetAuthorizeAsync()
        {
            var res = new ApiResult<List<SysMenu>>() { statusCode = (int)ApiEnum.Error };
            try
            {
                //根据权限菜单查询列表
                res.data = DbContext._.Db.From<SysMenu>().Where(d => d.Status == true).ToList();
                res.statusCode = (int)ApiEnum.Status;
            }
            catch (Exception ex)
            {
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
            }
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<List<SysMenuTree>>> GetListTreeAsync(string roleGuid)
        {

            var list = DbContext._.Db.From<SysMenu>().ToList();
            var treeList = new List<SysMenuTree>();
            foreach (var item in list.Where(m => m.Layer == 1).OrderBy(m => m.Sort))
            {
                //获得子级
                var children = RecursionOrganize(list, new List<SysMenuTree>(), item.Guid);
                treeList.Add(new SysMenuTree()
                {
                    guid = item.Guid,
                    name = item.Name,
                    open = children.Count > 0,
                    isChecked = true,
                    children = children.Count == 0 ? null : children
                });
            }

            var res = new ApiResult<List<SysMenuTree>>
            {
                statusCode = 200,
                data = treeList
            };
            return await Task.Run(() => res);
        }
        List<SysMenuTree> RecursionOrganize(List<SysMenu> sourceList, List<SysMenuTree> list, string guid)
        {
            foreach (var row in sourceList.Where(m => m.ParentGuid == guid).OrderBy(m => m.Sort))
            {
                var res = RecursionOrganize(sourceList, new List<SysMenuTree>(), row.Guid);
                list.Add(new SysMenuTree()
                {
                    guid = row.Guid,
                    name = row.Name,
                    isChecked = true,
                    open = res.Count > 0,
                    children = res.Count > 0 ? res : null
                });
            }
            return list;
        }
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResult<Page<SysMenu>>> GetPagesAsync(PageParm parm)
        {
            var res = new ApiResult<Page<SysMenu>>();
            try
            {
                var where = new Where<SysMenu>();
                if (!string.IsNullOrEmpty(parm.key))
                {
                    where.And(d => d.ParentGuidList.Contains(parm.key));
                }
                var query = DbContext._.Db.From<SysMenu>()
                    .Where(where)
                    .ToPageAsync(parm.page, parm.limit);

                res.success = true;
                res.message = "获取成功！";
                var result = new List<SysMenu>();
                ChildModule(query.Result.Items, result, null);
                query.Result.Items = result;
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
        /// 递归模块列表
        /// </summary>
        private void ChildModule(List<SysMenu> list, List<SysMenu> newlist, string parentId)
        {
            var result = list.Where(p => p.ParentGuid == parentId).OrderBy(p => p.Layer).ThenBy(p => p.Sort).ToList();
            if (!result.Any()) return;
            for (int i = 0; i < result.Count(); i++)
            {
                newlist.Add(result[i]);
                ChildModule(list, newlist, result[i].Guid);
            }
        }

        /// <summary>
        /// 删除一条或多条数据
        /// </summary>
        public async Task<ApiResult<string>> DeleteAsync(List<string> liGuid)
        {
            var res = new ApiResult<string>() { statusCode = (int)ApiEnum.Error };
            try
            {
                var dbres = DbContext._.Db.Delete<SysMenu>(d => d.Guid.In(liGuid));
                if (0 < dbres)
                {
                    res.statusCode = (int)ApiEnum.Status;
                }
                else
                {
                    res.message = "删除数据失败~";
                }
            }
            catch (Exception ex)
            {
                res.message = ApiEnum.Error.GetEnumText() + ex.Message;
            }
            return await Task.Run(() => res);
        }

        public new async Task<ApiResult<string>> AddAsync(SysMenu parm)
        {
            parm.Guid = Guid.NewGuid().ToString();
            parm.EditTime = DateTime.Now;
            parm.AddTIme = DateTime.Now;
            DbContext._.Db.Insert<SysMenu>(parm);
            if (!string.IsNullOrEmpty(parm.ParentGuid))
            {
                // 说明有父级  根据父级，查询对应的模型
                var model = DbContext._.Db.From<SysMenu>().Where(d => d.Guid == parm.ParentGuid).ToFirstDefault();//SysMenuDb.GetById(parm.ParentGuid);
                parm.ParentGuidList = model.ParentGuidList + parm.Guid + ",";
                parm.Layer = model.Layer + 1;
            }
            else
            {
                parm.ParentGuidList = "," + parm.Guid + ",";
                parm.Layer = 1;
            }
            //更新  新的对象
            DbContext._.Db.Update<SysMenu>(parm, d => d.Guid == parm.Guid);
            var res = new ApiResult<string>
            {
                statusCode = 200,
                data = "1"
            };
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<string>> ModifyAsync(SysMenu parm)
        {
            parm.EditTime = DateTime.Now;
            if (!string.IsNullOrEmpty(parm.ParentGuid))
            {
                // 说明有父级  根据父级，查询对应的模型
                var model = DbContext._.Db.From<SysMenu>().Where(d => d.Guid == parm.ParentGuid).ToFirstDefault();//SysMenuDb.GetById(parm.ParentGuid);
                parm.ParentGuidList = model.ParentGuidList + parm.Guid + ",";
                parm.Layer = model.Layer + 1;
            }
            else
            {
                parm.ParentGuidList = "," + parm.Guid + ",";
            }
            var res = new ApiResult<string>
            {
                statusCode = 200,
                data = DbContext._.Db.Update<SysMenu>(parm, d => d.Guid == parm.Guid) > 0 ? "1" : "0"//SysMenuDb.Update(parm) ? "1" : "0"
            };
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<SysMenu>> GetByGuidAsync(string parm)
        {
            var model = DbContext._.Db.From<SysMenu>().Where(d => d.Guid == parm).ToFirstDefault(); //SysMenuDb.GetSingle(m => m.Guid == parm);
            var res = new ApiResult<SysMenu>
            {
                statusCode = 200
            };
            var pmdel = DbContext._.Db.From<SysMenu>().OrderBy(SysMenu._.Sort.Desc).ToFirstDefault(); //Db.Queryable<SysMenu>().OrderBy(m => m.Sort, OrderByType.Desc).First();
            res.data = model ?? new SysMenu() { Sort = pmdel?.Sort + 1 ?? 1, Status = true };
            return await Task.Run(() => res);
        }
    }
}

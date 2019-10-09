using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayProject.Common;
using PayProject.DTO;
using PayProject.Entity;
using PayProject.Logic;

namespace PayProject.WebAdmin.Controllers
{
    [Produces("application/json")]
    [Route("menu")]
    [Authorize]
    public class MenuController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("edit")]
        public IActionResult Edit(string guid)
        {
            var model = SysMenuBll._.GetByGuidAsync(guid).Result.data;
            return View(model);
            //var li = modulesBll.GetAllModules();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<option value=\"0\">一级菜单</option>");
            //string _html = CreateTreeSelect(li, 0, id, 0, sb);
            //ViewBag.TreeSelectHtml = _html;
            //return View();
        }
        /// <summary>
        /// 提供权限查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("/api/menu/authmenu")]
        [HttpGet]
        public async Task<ApiResult<List<SysMenu>>> GetAuthMenu()
        {
            return await SysMenuBll._.GetAuthorizeAsync();
        }

        /// <summary>
        /// 获得组织结构Tree列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/menu/gettree")]
        public List<SysMenuTree> GetListPage(string roleGuid)
        {
            return SysMenuBll._.GetListTreeAsync(roleGuid).Result.data;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("/api/menu/getpages")]
        public async Task<JsonResult> GetPages(PageParm parm)
        {
            var res = await SysMenuBll._.GetPagesAsync(parm);
            if (res.data.Items.Count > 0)
            {
                foreach (var item in res.data.Items)
                {
                    item.Name = Utils.LevelName(item.Name, item.Layer);
                }
            }
            return Json(new { code = 0, msg = "success", count = res.data.TotalItems, data = res.data.Items });
        }

        [HttpPost("/api/menu/add")]
        public async Task<ApiResult<string>> AddMenu(SysMenu parm)
        {
            return await SysMenuBll._.AddAsync(parm);
        }

        [HttpPost("/api/menu/delete")]
        public async Task<ApiResult<string>> DeleteMenu(string parm)
        {
            var list = Utils.StrToListString(parm);
            return await SysMenuBll._.DeleteAsync(list);//_sysMenuService.DeleteAsync(m => list.Contains(m.Guid));
        }

        [HttpPost("/api/menu/edit")]
        public async Task<ApiResult<string>> EditMenu(SysMenu parm)
        {
            return await SysMenuBll._.ModifyAsync(parm);
        }
    }


}
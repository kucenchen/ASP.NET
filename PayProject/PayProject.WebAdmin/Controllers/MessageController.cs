using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayProject.Common;
using PayProject.DTO;

namespace PayProject.WebAdmin.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MessageController : Controller
    {
        [HttpPost("page")]
        public async Task<ApiResult<Page<object>>> GetPages(PageParm parm)
        {
            var res = new ApiResult<Page<object>>();
            var page = new Page<object>();
            var totalItems = 0;
            var totalPages =  0;
            page.CurrentPage = 1;
            page.ItemsPerPage = parm.limit;
            page.TotalItems = totalItems;
            page.TotalPages = totalPages;
            page.Items = null;
            res.success = true;
            res.message = "获取成功！";
            res.data = page;
            return await Task.Run(() => res);
        }
    }
}
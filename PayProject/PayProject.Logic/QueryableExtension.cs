using Dos.ORM;
using PayProject.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Logic
{
    public static class QueryableExtension
    {
        /// <summary>
        /// 读取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        public static async Task<Page<T>> ToPageAsync<T>(this FromSection<T> query,
            int pageIndex,
            int pageSize,
            bool isOrderBy = false) where T : Dos.ORM.Entity
        {
            var page = new Page<T>();
            var totalItems = query.Count();
            var totalPages = totalItems != 0 ? (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1 : 0;
            page.CurrentPage = pageIndex;
            page.ItemsPerPage = pageSize;
            page.TotalItems = totalItems;
            page.TotalPages = totalPages;
            page.Items = totalItems == 0 ? null : query.Page(pageSize, pageIndex).ToList();
            return page;
        }

        ///// <summary>
        ///// 读取列表
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="query"></param>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="isOrderBy"></param>
        ///// <returns></returns>
        //public static Page<T> ToPage<T>(this FromSection<T> query,
        //    int pageIndex,
        //    int pageSize,
        //    bool isOrderBy = false)
        //{
        //    var page = new Page<T>();
        //    var totalItems = query.Count();
        //    page.Items = query.ToPageList(pageIndex, pageSize, ref totalItems);
        //    var totalPages = totalItems != 0 ? (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1 : 0;
        //    page.CurrentPage = pageIndex;
        //    page.ItemsPerPage = pageSize;
        //    page.TotalItems = totalItems;
        //    page.TotalPages = totalPages;
        //    return page;
        //}
    }
}

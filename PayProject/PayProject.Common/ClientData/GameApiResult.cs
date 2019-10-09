using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common
{
    /// <summary>
    /// 游戏客户端调用返回json字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GameApiResult<T> where T : class
    {
        /// <summary>
        /// 状态 大于0成功,小于0失败
        /// </summary>
        public int s { get; set; } = 0;
        /// <summary>
        /// 失败提示信息
        /// </summary>
        public string m { get; set; } = "";
        /// <summary>
        /// 数据集
        /// </summary>
        public T d { get; set; }
    }
    public class GameApiPage<T> 
    {
        public List<T> items { get; set; } = new List<T>();
        public GamePager pager { get; set; } = new GamePager();
    }
    
    public class GamePager
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPage { get; set; }
        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int maxResults { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int currentPage { get; set; }
    }
    

    public enum GameApiStatuEnum
    {
        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Text("请求(或处理)成功")]
        Success = 1,
        /// <summary>
        /// 请求(或处理)失败
        /// </summary>
        [Text("请求(或处理)失败")]
        Fail = -1,
        /// <summary>
        /// 需要短信二次验证
        /// </summary>
        [Text("需要短信验证")]
        Validate = 999
    }
}
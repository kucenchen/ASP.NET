using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayProject.Common
{
    public class QueryHelper
    {
        public static string BuildPageWhere(Dictionary<string,string> dict)
        {
            HttpContextAccessor _context = new HttpContextAccessor();
            string selectUserType = _context.HttpContext.Request.Query["selectUserType"].FirstOrDefault();
            string queryUser = _context.HttpContext.Request.Query["queryUser"].FirstOrDefault();
            string selectIpMachine = _context.HttpContext.Request.Query["selectIpMachine"].FirstOrDefault();
            string queryIpMachine = _context.HttpContext.Request.Query["queryIpMachine"].FirstOrDefault();
            string queryDate = _context.HttpContext.Request.Query["queryDate"].FirstOrDefault();
            string queryLogType = _context.HttpContext.Request.Query["queryLogType"].FirstOrDefault();
            string _where = " 1=1 ";

            if (!string.IsNullOrEmpty(selectUserType) && !string.IsNullOrEmpty(queryUser))
            {
                queryUser = queryUser.Trim();
                switch (selectUserType)
                {
                    case "-1":
                        _where += string.Format(" AND ("+ dict["userid"] + "={0} OR "+ dict["gameid"] + "={0} OR "+ dict["accounts"] + " LIKE '%{1}%' OR "+ dict["nick_name"] + " LIKE '%{1}%')", MyParse.ParseInt(queryUser, -1), queryUser.SqlFilters());
                        break;
                    case "0":
                        _where += string.Format(" AND "+ dict["userid"] + "={0}", MyParse.ParseInt(queryUser, 0));
                        break;
                    case "1":
                        _where += string.Format(" AND " + dict["gameid"] + "={0}", MyParse.ParseInt(queryUser, 0));
                        break;
                    case "2":
                        _where += string.Format(" AND " + dict["accounts"] + " LIKE '%{0}%'", queryUser.SqlFilters());
                        break;
                    case "3":
                        _where += string.Format(" AND " + dict["nick_name"] + " LIKE '%{0}%'", queryUser.SqlFilters());
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(selectIpMachine) && !string.IsNullOrEmpty(queryIpMachine))
            {
                queryIpMachine = queryIpMachine.Trim();
                switch (selectIpMachine)
                {
                    case "-1":
                        _where += string.Format(" AND ("+ dict["ip"] + " like '%{0}%' OR "+ dict["machine"] + " like '%{0}%')", queryIpMachine.SqlFilters());
                        break;
                    case "0":
                        _where += string.Format(" AND ("+ dict["ip"] + "='{0}')", queryIpMachine.SqlFilters());
                        break;
                    case "1":
                        _where += string.Format(" AND ("+ dict["machine"] + "='{0}')", queryIpMachine.SqlFilters());
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(queryDate))
            {
                queryDate = queryDate.Trim();
                string[] date = queryDate.Split("-");
                DateTime dtStart = MyParse.ParseTime(date[0].Trim());
                DateTime dtEnd = MyParse.ParseTime(date[1].Trim());
                _where += string.Format(" AND "+ dict["createtime"] + " BETWEEN {0} AND {1}", dtStart.ToTimeStamp(), dtEnd.ToTimeStamp());
            }

            if (!string.IsNullOrEmpty(queryLogType))
            {
                _where += string.Format(" AND (" + dict["logtype"] + "={0})", MyParse.ParseInt(queryLogType.Trim(), 0));
            }

            return _where;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PayProject.Common
{
    public static class MyExtensions
    {
        public static DateTime ToDateTime(this int timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        }
        public static int ToTimeStamp(this DateTime time)
        {
            TimeSpan span = (time - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (int)span.TotalSeconds;
        }
        public static int ToTimeStamp(this string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return 0;
            }
            TimeSpan span = (Convert.ToDateTime(time) - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (int)span.TotalSeconds;
        }
        public static int[] ToIntArr(this string[] strArr)
        {
            List<int> numli = new List<int>();
            foreach (var item in strArr)
            {
                numli.Add(Convert.ToInt32(item));
            }
            return numli.ToArray();
        }

        public static string SqlFilters(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            source = source.Replace("--", "");
            //半角括号替换为全角括号
            source = source.Replace("'", "'''");
            //去除执行SQL语句的命令关键字
            source = Regex.Replace(source, "select ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "insert ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "update ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "delete ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "drop ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "truncate ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "declare ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "xp_cmdshell ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "/add ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "net user ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "and ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "or ", "", RegexOptions.IgnoreCase);
            //去除执行存储过程的命令关键字 
            source = Regex.Replace(source, "exec ", "", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "execute ", "", RegexOptions.IgnoreCase);
            //去除系统存储过程或扩展存储过程关键字
            source = Regex.Replace(source, "xp_", "x p_", RegexOptions.IgnoreCase);
            source = Regex.Replace(source, "sp_", "s p_", RegexOptions.IgnoreCase);
            //防止16进制注入
            source = Regex.Replace(source, "0x", "0 x", RegexOptions.IgnoreCase);
            return source;
        }


        public static string BankCardToStar(this string bankCard)
        {
            string str = "";
            if (!string.IsNullOrEmpty(bankCard))
            {
                int bankLen = bankCard.Length;
                str = "**** **** **** " + bankCard.Substring(bankLen - 4);
            }
            return str;
        }

        public static string AlipayToStar(this string alipayCard)
        {
            string str = "";
            if (!string.IsNullOrEmpty(alipayCard))
            {
                if (Utils.IsEmail(alipayCard))
                {
                    int splitIndex = alipayCard.IndexOf('@');
                    if (splitIndex > 1)
                    {
                        str = alipayCard.Substring(0, 2) + "***" + alipayCard.Substring(splitIndex);
                    }
                    else
                    {
                        str = alipayCard.Substring(0, 2) + "******" + alipayCard.Substring(alipayCard.Length - 2);
                    }
                }
                else
                {
                    str = "**** **** **** " + alipayCard.Substring(alipayCard.Length - 4);
                }
            }
            return str;
        }
    }
}

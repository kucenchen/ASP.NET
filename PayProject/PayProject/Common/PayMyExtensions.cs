using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayProject.Common
{
    public static class PayMyExtensions
    {
        public static DateTime ToDateTime(this int timestamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddSeconds(timestamp);
            return newDateTime.ToLocalTime();
        }
        public static int PayToTimeStamp(this DateTime time)
        {
            TimeSpan span = (time - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (int)span.TotalSeconds;
        }
        public static int PayToTimeStamp(this string time)
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
    }
}
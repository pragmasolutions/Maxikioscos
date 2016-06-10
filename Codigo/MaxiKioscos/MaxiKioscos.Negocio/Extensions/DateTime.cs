using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Negocio.Extensions
{
    public static partial class DateTimeExtensions
    {
        public static DateTime ToArgentinaTimezone(this DateTime date)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            return TimeZoneInfo.ConvertTime(date, timeZoneInfo);
        }

        public static string ToArgentinaDateString(this DateTime date)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            var datetime = TimeZoneInfo.ConvertTime(date, timeZoneInfo);
            return datetime.ToShortDateString();
        }

        public static string ToArgentinaTimeString(this DateTime date)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            var datetime = TimeZoneInfo.ConvertTime(date, timeZoneInfo);
            return String.Format("{0} {1}", datetime.ToShortDateString(), datetime.ToShortTimeString());
        }
    }
}

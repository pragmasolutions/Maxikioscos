using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Maxikioscos.Comun.Extensions
{
    public static class NullableExtensions
    {
        public static string ToString(this DateTime? dateTime, string format)
        {
            return dateTime.ToString(format, "");
        }

        public static string ToString(this DateTime? dateTime, string format, string returnIfNull)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString(format);
            else
                return returnIfNull;
        }

        public static string ToShortDateString(this DateTime? dateTime)
        {
            return dateTime.ToShortDateString("");
        }

        public static string ToShortDateString(this DateTime? dateTime, string returnIfNull)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToShortDateString();
            else
                return returnIfNull;
        }

        public static string ToLongString(this DateTime? dateTime, string returnIfNull)
        {
            return dateTime.HasValue
                ? String.Format("{0} {1}", dateTime.Value.ToShortDateString(), dateTime.Value.ToShortTimeString())
                : returnIfNull;
        }

        public static DateTime ToZeroTime(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
        }
    }
}
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
            return date.AddHours(-3);
        }

        public static string ToArgentinaDateString(this DateTime date)
        {
            var datetime = date.AddHours(-3);
            return datetime.ToShortDateString();
        }

        public static string ToArgentinaTimeString(this DateTime date)
        {
            var datetime = date.AddHours(-3);
            return String.Format("{0} {1}", datetime.ToShortDateString(), datetime.ToShortTimeString());
        }
    }
}

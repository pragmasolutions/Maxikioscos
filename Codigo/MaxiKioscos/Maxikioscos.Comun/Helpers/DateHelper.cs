using System;

namespace Maxikioscos.Comun.Helpers
{
    public static class DateHelper
    {
        public static string DateAndTimeToISO(DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            return null;
        }

        public static string DateToISO(DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("yyyy-MM-ddT00:00:00");
            }
            return null;
        }

        public static DateTime? ISOToDate(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return DateTime.Parse(value);
            }
            return null;
        }

        public static double DifferenceInMinutes(DateTime greater, DateTime smaller)
        {
            var diff = greater.Subtract(smaller);
            return diff.TotalMinutes;
        }
    }
}
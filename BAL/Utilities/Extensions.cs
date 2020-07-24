using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Utilities
{
   public static class Extensions
    {
        public static string ToDateTimeString(this DateTime? dt)
        {
            return dt?.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
        }

        public static string ToDateString(this DateTime? dt)
        {
            return dt?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static string ToJsonDateTimeString(this DateTime? dt)
        {
            return dt?.ToString("yyyyMMddThh:mm", CultureInfo.InvariantCulture);
        }

        public static string ToJsonDateString(this DateTime? dt)
        {
            return dt?.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }

    public static class StringExtensions
    {
        public static DateTime? ToDateTime(this string dt)
        {
            return !DateTime.TryParseExact(dt, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime) ? (DateTime?)null : datetime;
        }

        public static DateTime? ToDate(this string dt)
        {
            return !DateTime.TryParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime) ? (DateTime?)null : datetime;
        }


        public static T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public static class ObjectExtensions
    {
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}

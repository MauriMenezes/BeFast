using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.CrossCutting.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GetBrasiliaDateTime()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            return dateTime;
        }

        public static DateTime ConvertTimeToBR(this DateTime value)
        {
            return TimeZoneInfo.ConvertTime(value, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }
    }
}
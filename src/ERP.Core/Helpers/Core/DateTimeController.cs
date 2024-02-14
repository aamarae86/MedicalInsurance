using System;
using System.Globalization;

namespace ERP.Helpers.Core
{
    public class DateTimeController
    {
        public static DateTime? ConvertToDateTime(string dt)
        {
            if (string.IsNullOrEmpty(dt)) return null;
            dt = dt.Replace("م", "PM").Replace("ص", "AM");
            try
            {
                string dtFormat = dt.Contains(" ") && dt.Contains(":")
                                  ? (dt.Contains("AM") || dt.Contains("PM") || dt.Contains("م") || dt.Contains("ص") ? Formatters.DateTimeFormat_AM_PM : Formatters.DateTimeFormat)
                                  : Formatters.DateFormat;

                return DateTime.ParseExact(dt, dtFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception x)
            {
                return DateTime.MinValue;
            }
        }
    }
}

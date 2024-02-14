namespace ERP.Helpers.Core
{
    public class Formatters
    {
        public static string DateFormat = "dd/MM/yyyy";

        public static string TimeFormat = "HH:mm";

        public static string TimeFormat_AM_PM = "HH:mm tt";

        public static string DateTimeFormat = $"{DateFormat} {TimeFormat}";

        public static string DateTimeFormat_AM_PM = $"{DateFormat} {TimeFormat_AM_PM}";
    }
}

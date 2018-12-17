using System;

namespace OnePIF
{
    public class DateTimeFormatter
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static string FormatDate(DateTime dateTime, DateFormat dateFormat)
        {
            switch (dateFormat)
            {
                case DateFormat.International:
                    return dateTime.ToString("yyyy'-'MM'-'dd");
                case DateFormat.Locale:
                    return dateTime.ToShortDateString();
                case DateFormat.Epoch:
                    return (dateTime - UnixEpoch).TotalSeconds.ToString("F0");
                default:
                    break;
            }

            return string.Empty;
        }

        public static string FormatDateTime(DateTime dateTime, DateFormat dateFormat)
        {
            switch (dateFormat)
            {
                case DateFormat.International:
                    return dateTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
                case DateFormat.Locale:
                    return dateTime.ToString("G");
                case DateFormat.Epoch:
                    return (dateTime - UnixEpoch).TotalSeconds.ToString("F0");
                default:
                    break;
            }

            return string.Empty;
        }

        public static string FormatMonthYear(DateTime dateTime, DateFormat dateFormat)
        {
            switch (dateFormat)
            {
                case DateFormat.International:
                    return dateTime.ToString("yyyy'-'MM");
                case DateFormat.Locale:
                    //return dateTime.ToString("MM/yyyy");
                    return dateTime.ToString("y");
                case DateFormat.Epoch:
                    return (dateTime - UnixEpoch).TotalSeconds.ToString("F0");
                default:
                    break;
            }

            return string.Empty;
        }
    }
}

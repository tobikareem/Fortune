namespace Web.Pages.Classes
{
    public static class Extend
    {
        public static string GetConvertedDate(DateTime utcDate, bool withTime = true) => ConvertDateToLocalTime(utcDate, withTime);
        public static string GetTimeDifference(DateTime utcDate) => CalculateTimeDifference(utcDate);

        private static string CalculateTimeDifference(DateTime utcDate)
        {
            var currentTime = DateTime.UtcNow;

            // Get the difference in days, hours, and minutes
            var difference = currentTime - utcDate;
            var days = difference.Days;
            var hours = difference.Hours;
            var minutes = difference.Minutes;


            // If the difference is less than a minute, return "Just now"
            if (difference.TotalMinutes < 1)
            {
                return "Just now";
            }

            // If the difference is less than an hour, return "x minutes ago"
            if (difference.TotalHours < 1)
            {
                return $"~ {minutes} {(minutes == 1 ? "min" : "mins")} ago";
            }

            return difference.TotalDays switch
            {
                // If the difference is less than a day, return "x hours ago"
                < 1 => $"~ {hours} {(hours == 1 ? "hour" : "hours")} ago",
                // If the difference is less than a week, return "x days ago"
                < 7 => $"~ {days} {(days == 1 ? "day" : "days")} ago",
                // If the difference is less than a month, return "x weeks ago"
                < 30 => $"~ {days / 7} {(days / 7 == 1 ? "week" : "weeks")} ago",
                // If the difference is less than a year, return "x months ago"
                < 365 => $"~ {days / 30} {(days / 30 == 1 ? "month" : "months")} ago",
                _ => $"~ {days / 365} {(days / 365 == 1 ? "year" : "years")} ago"
            };
        }

        private static string ConvertDateToLocalTime(DateTime utcDate, bool withTime)
        {
            var pacificTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var pacificDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDate, pacificTimeZone);

            // return date in format MM/dd/yyyy hh:mm tt
            return withTime ? pacificDateTime.ToString("MM/dd/yyyy hh:mm tt") : pacificDateTime.ToString("MM/dd/yyyy");
        }
    }
}

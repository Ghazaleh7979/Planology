namespace Application.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeekFromSaturday(this DateTime date)
        {
            const DayOfWeek weekStart = DayOfWeek.Saturday;
            int diff = (7 + (date.DayOfWeek - weekStart)) % 7;
            return date.AddDays(-diff).Date;
        }
        public static bool IsInCurrentWeekFromSaturday(this DateTime targetDate)
        {
            var today = DateTime.UtcNow.Date;
            var startOfWeek = today.StartOfWeekFromSaturday();
            var endOfWeek = startOfWeek.AddDays(6);

            return targetDate.Date >= startOfWeek && targetDate.Date <= endOfWeek;
        }
    }
}

namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool IsWeekend(this DateTime date)
        => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;

    public static bool IsWeekday(this DateTime date)
        => !date.IsWeekend();

    public static DateTime NextDayOfWeek(this DateTime date, DayOfWeek day)
    {
        int daysToAdd = ((int)day - (int)date.DayOfWeek + 7) % 7;
        return date.AddDays(daysToAdd == 0 ? 7 : daysToAdd);
    }

    public static int DaysUntil(this DateTime date, DateTime untilDate)
        => (untilDate - date).Days;

    public static DateTime AddBusinessDays(this DateTime date, int businessDays)
    {
        if (businessDays == 0)
            return date;

        int direction = businessDays > 0 ? 1 : -1;
        DateTime newDate = date;

        while (businessDays != 0)
        {
            newDate = newDate.AddDays(direction);

            if (newDate.IsWeekday())
                businessDays -= direction;
        }

        return newDate;
    }

    public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
    {
        int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
        return date.AddDays(-1 * diff).Date;
    }

    public static DateTime EndOfWeek(this DateTime date, DayOfWeek endOfWeek = DayOfWeek.Sunday)
    {
        int diff = (7 - (endOfWeek - date.DayOfWeek)) % 7;
        return date.AddDays(diff).Date;
    }

    public static bool IsLaterThan(this DateTime date, DateTime comparison) => date > comparison;

    public static bool IsEarlierThan(this DateTime date, DateTime comparison) => date < comparison;

    public static bool IsBetween(this DateTime date, DateTime start, DateTime end) => date >= start && date <= end;
}
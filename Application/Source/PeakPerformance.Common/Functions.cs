namespace PeakPerformance.Common;

public class Functions
{
    // Date

    public static DateTime GOAL_START_DATE_EARLIEST => TODAY.Date.AddMonths(-6);

    public static DateTime GOAL_START_DATE_LATEST => TODAY.Date.AddMonths(6);

    public static DateTime INJURY_START_DATE_EARLIEST => TODAY.Date.AddYears(-1);

    public static DateTime INJURY_START_DATE_LATEST => TODAY.Date.AddYears(1);

    public static DateTime MINIMUM_AGE => TODAY.Date.AddYears(-18);

    public static DateTime TODAY => DateTime.UtcNow;
}
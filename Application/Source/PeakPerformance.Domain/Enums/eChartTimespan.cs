namespace PeakPerformance.Domain.Enums;

public enum eChartTimespan
{
    [Description("Last 3 Months")]
    Last3Months = 3,

    [Description("Last 6 Months")]
    Last6Months = 6,

    [Description("Last 12 Months")]
    Last12Months = 12,

    [Description("All Time")]
    AllTime = 100
}
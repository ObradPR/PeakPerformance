namespace PeakPerformance.Domain.Searches;

public class WeightSearchOptions : SearchOptions
{
    public long? UserId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }
}
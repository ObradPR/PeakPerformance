namespace PeakPerformance.Application.Dtos.Weights;

public class WeightDto
{
    [Description("Weight")]
    public decimal? Weight { get; set; }

    [Description("Weight Unit")]
    public eMeasurementUnit WeightUnitId { get; set; }

    [Description("Body Fat Percentage")]
    public decimal? BodyFatPercentage { get; set; }
}
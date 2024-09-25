namespace PeakPerformance.Application.Dtos.Weights;

public class WeightDto
{
    [Display(Name = "Weight")]
    public decimal? Weight { get; set; }

    [Display(Name = "Weight Unit")]
    public eMeasurementUnit WeightUnitId { get; set; }

    [Display(Name = "Body Fat Percentage")]
    public decimal? BodyFatPercentage { get; set; }
}
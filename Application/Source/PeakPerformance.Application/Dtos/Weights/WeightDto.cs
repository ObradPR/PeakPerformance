namespace PeakPerformance.Application.Dtos.Weights;

public class WeightDto
{
    [Display(Name = "Weight")]
    public decimal? Weight { get; set; }

    [Display(Name = "Weight unit")]
    public eMeasurementUnit WeightUnitId { get; set; }

    [Display(Name = "Body fat percentage")]
    public decimal? BodyFatPercentage { get; set; }
}
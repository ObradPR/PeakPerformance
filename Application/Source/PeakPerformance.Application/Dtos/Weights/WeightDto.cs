namespace PeakPerformance.Application.Dtos.Weights;

public class WeightDto
{
    [Display(Name = "Weight")]
    public decimal? Weight { get; set; }

    [Display(Name = "Weight unit")]
    public eMeasurementUnit WeightUnitId { get; set; }

    [Display(Name = "Body fat percentage")]
    public decimal? BodyFatPercentage { get; set; }

    public DateTime? LogDate { get; set; }

    // methods

    public void ToModel(Weight model, long userId)
    {
        model.Value = Weight ?? Constants.WEIGHT_DEFAULT;
        model.WeightUnitId = WeightUnitId;
        model.BodyFatPercentage = BodyFatPercentage;
        model.UserId = userId;
        model.LogDate = LogDate ?? DateTime.UtcNow;
    }
}
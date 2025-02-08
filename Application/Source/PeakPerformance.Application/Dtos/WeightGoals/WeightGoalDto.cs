namespace PeakPerformance.Application.Dtos.WeightGoals;

public class WeightGoalDto
{
    public long Id { get; set; }

    [Display(Name = "Target weight")]
    public decimal TargetWeight { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime EndDate { get; set; }

    // methods

    public void ToModel(WeightGoal model, eMeasurementUnit weightUnitId, long userId)
    {
        model.UserId = userId;
        model.TargetWeight = TargetWeight;
        model.StartDate = StartDate;
        model.EndDate = EndDate;
        model.WeightUnitId = weightUnitId;
    }
}
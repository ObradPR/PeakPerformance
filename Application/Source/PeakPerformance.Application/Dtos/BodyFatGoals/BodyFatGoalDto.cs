namespace PeakPerformance.Application.Dtos.BodyFatGoals;

public class BodyFatGoalDto
{
    [Display(Name = "Target body fat percentage")]
    public decimal TargetBodyFatPercentage { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime EndDate { get; set; }

    // methods

    public void ToModel(BodyFatGoal model, long userId)
    {
        model.UserId = userId;
        model.TargetBodyFatPercentage = TargetBodyFatPercentage;
        model.StartDate = StartDate;
        model.EndDate = EndDate;
    }
}
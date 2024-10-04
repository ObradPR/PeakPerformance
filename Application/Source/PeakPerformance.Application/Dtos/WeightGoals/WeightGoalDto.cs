namespace PeakPerformance.Application.Dtos.WeightGoals;

public class WeightGoalDto
{
    [Display(Name = "Target weight")]
    public decimal TargetWeight { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime EndDate { get; set; }
}
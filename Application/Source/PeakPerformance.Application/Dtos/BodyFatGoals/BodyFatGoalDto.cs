namespace PeakPerformance.Application.Dtos.BodyFatGoals;

public class BodyFatGoalDto
{
    [Display(Name = "Target Body Fat Percentage")]
    public decimal TargetBodyFatPercentage { get; set; }

    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
}
namespace PeakPerformance.Application.Dtos.WeightGoals;

public class WeightGoalDto
{
    [Display(Name = "Target Weight")]
    public decimal TargetWeight { get; set; }

    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
}
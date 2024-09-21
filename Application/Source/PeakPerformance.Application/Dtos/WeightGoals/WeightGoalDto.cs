namespace PeakPerformance.Application.Dtos.WeightGoals;

public class WeightGoalDto
{
    [Description("Target Weight")]
    public decimal TargetWeight { get; set; }

    [Description("Start Date")]
    public DateTime StartDate { get; set; }

    [Description("End Date")]
    public DateTime EndDate { get; set; }
}
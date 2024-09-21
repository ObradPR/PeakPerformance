using System.ComponentModel;

namespace PeakPerformance.Application.Dtos.BodyFatGoals;

public class BodyFatGoalDto
{
    [Description("Target Body Fat Percentage")]
    public decimal TargetBodyFatPercentage { get; set; }

    [Description("Start Date")]
    public DateTime StartDate { get; set; }

    [Description("End Date")]
    public DateTime EndDate { get; set; }
}
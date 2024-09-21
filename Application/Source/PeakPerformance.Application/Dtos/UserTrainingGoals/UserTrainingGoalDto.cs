namespace PeakPerformance.Application.Dtos.UserTrainingGoals;

public class UserTrainingGoalDto
{
    [Description("Training Goal")]
    public eTrainingGoal TrainingGoalId { get; set; }

    [Description("Start Date")]
    public DateTime StartDate { get; set; }

    [Description("End Date")]
    public DateTime? EndDate { get; set; }
}
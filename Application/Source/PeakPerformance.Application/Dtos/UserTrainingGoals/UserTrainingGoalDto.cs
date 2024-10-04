namespace PeakPerformance.Application.Dtos.UserTrainingGoals;

public class UserTrainingGoalDto
{
    [Display(Name = "Training goal")]
    public eTrainingGoal TrainingGoalId { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime? EndDate { get; set; }
}
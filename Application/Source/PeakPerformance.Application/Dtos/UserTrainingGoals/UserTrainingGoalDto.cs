namespace PeakPerformance.Application.Dtos.UserTrainingGoals;

public class UserTrainingGoalDto
{
    [Display(Name = "Training Goal")]
    public eTrainingGoal TrainingGoalId { get; set; }

    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime? EndDate { get; set; }
}
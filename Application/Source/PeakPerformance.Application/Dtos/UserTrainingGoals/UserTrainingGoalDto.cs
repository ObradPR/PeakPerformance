namespace PeakPerformance.Application.Dtos.UserTrainingGoals;

public class UserTrainingGoalDto
{
    [Display(Name = "Training goal")]
    public eTrainingGoal TrainingGoalId { get; set; }

    [Display(Name = "Start date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime? EndDate { get; set; }

    // methods

    public void ToModel(UserTrainingGoal model, long userId)
    {
        model.UserId = userId;
        model.TrainingGoalId = TrainingGoalId;
        model.StartDate = StartDate;
        model.EndDate = EndDate;
    }
}
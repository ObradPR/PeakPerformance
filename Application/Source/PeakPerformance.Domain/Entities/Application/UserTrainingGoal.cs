namespace PeakPerformance.Domain.Entities.Application;

public class UserTrainingGoal : BaseAuditedDomain<long>
{
    public long UserId { get; set; }

    public eTrainingGoal TrainingGoalId { get; set; }

    [Column(TypeName = Constants.DB_TYPE_DATE)]
    public DateTime StartDate { get; set; }

    [Column(TypeName = Constants.DB_TYPE_DATE)]
    public DateTime? EndDate { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(TrainingGoalId))]
    public virtual TrainingGoal TrainingGoal { get; set; }

    #endregion Relationships
}
namespace PeakPerformance.Domain.Entities.Application;

public class UserActivityLog : BaseDomain<long>
{
    public long UserId { get; set; }

    public eActionType ActionTypeId { get; set; }

    public DateTime RecordDate { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(ActionTypeId))]
    public virtual ActionType ActionType { get; set; }

    #endregion Relationships
}
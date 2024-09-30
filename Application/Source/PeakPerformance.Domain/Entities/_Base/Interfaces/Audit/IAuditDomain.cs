namespace PeakPerformance.Domain.Entities._Base.Interfaces.Audit;

public interface IAuditDomain<TKey>
    where TKey : struct
{
    DateTime? CreatedOn { get; set; }

    DateTime? ModifiedOn { get; set; }

    TKey? ModifiedBy { get; set; }

    DateTime? DeletedOn { get; set; }

    TKey? DeletedBy { get; set; }

    bool? IsActive { get; set; }

    eActionType? ActionTypeId { get; set; }

    string DetailsJson { get; set; }

    // relationships

    ActionType ActionType { get; set; }
}
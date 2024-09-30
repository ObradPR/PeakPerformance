using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PeakPerformance.Domain.Entities._Base.Interfaces.Audit;

namespace PeakPerformance.Domain.Entities._Base.Audit;

public abstract class AuditDomain
{ }

public class AuditDomain<TKey> : AuditDomain, IAuditDomainEntity<TKey>
{
    [Key]
    public long AuditId { get; set; }

    public TKey Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public long? DeletedBy { get; set; }

    public bool? IsActive { get; set; }

    public eActionType? ActionTypeId { get; set; }

    public string DetailsJson { get; set; }

    #region Relationships

    [ForeignKey(nameof(ActionTypeId))]
    public ActionType ActionType { get; set; }

    #endregion Relationships
}
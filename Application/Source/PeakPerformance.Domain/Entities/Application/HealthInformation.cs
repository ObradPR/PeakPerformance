﻿namespace PeakPerformance.Domain.Entities.Application;

[NoPlural]
public class HealthInformation : BaseAuditedDomain<long>
{
    public long UserId { get; set; }

    public eInjuryType InjuryTypeId { get; set; }

    public string Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(InjuryTypeId))]
    public virtual InjuryType InjuryType { get; set; }

    #endregion Relationships
}
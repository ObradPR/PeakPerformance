namespace PeakPerformance.Domain.Entities._Base.Interfaces.Audit;

public interface IAuditDomainEntity<TKey> : IAuditDomainEntity
{
    TKey Id { get; set; }

    DateTime AuditTimeStamp { get; set; }
}

public interface IAuditDomainEntity : IAuditDomain<long>
{ }
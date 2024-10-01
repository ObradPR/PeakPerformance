namespace PeakPerformance.Domain.Entities.Audits;

[Audit]
public class UserRole_aud : AuditDomain<long>
{
    public long? UserId { get; set; }

    public eSystemRole? RoleId { get; set; }
}
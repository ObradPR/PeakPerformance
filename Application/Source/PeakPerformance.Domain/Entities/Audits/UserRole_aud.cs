namespace PeakPerformance.Domain.Entities.Audits;

public class UserRole_aud : AuditDomain<long>
{
    public long? UserId { get; set; }

    public eSystemRole? RoleId { get; set; }
}
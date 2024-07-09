using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Audits;

public class UserRole_aud : Audit
{
    public long? Id { get; set; }

    public long? UserId { get; set; }

    public int? RoleId { get; set; }
}
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class UserRole : AuditableEntity
{
    public long? UserId { get; set; }

    public int RoleId { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual SystemRole Role { get; set; }
}
using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application;

namespace PeakPerformance.Domain.Entities.Application_lu;

public class SystemRole : Entity_lu
{
    // Relationships

    public virtual ICollection<UserRole> UserRoles { get; set; } = [];
}
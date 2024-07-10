using PeakPerformance.Domain.Entities._Base;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Entities.Audits;

namespace PeakPerformance.Domain.Entities.Application_lu;

public class ActionType : Entity_lu
{
    // Relationships

    public virtual ICollection<User_aud> Users_aud { get; set; } = [];

    public virtual ICollection<UserRole_aud> UserRoles_aud { get; set; } = [];

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = [];
}
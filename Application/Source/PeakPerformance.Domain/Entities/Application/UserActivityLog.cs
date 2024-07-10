using PeakPerformance.Domain.Entities.Application_lu;

namespace PeakPerformance.Domain.Entities.Application;

public class UserActivityLog
{
    public UserActivityLog() => RecordDate = DateTime.UtcNow;

    public long Id { get; set; }

    public long UserId { get; set; }

    public int ActionTypeId { get; set; }

    public DateTime RecordDate { get; set; }

    // Relationships

    public virtual User User { get; set; }

    public virtual ActionType ActionType { get; set; }
}
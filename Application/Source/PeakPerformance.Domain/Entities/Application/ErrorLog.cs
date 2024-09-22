using PeakPerformance.Domain.Entities._Base;

namespace PeakPerformance.Domain.Entities.Application;

public class ErrorLog : _BaseEntity
{
    public ErrorLog() => RecordDate = DateTime.UtcNow;

    public long Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public string? StackTrace { get; set; }

    public string? InnerException { get; set; }

    public DateTime RecordDate { get; set; }
}
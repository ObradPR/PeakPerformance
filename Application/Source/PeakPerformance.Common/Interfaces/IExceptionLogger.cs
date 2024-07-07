namespace PeakPerformance.Common.Interfaces;

public interface IExceptionLogger
{
    Task LogExceptionAsync(Exception ex);
}
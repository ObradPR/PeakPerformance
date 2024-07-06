namespace PeakPerformance.Common.Interfaces;

public interface IExceptionLogger
{
    void LogException(Exception ex);
}
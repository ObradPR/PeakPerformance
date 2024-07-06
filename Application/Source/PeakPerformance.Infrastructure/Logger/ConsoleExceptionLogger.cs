using PeakPerformance.Common.Interfaces;
using Serilog;

namespace PeakPerformance.Infrastructure.Logger;

public class ConsoleExceptionLogger : IExceptionLogger
{
    public void LogException(Exception ex)
        => Log.Error(ex, $"An Error occurred\nMessage: {ex.Message}");
}
using PeakPerformance.Domain.Interfaces;
using Serilog;

namespace PeakPerformance.Infrastructure.Logger;

public class ConsoleExceptionLogger : IExceptionLogger
{
    public Task LogExceptionAsync(Exception ex)
    {
        Log.Error(ex, $"An Error occurred\nMessage: {ex.Message}");
        return Task.CompletedTask;
    }
}
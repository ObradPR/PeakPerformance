namespace PeakPerformance.Domain.Repositories.Application;

public interface IUserActivityLogRepository
{
    // Get

    // Add, Remove, Edit

    Task AddAsync(UserActivityLog userActivityLog, CancellationToken cancellationToken = default);
}
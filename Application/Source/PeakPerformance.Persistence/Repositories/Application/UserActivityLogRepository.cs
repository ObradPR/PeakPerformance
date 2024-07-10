using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Repositories.Application;
using PeakPerformance.Persistence.Contexts;
using PeakPerformance.Persistence.Repositories._Base;

namespace PeakPerformance.Persistence.Repositories.Application;

public class UserActivityLogRepository(ApplicationDbContext context)
    : BaseRepository(context), IUserActivityLogRepository
{
    // Get

    // Add, Remove, Edit

    public async Task AddAsync(UserActivityLog userActivityLog, CancellationToken cancellationToken = default)
        => await Context.UserActivityLogs.AddAsync(userActivityLog, cancellationToken);
}
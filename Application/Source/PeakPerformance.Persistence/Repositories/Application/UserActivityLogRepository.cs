namespace PeakPerformance.Persistence.Repositories.Application;

public class UserActivityLogRepository(ApplicationDbContext context)
    : BaseRepository(context), IUserActivityLogRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(UserActivityLog userActivityLog) => await db.CreateAsync(userActivityLog);
}
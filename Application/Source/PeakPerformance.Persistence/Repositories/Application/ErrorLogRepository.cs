namespace PeakPerformance.Persistence.Repositories.Application;

public class ErrorLogRepository(ApplicationDbContext context)
    : BaseRepository(context), IErrorLogRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(ErrorLog model) => await db.CreateAsync(model);
}
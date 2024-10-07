namespace PeakPerformance.Persistence.Repositories.Application;

public class HealthInformationRepository(ApplicationDbContext context)
    : BaseRepository(context), IHealthInformationRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddRangeAsync(IEnumerable<HealthInformation> models) => await db.CreateListAsync(models);
}
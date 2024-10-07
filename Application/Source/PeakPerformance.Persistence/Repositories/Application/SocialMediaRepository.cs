namespace PeakPerformance.Persistence.Repositories.Application;

public class SocialMediaRepository(ApplicationDbContext context)
    : BaseRepository(context), ISocialMediaRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddRangeAsync(IEnumerable<SocialMedia> models) => await db.CreateListAsync(models);
}

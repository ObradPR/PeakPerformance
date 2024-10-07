namespace PeakPerformance.Persistence.Repositories.Application;

public class WeightRepository(ApplicationDbContext context)
    : BaseRepository(context), IWeightRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(Weight model) => await db.CreateAsync(model);
}
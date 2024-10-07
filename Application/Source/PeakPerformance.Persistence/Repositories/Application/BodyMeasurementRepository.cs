namespace PeakPerformance.Persistence.Repositories.Application;

public class BodyMeasurementRepository(ApplicationDbContext context)
    : BaseRepository(context), IBodyMeasurementRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(BodyMeasurement model) => await db.CreateAsync(model);
}

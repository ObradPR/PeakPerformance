namespace PeakPerformance.Persistence.Repositories.Application;

public class UserMeasurementPreferenceRepository(ApplicationDbContext context)
    : BaseRepository(context), IUserMeasurementPreferenceRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(UserMeasurementPreference model) => await db.CreateAsync(model);
}
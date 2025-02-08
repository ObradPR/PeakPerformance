namespace PeakPerformance.Persistence.Repositories.Application;

public class UserMeasurementPreferenceRepository(ApplicationDbContext context)
    : BaseRepository(context), IUserMeasurementPreferenceRepository
{
    // Get

    public async Task<UserMeasurementPreference> GetByUserIdAsync(long userId) => await db.UserMeasurementPreferences.GetSingleAsync(_ => _.UserId == userId);

    // Add / Remove / Edit

    public async Task AddAsync(UserMeasurementPreference model) => await db.CreateAsync(model);
}
namespace PeakPerformance.Domain.Repositories.Application;

public interface IUserMeasurementPreferenceRepository
{
    // Get

    Task<UserMeasurementPreference> GetByUserIdAsync(long userId);

    // Add / Remove / Edit

    Task AddAsync(UserMeasurementPreference model);
}
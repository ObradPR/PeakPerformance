namespace PeakPerformance.Domain.Repositories.Application;

public interface ISocialMediaRepository
{
    // Get

    // Add / Remove / Edit

    Task AddRangeAsync(IEnumerable<SocialMedia> models);
}
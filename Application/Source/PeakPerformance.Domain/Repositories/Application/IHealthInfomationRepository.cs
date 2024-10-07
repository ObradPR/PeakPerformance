using HealthInformation_ = PeakPerformance.Domain.Entities.Application.HealthInformation;

namespace PeakPerformance.Domain.Repositories.Application;

public interface IHealthInformationRepository
{
    // Get

    // Add / Remove / Edit

    Task AddRangeAsync(IEnumerable<HealthInformation_> models);
}
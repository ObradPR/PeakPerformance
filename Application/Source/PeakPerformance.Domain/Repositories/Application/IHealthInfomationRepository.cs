using HealthInformation_ = PeakPerformance.Domain.Entities.Application.HealthInformation;

namespace PeakPerformance.Domain.Repositories.Application;

public interface IHealthInformationRepository
{
    // Get

    Task<PagingResult<HealthInformation>> SearchAsync(HealthInformationSearchOptions options, List<Expression<Func<HealthInformation, bool>>> predicates);

    // Add / Remove / Edit

    Task AddRangeAsync(IEnumerable<HealthInformation_> models);
}
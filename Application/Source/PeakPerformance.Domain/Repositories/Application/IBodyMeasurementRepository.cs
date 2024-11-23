using System.Linq.Expressions;

namespace PeakPerformance.Domain.Repositories.Application;

public interface IBodyMeasurementRepository
{
    // Get

    Task<PagingResult<BodyMeasurement>> SearchAsync(BodyMeasurementSearchOptions options, List<Expression<Func<BodyMeasurement, bool>>> predicates);

    // Add / Remove / Edit

    Task AddAsync(BodyMeasurement model);
}
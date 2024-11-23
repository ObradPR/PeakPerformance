using PeakPerformance.Domain.Searches;

namespace PeakPerformance.Persistence.Repositories.Application;

public class BodyMeasurementRepository(ApplicationDbContext context)
    : BaseRepository(context), IBodyMeasurementRepository
{
    // Get

    public async Task<PagingResult<BodyMeasurement>> SearchAsync(BodyMeasurementSearchOptions options, List<Expression<Func<BodyMeasurement, bool>>> predicates)
       => await db.BodyMeasurements.SearchAsync(options, _ => _.CreatedOn, true, predicates, null);

    // Add / Remove / Edit

    public async Task AddAsync(BodyMeasurement model) => await db.CreateAsync(model);
}
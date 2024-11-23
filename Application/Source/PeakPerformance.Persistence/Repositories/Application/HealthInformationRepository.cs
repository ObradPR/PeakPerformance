namespace PeakPerformance.Persistence.Repositories.Application;

public class HealthInformationRepository(ApplicationDbContext context)
    : BaseRepository(context), IHealthInformationRepository
{
    // Get

    public async Task<PagingResult<HealthInformation>> SearchAsync(HealthInformationSearchOptions options, List<Expression<Func<HealthInformation, bool>>> predicates)
        => await db.HealthInformation.SearchAsync(options, _ => _.CreatedOn, true, predicates, null);

    // Add / Remove / Edit

    public async Task AddRangeAsync(IEnumerable<HealthInformation> models) => await db.CreateListAsync(models);
}
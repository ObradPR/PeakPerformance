namespace PeakPerformance.Persistence.Repositories.Application;

public class WeightRepository(ApplicationDbContext context)
    : BaseRepository(context), IWeightRepository
{
    // Get

    public async Task<PagingResult<Weight>> SearchAsync(WeightSearchOptions options, List<Expression<Func<Weight, bool>>> predicates)
        => await db.Weights.SearchAsync(options, _ => _.LogDate, true, predicates, null);

    // Add / Remove / Edit

    public async Task AddAsync(Weight model) => await db.CreateAsync(model);
}
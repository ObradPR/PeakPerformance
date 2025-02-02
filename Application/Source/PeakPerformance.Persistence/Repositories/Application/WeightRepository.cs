namespace PeakPerformance.Persistence.Repositories.Application;

public class WeightRepository(ApplicationDbContext context)
    : BaseRepository(context), IWeightRepository
{
    // Get

    public async Task<Weight> GetByIdAsync(long id) => await db.Weights.GetSingleAsync(id);

    public async Task<PagingResult<Weight>> SearchAsync(WeightSearchOptions options, List<Expression<Func<Weight, bool>>> predicates)
        => await db.Weights.SearchAsync(options, _ => _.LogDate, false, predicates, null);

    // Add / Remove / Edit

    public async Task AddAsync(Weight model) => await db.CreateAsync(model);

    public async Task RemoveAsync(long id) => db.DeleteSingle(await GetByIdAsync(id));
}
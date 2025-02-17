namespace PeakPerformance.Persistence.Repositories.Application;

public class WeightGoalRepository(ApplicationDbContext context)
    : BaseRepository(context), IWeightGoalRepository
{
    // Get

    public async Task<WeightGoal> GetSingleAsync(long id) => await db.WeightGoals.GetSingleAsync(id);

    public async Task<PagingResult<WeightGoal>> SearchAsync(WeightGoalSearchOptions options, List<Expression<Func<WeightGoal, bool>>> predicates)
    => await db.WeightGoals.SearchAsync(options, _ => _.StartDate, false, predicates, null);

    // Add / Remove / Edit

    public async Task AddAsync(WeightGoal model) => await db.CreateAsync(model);

    public async Task RemoveAsync(long id) => db.DeleteSingle(await GetSingleAsync(id));
}
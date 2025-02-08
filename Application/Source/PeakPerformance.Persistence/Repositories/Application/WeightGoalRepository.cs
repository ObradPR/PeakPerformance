namespace PeakPerformance.Persistence.Repositories.Application;

public class WeightGoalRepository(ApplicationDbContext context)
    : BaseRepository(context), IWeightGoalRepository
{
    // Get

    public async Task<WeightGoal> GetByIdAsync(long id) => await db.WeightGoals.GetSingleAsync(id);

    // Add / Remove / Edit

    public async Task AddAsync(WeightGoal model) => await db.CreateAsync(model);

    public async Task RemoveAsync(long id) => db.DeleteSingle(await GetByIdAsync(id));
}
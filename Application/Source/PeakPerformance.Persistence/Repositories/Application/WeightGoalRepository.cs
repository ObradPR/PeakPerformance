namespace PeakPerformance.Persistence.Repositories.Application;

public class WeightGoalRepository(ApplicationDbContext context)
    : BaseRepository(context), IWeightGoalRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(WeightGoal model) => await db.CreateAsync(model);
}

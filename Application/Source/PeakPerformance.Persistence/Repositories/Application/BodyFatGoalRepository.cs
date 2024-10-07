namespace PeakPerformance.Persistence.Repositories.Application;

public class BodyFatGoalRepository(ApplicationDbContext context)
    : BaseRepository(context), IBodyFatGoalRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(BodyFatGoal model) => await db.CreateAsync(model);
}

namespace PeakPerformance.Persistence.Repositories.Application;

public class UserTrainingGoalRepository(ApplicationDbContext context)
    : BaseRepository(context), IUserTrainingGoalRepository
{
    // Get

    // Add / Remove / Edit

    public async Task AddAsync(UserTrainingGoal model) => await db.CreateAsync(model);
}

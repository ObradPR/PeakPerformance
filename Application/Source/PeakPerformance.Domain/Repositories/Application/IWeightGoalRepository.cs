namespace PeakPerformance.Domain.Repositories.Application;

public interface IWeightGoalRepository
{
    // Get

    Task<WeightGoal> GetByIdAsync(long id);

    // Add / Remove / Edit

    Task AddAsync(WeightGoal model);

    Task RemoveAsync(long id);
}
namespace PeakPerformance.Domain.Repositories.Application;

public interface IWeightGoalRepository
{
    // Get

    Task<WeightGoal> GetByIdAsync(long id);

    Task<PagingResult<WeightGoal>> SearchAsync(WeightGoalSearchOptions options, List<Expression<Func<WeightGoal, bool>>> predicates);

    // Add / Remove / Edit

    Task AddAsync(WeightGoal model);

    Task RemoveAsync(long id);
}
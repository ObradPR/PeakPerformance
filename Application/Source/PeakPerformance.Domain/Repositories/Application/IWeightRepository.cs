namespace PeakPerformance.Domain.Repositories.Application;

public interface IWeightRepository
{
    // Get
    Task<Weight> GetByIdAsync(long id);

    Task<PagingResult<Weight>> SearchAsync(WeightSearchOptions options, List<Expression<Func<Weight, bool>>> predicates);

    // Add / Remove / Edit

    Task AddAsync(Weight model);

    Task RemoveAsync(long id);
}
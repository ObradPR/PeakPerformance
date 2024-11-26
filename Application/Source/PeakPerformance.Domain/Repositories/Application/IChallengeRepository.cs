namespace PeakPerformance.Domain.Repositories.Application;

public interface IChallengeRepository
{
    // Get

    Task<PagingResult<Challenge>> SearchAsync(ChallengeSearchOptions options, List<Expression<Func<Challenge, bool>>> predicates);

    // Add / Remove / Edit
}
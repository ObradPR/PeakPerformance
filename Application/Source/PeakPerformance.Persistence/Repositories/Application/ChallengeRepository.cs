namespace PeakPerformance.Persistence.Repositories.Application;

public class ChallengeRepository(ApplicationDbContext context)
    : BaseRepository(context), IChallengeRepository
{
    // Get

    public async Task<PagingResult<Challenge>> SearchAsync(ChallengeSearchOptions options, List<Expression<Func<Challenge, bool>>> predicates)
        => await db.Challenges.SearchAsync(options, _ => _.CreatedOn, true, predicates, null);

    // Add / Remove / Edit
}
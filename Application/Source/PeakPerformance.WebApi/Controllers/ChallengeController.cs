using PeakPerformance.Application.BusinessLogic.Challenges.Queries;
using PeakPerformance.Application.Dtos.Challenges;

namespace PeakPerformance.WebApi.Controllers;

public class ChallengeController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResult<ChallengeDto>))]
    public async Task<IActionResult> Search(ChallengeSearchOptions options) => Ok(await Mediator.Send(new SearchChallengesQuery(options)));
}
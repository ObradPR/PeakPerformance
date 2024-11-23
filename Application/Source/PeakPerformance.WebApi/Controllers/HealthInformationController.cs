using PeakPerformance.Application.BusinessLogic.HealthInformation.Queries;
using PeakPerformance.Application.Dtos.HealthInformation;

namespace PeakPerformance.WebApi.Controllers;

public class HealthInformationController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResult<HealthInformationDto>))]
    public async Task<IActionResult> Search(HealthInformationSearchOptions options) => Ok(await Mediator.Send(new SearchHealthInformationQuery(options)));
}
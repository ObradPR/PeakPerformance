using PeakPerformance.Application.BusinessLogic.Weights.Queries;
using PeakPerformance.Application.Dtos._Grid;
using PeakPerformance.Application.Dtos.Searches;

namespace PeakPerformance.WebApi.Controllers;

public class WeightController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResultDto))]
    public async Task<IActionResult> Search(WeightSearchOptionsDto options) => Ok(await Mediator.Send(new SearchWeightsQuery(options)));
}
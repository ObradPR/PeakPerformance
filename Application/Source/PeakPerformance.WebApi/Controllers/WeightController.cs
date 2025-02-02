using PeakPerformance.Application.BusinessLogic.Weights.Commands;
using PeakPerformance.Application.BusinessLogic.Weights.Queries;
using PeakPerformance.Application.Dtos.Weights;

namespace PeakPerformance.WebApi.Controllers;

public class WeightController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResult<WeightDto>))]
    public async Task<IActionResult> Search(WeightSearchOptions options) => Ok(await Mediator.Send(new SearchWeightsQuery(options)));

    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Add(WeightDto data)
    {
        await Mediator.Send(new AddBodyweightCommand(data));
        return NoContent();
    }

    [HttpPut]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Edit(WeightDto data)
    {
        await Mediator.Send(new EditBodyweightCommand(data));
        return NoContent();
    }

    [HttpDelete]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Remove([FromQuery] long id)
    {
        await Mediator.Send(new RemoveBodyweightCommand(id));
        return NoContent();
    }
}
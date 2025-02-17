using PeakPerformance.Application.BusinessLogic.WeightGoals.Commands;
using PeakPerformance.Application.BusinessLogic.WeightGoals.Queries;
using PeakPerformance.Application.Dtos.WeightGoals;

namespace PeakPerformance.WebApi.Controllers;

public class WeightGoalController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(PagingResult<WeightGoalDto>))]
    public async Task<IActionResult> Search(WeightGoalSearchOptions options) => Ok(await Mediator.Send(new SearchWeightGoalsQuery(options)));

    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Add(WeightGoalDto data)
    {
        await Mediator.Send(new AddBodyweightGoalCommand(data));
        return NoContent();
    }

    [HttpPut]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Edit(WeightGoalDto data)
    {
        await Mediator.Send(new EditBodyweightGoalCommand(data));
        return NoContent();
    }

    [HttpDelete]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Remove([FromQuery] long id)
    {
        await Mediator.Send(new RemoveBodyweightGoalCommand(id));
        return NoContent();
    }
}
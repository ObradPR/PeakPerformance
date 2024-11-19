using PeakPerformance.Application.BusinessLogic.Users.Commands;
using PeakPerformance.Application.BusinessLogic.Users.Queries;
using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.WebApi.Controllers;

public class UserController(IMediator mediator) : BaseController(mediator)
{
    [HttpGet]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(UserDto))]
    public async Task<IActionResult> GetCurrent() => Ok(await Mediator.Send(new GetCurrentUserQuery()));

    [HttpPost]
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ProfileSetup([FromForm] ProfileSetupDto data)
    {
        await Mediator.Send(new ProfileSetupCommand(data));

        return NoContent();
    }
}
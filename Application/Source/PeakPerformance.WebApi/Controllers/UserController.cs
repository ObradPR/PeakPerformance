using PeakPerformance.Application.BusinessLogic.Users.Commands;
using PeakPerformance.Application.Dtos.Users;

namespace PeakPerformance.WebApi.Controllers;

public class UserController(IMediator mediator) : BaseController(mediator)
{
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ProfileSetup([FromForm] ProfileSetupDto data)
    {
        await Mediator.Send(new ProfileSetupCommand(data));

        return NoContent();
    }
}
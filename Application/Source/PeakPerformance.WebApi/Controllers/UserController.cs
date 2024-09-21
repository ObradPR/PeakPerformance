using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeakPerformance.Application.BusinessLogic.Users.Commands;
using PeakPerformance.Application.Dtos.Users;
using PeakPerformance.Common.Enums;
using PeakPerformance.WebApi.Attributes;
using PeakPerformance.WebApi.Controllers._Base;
using PeakPerformance.WebApi.ReinforcedTypings.Generator;

namespace PeakPerformance.WebApi.Controllers;

public class UserController(IMediator mediator) : BaseController(mediator)
{
    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ProfileSetup(ProfileSetupDto settings)
    {
        await Mediator.Send(new ProfileSetupCommand(settings));

        return NoContent();
    }
}
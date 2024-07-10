using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeakPerformance.Application.BusinessLogic.Users.Commands;
using PeakPerformance.Application.Dtos.Users.Auth;
using PeakPerformance.Common.Enums;
using PeakPerformance.WebApi.Attributes;
using PeakPerformance.WebApi.Controllers._Base;
using PeakPerformance.WebApi.ReinforcedTypings.Generator;

namespace PeakPerformance.WebApi.Controllers;

public class AuthController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [AngularMethod(typeof(AuthorizationDto))]
    public async Task<IActionResult> Signup([FromBody] SignupDto user) => Ok(await Mediator.Send(new SignupCommand(user)));

    [HttpPost]
    [AngularMethod(typeof(AuthorizationDto))]
    public async Task<IActionResult> Signin(SigninDto user) => Ok(await Mediator.Send(new SigninCommand(user)));

    [Authorization(eSystemRole.User, eSystemRole.Admin)]
    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> Signout()
    {
        await Mediator.Send(new SignoutCommand());

        return NoContent();
    }
}
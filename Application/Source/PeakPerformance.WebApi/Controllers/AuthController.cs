using MediatR;
using PeakPerformance.WebApi.Controllers._Base;

namespace PeakPerformance.WebApi.Controllers;

public class AuthController(IMediator mediator) : BaseController(mediator)
{
    //[HttpPost]
    //[AngularMethod(typeof(AuthorizationDto))]
    //public async Task<IActionResult> Signup(SignupDto user) => Ok(await Mediator.Send(new SignupCommand(user)));

    //[HttpPost]
    //[AngularMethod(typeof(AuthorizationDto))]
    //public async Task<IActionResult> Signin(SigninDto user) => Ok(await Mediator.Send(new SigninCommand(user)));
}
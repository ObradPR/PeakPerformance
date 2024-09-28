using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeakPerformance.Application.BusinessLogic.Users.Commands;
using PeakPerformance.Application.Dtos.Users.Auth;
using PeakPerformance.Application.Interfaces;
using PeakPerformance.Common.Enums;
using PeakPerformance.Common.Exceptions;
using PeakPerformance.WebApi.Attributes;
using PeakPerformance.WebApi.Controllers._Base;
using PeakPerformance.WebApi.ReinforcedTypings.Generator;

namespace PeakPerformance.WebApi.Controllers;

public class AuthController(IMediator mediator, IVerificationCodeService verificationCodeService)
    : BaseController(mediator)
{
    private readonly IVerificationCodeService _verificationCodeService = verificationCodeService;

    [HttpPost]
    [AngularMethod(typeof(AuthorizationDto))]
    public async Task<IActionResult> Signup([FromBody] SignupDto user)
    {
        if (!_verificationCodeService.ValidateCode(user.Email, user.VerificationCode))
            throw new ValidationException();

        return Ok(await Mediator.Send(new SignupCommand(user)));
    }

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

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ValidateEmail(ValidateUserDto user)
    {
        await Mediator.Send(new ValidateEmailCommand(user));

        return NoContent();
    }

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ValidateUser(ValidateUserDto user)
    {
        await Mediator.Send(new ValidateUserCommand(user));

        return NoContent();
    }

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ValidateCode(ValidateUserCodeDto user)
    {
        if (!_verificationCodeService.ValidateCode(user.Email, user.VerifyCode))
            throw new ValidationException();

        return NoContent();
    }

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto user)
    {
        await Mediator.Send(new ChangePasswordCommand(user));

        return NoContent();
    }
}
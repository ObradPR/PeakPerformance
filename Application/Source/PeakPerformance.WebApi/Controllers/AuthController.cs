using PeakPerformance.Application.BusinessLogic.Users.Commands;
using PeakPerformance.Application.Dtos.Users.Auth;

namespace PeakPerformance.WebApi.Controllers;

public class AuthController(IMediator mediator, IVerificationCodeService verificationCodeService)
    : BaseController(mediator)
{
    private readonly IVerificationCodeService _verificationCodeService = verificationCodeService;

    [HttpPost]
    [AngularMethod(typeof(AuthorizationDto))]
    public async Task<IActionResult> Signup([FromBody] SignupDto data)
    {
        if (!_verificationCodeService.ValidateCode(data.Email, data.VerificationCode))
            throw new ValidationException();

        return Ok(await Mediator.Send(new SignupCommand(data)));
    }

    [HttpPost]
    [AngularMethod(typeof(AuthorizationDto))]
    public async Task<IActionResult> Signin(SigninDto data) => Ok(await Mediator.Send(new SigninCommand(data)));

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
    public async Task<IActionResult> ValidateEmail(ValidateUserDto data)
    {
        await Mediator.Send(new ValidateEmailCommand(data));

        return NoContent();
    }

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ValidateUser(ValidateUserDto data)
    {
        await Mediator.Send(new ValidateUserCommand(data));

        return NoContent();
    }

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ValidateCode(ValidateUserCodeDto data)
    {
        if (!_verificationCodeService.ValidateCode(data.Email, data.VerifyCode))
            throw new ValidationException();

        return NoContent();
    }

    [HttpPost]
    [AngularMethod(typeof(void))]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto data)
    {
        await Mediator.Send(new ChangePasswordCommand(data));

        return NoContent();
    }
}
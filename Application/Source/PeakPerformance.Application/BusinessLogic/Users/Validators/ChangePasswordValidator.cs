namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(_ => _.User.Password)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .Matches(Constants.REGEX_PASSWORD)
            .WithMessageAuto(ResourceValidation.Password);

        RuleFor(_ => _.User.ConfirmPassword)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .Equal(_ => _.User.Password)
            .WithMessageAuto(ResourceValidation.Dont_Match, "Password");
    }
}
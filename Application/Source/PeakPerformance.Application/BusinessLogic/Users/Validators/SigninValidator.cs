namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SigninValidator : AbstractValidator<SigninCommand>
{
    public SigninValidator()
    {
        RuleFor(_ => _.User.Username)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .MaximumLength(30)
            .WithMessageAuto(ResourceValidation.Maximum_Characters, "30")
            .MinimumLength(2)
            .WithMessageAuto(ResourceValidation.Minimum_Characters, "2");

        RuleFor(_ => _.User.Password)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .Matches(Constants.REGEX_PASSWORD)
            .WithMessageAuto(ResourceValidation.Password);
    }
}
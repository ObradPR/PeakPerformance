namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SigninValidator : AbstractValidator<SigninCommand>
{
    public SigninValidator()
    {
        RuleFor(_ => _.User.Username)
            .Required()
            .MaximumLengthAuto(30)
            .MinimumLengthAuto(2);

        RuleFor(_ => _.User.Password)
            .Required()
            .MatchesPassword();
    }
}
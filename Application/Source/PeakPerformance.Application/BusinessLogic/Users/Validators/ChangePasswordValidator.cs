namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(_ => _.User.Password)
            .Required()
            .MatchesPassword();

        RuleFor(_ => _.User.ConfirmPassword)
            .Required()
            .EqualAuto(_ => _.User.Password);
    }
}
namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignupValidator : AbstractValidator<SignupCommand>
{
    public SignupValidator()
    {
        RuleFor(_ => _.User.FirstName)
            .Required()
            .MaximumLengthAuto(20)
            .MinimumLengthAuto(2);

        RuleFor(_ => _.User.MiddleName)
            .MaximumLengthAuto(20, _ => _.User.MiddleName.IsNotNullOrWhiteSpace())
            .MinimumLengthAuto(2, _ => _.User.MiddleName.IsNotNullOrWhiteSpace());

        RuleFor(_ => _.User.LastName)
            .Required()
            .MaximumLengthAuto(30)
            .MinimumLengthAuto(2);

        RuleFor(_ => _.User.Username)
            .Required()
            .MaximumLengthAuto(30)
            .MinimumLengthAuto(2);

        RuleFor(_ => _.User.Email)
            .Required()
            .EmailAddressAuto()
            .MaximumLengthAuto(100);

        RuleFor(_ => _.User.Password)
            .Required()
            .MatchesPassword();

        RuleFor(_ => _.User.ConfirmPassword)
             .Required()
             .EqualAuto(_ => _.User.Password);

        RuleFor(_ => _.User.DateOfBirth)
            .Required()
            .InValidRangeOfDate(toDate: Functions.MINIMUM_AGE, resourceValidation: ResourceValidation.Minimum_Age);

        RuleFor(_ => _.User.PhoneNumber)
            .Required()
            .MatchesPhone();
    }
}
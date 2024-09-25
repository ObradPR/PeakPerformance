namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class SignupValidator : AbstractValidator<SignupCommand>
{
    public SignupValidator()
    {
        RuleFor(_ => _.User.FirstName)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .MaximumLength(20)
            .WithMessageAuto(ResourceValidation.Maximum_Characters, "20")
            .MinimumLength(2)
            .WithMessageAuto(ResourceValidation.Minimum_Characters, "2");

        RuleFor(_ => _.User.MiddleName)
            .MaximumLength(20)
            .When(_ => !_.User.MiddleName.IsNullOrWhiteSpace())
            .WithMessageAuto(ResourceValidation.Maximum_Characters, "20")
            .MinimumLength(2)
            .When(_ => !_.User.MiddleName.IsNullOrWhiteSpace())
            .WithMessageAuto(ResourceValidation.Minimum_Characters, "2");

        RuleFor(_ => _.User.LastName)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .MaximumLength(30)
            .WithMessageAuto(ResourceValidation.Maximum_Characters, "30")
            .MinimumLength(2)
            .WithMessageAuto(ResourceValidation.Minimum_Characters, "2");

        RuleFor(_ => _.User.Username)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .MaximumLength(30)
            .WithMessageAuto(ResourceValidation.Maximum_Characters, "30")
            .MinimumLength(2)
            .WithMessageAuto(ResourceValidation.Minimum_Characters, "2");

        RuleFor(_ => _.User.Email)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .EmailAddress()
            .WithMessageAuto(ResourceValidation.Wrong_Format)
            .MaximumLength(100)
            .WithMessageAuto(ResourceValidation.Maximum_Characters, "100");

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

        RuleFor(_ => _.User.DateOfBirth)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .Must(_ => _.BeAtLeastEighteenYearsOld())
            .WithMessageAuto(ResourceValidation.Minimum_Age, "18");

        RuleFor(_ => _.User.PhoneNumber)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required)
            .Matches(Constants.REGEX_PHONE_NUMBER)
            .WithMessageAuto(ResourceValidation.Phone_Number);
    }
}
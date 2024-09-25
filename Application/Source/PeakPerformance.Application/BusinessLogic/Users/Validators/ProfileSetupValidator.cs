namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupValidator : AbstractValidator<ProfileSetupCommand>
{
    public ProfileSetupValidator()
    {
        RuleFor(_ => _.Settings.Weight.Weight)
            .GreaterThan(20)
            .When(_ => _.Settings.Weight.Weight.HasValue)
            .WithMessageAuto(ResourceValidation.Greater_Than, "20")
            .LessThan(1000)
            .When(_ => _.Settings.Weight.Weight.HasValue)
            .WithMessageAuto(ResourceValidation.Less_Than, "1000");

        RuleFor(_ => _.Settings.Weight.WeightUnitId)
            .NotEmpty()
            .WithMessageAuto(ResourceValidation.Required);

        RuleFor(_ => _.Settings.Weight.BodyFatPercentage)
            .GreaterThan(1)
            .When(_ => _.Settings.Weight.BodyFatPercentage.HasValue)
            .WithMessageAuto(ResourceValidation.Greater_Than, "1")
            .LessThan(1000)
            .When(_ => _.Settings.Weight.BodyFatPercentage.HasValue)
            .WithMessageAuto(ResourceValidation.Less_Than, "1000");

        //RuleFor
    }
}
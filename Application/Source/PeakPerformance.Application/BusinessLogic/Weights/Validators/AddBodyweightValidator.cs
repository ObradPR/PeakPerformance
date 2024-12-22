using PeakPerformance.Application.BusinessLogic.Weights.Commands;

namespace PeakPerformance.Application.BusinessLogic.Weights.Validators;

public class AddBodyweightValidator : AbstractValidator<AddBodyweightCommand>
{
    public AddBodyweightValidator()
    {
        RuleFor(_ => _.Data.Weight)
            .Required()
            .GreaterThanAuto(20)
            .LessThanAuto(1000);

        RuleFor(_ => _.Data.WeightUnitId)
            .Required()
            .IsInEnumAuto();

        RuleFor(_ => _.Data.BodyFatPercentage)
            .GreaterThanAuto(1, _ => _.Data.BodyFatPercentage.HasValue)
            .LessThanAuto(100, _ => _.Data.BodyFatPercentage.HasValue);
    }
}
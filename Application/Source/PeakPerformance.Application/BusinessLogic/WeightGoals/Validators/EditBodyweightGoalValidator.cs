using PeakPerformance.Application.BusinessLogic.WeightGoals.Commands;

namespace PeakPerformance.Application.BusinessLogic.WeightGoals.Validators;

public class EditBodyweightGoalValidator : AbstractValidator<EditBodyweightGoalCommand>
{
    public EditBodyweightGoalValidator()
    {
        RuleFor(_ => _.Data.TargetWeight)
            .Required()
            .GreaterThanAuto(20)
            .LessThanAuto(1000);

        RuleFor(_ => _.Data.StartDate)
            .Required()
            .InValidRangeOfDate(Functions.GOAL_START_DATE_EARLIEST, Functions.GOAL_START_DATE_LATEST);

        RuleFor(_ => _.Data.EndDate)
            .Required()
            .InValidRangeOfDate(fromDateFunc: _ => _.Data.StartDate);
    }
}
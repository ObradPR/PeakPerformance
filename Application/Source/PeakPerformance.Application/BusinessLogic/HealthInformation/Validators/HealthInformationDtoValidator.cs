using PeakPerformance.Application.Dtos.HealthInformation;

namespace PeakPerformance.Application.BusinessLogic.HealthInformation.Validators;

public class HealthInformationDtoValidator : AbstractValidator<HealthInformationDto>
{
    public HealthInformationDtoValidator()
    {
        RuleFor(_ => _.InjuryTypeId)
            .Required()
            .IsInEnumAuto();

        RuleFor(_ => _.Description).Required();

        RuleFor(_ => _.StartDate)
            .InValidRangeOfDate(Functions.INJURY_START_DATE_EARLIEST, Functions.INJURY_START_DATE_LATEST, _ => _.StartDate.HasValue);

        RuleFor(_ => _.EndDate)
            .InValidRangeOfDate(fromDateFunc: _ => _.StartDate, condition: _ => _.EndDate.HasValue);
    }
}
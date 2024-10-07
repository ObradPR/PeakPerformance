using HealthInformation_ = PeakPerformance.Domain.Entities.Application.HealthInformation;

namespace PeakPerformance.Application.Dtos.HealthInformation;

public class HealthInformationDto
{
    [Display(Name = "Injury type")]
    public eInjuryType InjuryTypeId { get; set; }

    [Display(Name = "description")]
    public string Description { get; set; }

    [Display(Name = "Start date")]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End date")]
    public DateTime? EndDate { get; set; }

    // methods

    public void ToModel(HealthInformation_ model, long userId)
    {
        model.UserId = userId;
        model.InjuryTypeId = InjuryTypeId;
        model.Description = Description;
        model.StartDate = StartDate;
        model.EndDate = EndDate;
    }
}
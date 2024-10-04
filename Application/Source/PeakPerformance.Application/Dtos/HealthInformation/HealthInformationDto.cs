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
}
namespace PeakPerformance.Application.Dtos.HealthInformation;

public class HealthInformationDto
{
    [Display(Name = "Injury Type")]
    public eInjuryType InjuryTypeId { get; set; }

    [Display(Name = "Description")]
    public string Description { get; set; }

    [Display(Name = "Start Date")]
    public DateTime? StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime? EndDate { get; set; }
}
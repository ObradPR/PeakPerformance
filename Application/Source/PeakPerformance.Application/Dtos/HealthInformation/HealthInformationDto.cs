namespace PeakPerformance.Application.Dtos.HealthInformation;

public class HealthInformationDto
{
    [Description("Injury Type")]
    public eInjuryType InjuryTypeId { get; set; }

    [Description("Description")]
    public string Description { get; set; } = string.Empty;

    [Description("Start Date")]
    public DateTime? StartDate { get; set; }

    [Description("End Date")]
    public DateTime? EndDate { get; set; }
}
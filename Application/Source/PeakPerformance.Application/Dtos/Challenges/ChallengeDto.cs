namespace PeakPerformance.Application.Dtos.Challenges;

public class ChallengeDto
{
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Display(Name = "Description")]
    public string Description { get; set; }

    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Max Participants")]
    public int? MaxParticipants { get; set; }

    [Display(Name = "Min Participants")]
    public int? MinParticipants { get; set; }

    [Display(Name = "Status Id")]
    public eChallengeStatus StatusId { get; set; }

    [Display(Name = "Approved By")]
    public long? ApprovedBy { get; set; }

    [Display(Name = "Approved On")]
    public DateTime? ApprovedOn { get; set; }

    [Display(Name = "Is Restricted")]
    public bool IsRestricted { get; set; } = false;
}
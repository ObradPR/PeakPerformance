using PeakPerformance.Domain.Enums.Attributes;
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

    public bool IsCondition { get; set; }

    // methods

    public void ToModel(HealthInformation_ model, long userId)
    {
        model.UserId = userId;
        model.InjuryTypeId = InjuryTypeId;
        model.Description = Description;
        model.StartDate = StartDate;
        model.EndDate = EndDate;

        model.IsCondition = InjuryClassification(InjuryTypeId);
    }

    public static bool InjuryClassification(eInjuryType injuryTypeId)
    {
        var type = typeof(eInjuryType);
        var memberInfo = type.GetMember(injuryTypeId.ToString()).FirstOrDefault();

        return memberInfo != null && memberInfo.GetCustomAttributes(typeof(ConditionAttribute), false).Length != 0;
    }
}
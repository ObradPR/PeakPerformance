using PeakPerformance.Application.Dtos.SocialMedia;

namespace PeakPerformance.Application.BusinessLogic.SocialMedia.Validators;

public class SocialMediaDtoValidator : AbstractValidator<SocialMediaDto>
{
    public SocialMediaDtoValidator()
    {
        RuleFor(_ => _.PlatformId)
            .Required()
            .IsInEnumAuto();

        RuleFor(_ => _.Link)
            .ValidSocialMediaLink(_ => _.PlatformId, _ => _.Link.IsNotNullOrWhiteSpace())
            .MaximumLengthAuto(255, _ => _.Link.IsNotNullOrWhiteSpace());

        RuleFor(_ => _.PhoneNumber)
            .MatchesPhone(_ => _.PhoneNumber.IsNotNullOrWhiteSpace())
            .MaximumLengthAuto(15, _ => _.PhoneNumber.IsNotNullOrWhiteSpace());
    }
}
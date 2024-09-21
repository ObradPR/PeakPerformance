using PeakPerformance.Application.Dtos.BodyFatGoals;
using PeakPerformance.Application.Dtos.BodyMeasurements;
using PeakPerformance.Application.Dtos.Users;
using PeakPerformance.Application.Dtos.UserTrainingGoals;
using PeakPerformance.Application.Dtos.WeightGoals;
using PeakPerformance.Application.Dtos.Weights;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupCommand(ProfileSetupDto settings) : BaseCommand
{
    public ProfileSetupDto Settings { get; set; } = settings;

    // Validators

    public class ProfileSetupValidator : AbstractValidator<ProfileSetupCommand>
    {
        public ProfileSetupValidator()
        {
            var weightDescriptions = Extensions.GetAllPropertyDescriptions<WeightDto>();
            var bodyMeasurementDescriptions = Extensions.GetAllPropertyDescriptions<BodyMeasurementDto>();
            var userTrainingGoalDescriptions = Extensions.GetAllPropertyDescriptions<UserTrainingGoalDto>();
            var weightGoalDescriptions = Extensions.GetAllPropertyDescriptions<WeightGoalDto>();
            var bodyFatGoalDescriptions = Extensions.GetAllPropertyDescriptions<BodyFatGoalDto>();

            RuleFor(_ => _.Settings.Weight.Weight)
                .GreaterThan(20)
                .When(_ => _.Settings.Weight.Weight.HasValue)
                .WithMessage(ResourceValidation.Greater_Than.AppendArgument(weightDescriptions[nameof(WeightDto.Weight)], "20"))
                .LessThan(1000)
                .When(_ => _.Settings.Weight.Weight.HasValue)
                .WithMessage(ResourceValidation.Less_Than.AppendArgument(weightDescriptions[nameof(WeightDto.Weight)], "1000"));

            RuleFor(_ => _.Settings.Weight.WeightUnitId)
                .NotEmpty()
                .WithMessage(ResourceValidation.Required.AppendArgument(weightDescriptions[nameof(WeightDto.Weight)]));

            RuleFor(_ => _.Settings.Weight.BodyFatPercentage)
                .GreaterThan(1)
                .When(_ => _.Settings.Weight.BodyFatPercentage.HasValue)
                .WithMessage(ResourceValidation.Greater_Than.AppendArgument(weightDescriptions[nameof(WeightDto.BodyFatPercentage)], "1"))
                .LessThan(1000)
                .When(_ => _.Settings.Weight.BodyFatPercentage.HasValue)
                .WithMessage(ResourceValidation.Less_Than.AppendArgument(weightDescriptions[nameof(WeightDto.BodyFatPercentage)], "1000"));

            RuleFor
        }
    }

    // Handlers

    public class ProfileSetupCommandHandler : BaseCommandHandler<ProfileSetupCommand>
    {
        public ProfileSetupCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser = null) : base(unitOfWork, identityUser)
        {
        }

        public override Task Handle(ProfileSetupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
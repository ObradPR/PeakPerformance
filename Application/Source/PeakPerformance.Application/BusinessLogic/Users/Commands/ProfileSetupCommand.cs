using PeakPerformance.Application.Dtos.Users;
using HealthInformation_ = PeakPerformance.Domain.Entities.Application.HealthInformation;
using SocialMedia_ = PeakPerformance.Domain.Entities.Application.SocialMedia;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupCommand(ProfileSetupDto data) : BaseCommand<Unit>
{
    public ProfileSetupDto Data { get; set; } = data;

    public class ProfileSetupCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser)
        : BaseCommandHandler<ProfileSetupCommand, Unit>(unitOfWork, identityUser)
    {
        public override async Task<Unit> Handle(ProfileSetupCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityUser.Id;
            var data = request.Data;

            // Measurement Preferences

            var userMeasurementPreferences = new UserMeasurementPreference()
            {
                UserId = userId,
                WeightUnitId = data.Weight.WeightUnitId,
                MeasurementUnitId = data.BodyMeasurement.MeasurementUnitId
            };
            await _unitOfWork.UserMeasurementPreferenceRepository.AddAsync(userMeasurementPreferences);

            // Weight

            if (data.Weight.Weight.HasValue)
            {
                var weight = new Weight();
                data.Weight.ToModel(weight, userId);
                await _unitOfWork.WeightRepository.AddAsync(weight);
            }

            // Body Measurement

            if (data.BodyMeasurement.HasAnyValue())
            {
                var bodyMeasurement = new BodyMeasurement();
                data.BodyMeasurement.ToModel(bodyMeasurement, userId);
                await _unitOfWork.BodyMeasurementRepository.AddAsync(bodyMeasurement);
            }

            // User Training Goal

            var trainingGoal = new UserTrainingGoal();
            data.UserTrainingGoal.ToModel(trainingGoal, userId);
            await _unitOfWork.UserTrainingGoalRepository.AddAsync(trainingGoal);

            // Weight Goal

            var weightGoal = new WeightGoal();
            data.WeightGoal.ToModel(weightGoal, userId);
            await _unitOfWork.WeightGoalRepository.AddAsync(weightGoal);

            // Body Fat Goal

            var bodyFatGoal = new BodyFatGoal();
            data.BodyFatGoal.ToModel(bodyFatGoal, userId);
            await _unitOfWork.BodyFatGoalRepository.AddAsync(bodyFatGoal);

            // IMAGE LOGIC UPLOADING TO CLOUDINARY

            // User Data

            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            user.Description = data.Description;

            // Social Media

            var socialMedia = data.SocialMedia
                .Select(_ =>
                {
                    var model = new SocialMedia_();
                    _.ToModel(model, userId);
                    return model;
                })
                .ToList();
            await _unitOfWork.SocialMediaRepository.AddRangeAsync(socialMedia);

            // Health Information

            var healthInformation = data.HealthInformation
                .Select(_ =>
                {
                    var model = new HealthInformation_();
                    _.ToModel(model, userId);
                    return model;
                })
                .ToList();
            await _unitOfWork.HealthInformationRepository.AddRangeAsync(healthInformation);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
using PeakPerformance.Application.Dtos.Emails;
using PeakPerformance.Application.Dtos.Users;
using PeakPerformance.Application.Interfaces;
using PeakPerformance.Infrastructure.Storage.Interfaces;
using HealthInformation_ = PeakPerformance.Domain.Entities.Application.HealthInformation;
using SocialMedia_ = PeakPerformance.Domain.Entities.Application.SocialMedia;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupCommand(ProfileSetupDto data) : BaseCommand<Unit>
{
    public ProfileSetupDto Data { get; set; } = data;

    public class ProfileSetupCommandHandler(IUnitOfWork unitOfWork, IIdentityUser identityUser, ICloudinaryService cloudinaryService, IEmailService emailService)
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
            data.WeightGoal.ToModel(weightGoal, data.Weight.WeightUnitId, userId);
            await _unitOfWork.WeightGoalRepository.AddAsync(weightGoal);

            // User Data

            var user = await _unitOfWork.UserRepository.GetSingleAsync(userId);
            user.Description = data.Description;
            user.ReceiveAppNews = data.ReceiveNews;

            if (data.ReceiveNews)
            {
                await emailService.SendEmailAsync(new EmailDto
                {
                    ToEmail = user.Email,
                    Subject = "News Subscription",
                    Body = $@"
                        <h2>Successfully Subscribed to PeakPerformance Updates!</h2>
                        <p>Hi {user.FullName},</p>
                        <p>Thank you for subscribing to our news updates! We’re excited to keep you in the loop with the latest on fitness, health tips, app updates, and exclusive content crafted just for our community.</p>

                        <p>Here’s what you can expect:</p>
                        <ul>
                            <li><strong>Fitness Tips:</strong> Professional advice to help you reach your goals.</li>
                            <li><strong>App Updates:</strong> Be the first to know about new features and improvements.</li>
                            <li><strong>Latest Blogs:</strong> Dive into articles on fitness, nutrition, and wellness.</li>
                        </ul>

                        <p>We’re here to support your fitness journey every step of the way!</p>

                        <p>Best regards,<br>The PeakPerformance Team</p>
                        <p><small>If you wish to unsubscribe at any time, you can do so from your profile settings.</small></p>"
                });
            }

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

            // Profile Picture

            var imageUploadResult = await cloudinaryService.UploadPhotoAsync(data.Image);

            if (imageUploadResult.Error != null)
                throw new UploadFileException(imageUploadResult.Error.Message);

            user.ProfilePictureUrl = imageUploadResult.SecureUrl.ToString();
            user.PublicId = imageUploadResult.PublicId;

            // Save

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
using PeakPerformance.Application.BusinessLogic.HealthInformation.Validators;
using PeakPerformance.Application.BusinessLogic.SocialMedia.Validators;

namespace PeakPerformance.Application.BusinessLogic.Users.Commands;

public class ProfileSetupValidator : AbstractValidator<ProfileSetupCommand>
{
    public ProfileSetupValidator()
    {
        #region Weight

        RuleFor(_ => _.Data.Weight.Weight)
            .GreaterThanAuto(20, _ => _.Data.Weight.Weight.HasValue)
            .LessThanAuto(1000, _ => _.Data.Weight.Weight.HasValue);

        RuleFor(_ => _.Data.Weight.WeightUnitId)
            .Required()
            .IsInEnumAuto();

        RuleFor(_ => _.Data.Weight.BodyFatPercentage)
            .GreaterThanAuto(1, _ => _.Data.Weight.BodyFatPercentage.HasValue)
            .LessThanAuto(100, _ => _.Data.Weight.BodyFatPercentage.HasValue); // Add MIGRATION for the configuration change

        #endregion Weight

        #region BodyMeasurement

        RuleFor(_ => _.Data.BodyMeasurement.Waist)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.Waist.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.Waist.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.Hips)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.Hips.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.Hips.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.Neck)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.Neck.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.Neck.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.Chest)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.Chest.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.Chest.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.Shoulders)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.Shoulders.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.Shoulders.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.RightBicep)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.RightBicep.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.RightBicep.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.LeftBicep)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.LeftBicep.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.LeftBicep.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.RightForearm)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.RightForearm.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.RightForearm.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.LeftForearm)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.LeftForearm.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.LeftForearm.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.RightThigh)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.RightThigh.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.RightThigh.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.LeftThigh)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.LeftThigh.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.LeftThigh.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.RightCalf)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.RightCalf.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.RightCalf.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.LeftCalf)
            .GreaterThanAuto(20, _ => _.Data.BodyMeasurement.LeftCalf.HasValue)
            .LessThanAuto(1000, _ => _.Data.BodyMeasurement.LeftCalf.HasValue);

        RuleFor(_ => _.Data.BodyMeasurement.MeasurementUnitId)
            .Required()
            .IsInEnumAuto();

        #endregion BodyMeasurement

        #region UserTrainingGoals

        RuleFor(_ => _.Data.UserTrainingGoal.TrainingGoalId)
            .Required()
            .IsInEnumAuto();

        RuleFor(_ => _.Data.UserTrainingGoal.StartDate)
            .Required()
            .InValidRangeOfDate(Functions.GOAL_START_DATE_EARLIEST, Functions.GOAL_START_DATE_LATEST);

        RuleFor(_ => _.Data.UserTrainingGoal.EndDate)
            .InValidRangeOfDate(fromDateFunc: _ => _.Data.UserTrainingGoal.StartDate, condition: _ => _.Data.UserTrainingGoal.EndDate.HasValue);

        #endregion UserTrainingGoals

        #region WeightGoal

        RuleFor(_ => _.Data.WeightGoal.TargetWeight)
            .Required()
            .GreaterThanAuto(20)
            .LessThanAuto(1000);

        RuleFor(_ => _.Data.WeightGoal.StartDate)
            .Required()
            .InValidRangeOfDate(Functions.GOAL_START_DATE_EARLIEST, Functions.GOAL_START_DATE_LATEST);

        RuleFor(_ => _.Data.WeightGoal.EndDate)
            .Required()
            .InValidRangeOfDate(fromDateFunc: _ => _.Data.WeightGoal.StartDate);

        #endregion WeightGoal

        #region BodyFatGoal

        RuleFor(_ => _.Data.BodyFatGoal.TargetBodyFatPercentage)
            .Required()
            .GreaterThanAuto(1)
            .LessThanAuto(100); // Migration needed

        RuleFor(_ => _.Data.BodyFatGoal.StartDate)
            .Required()
            .InValidRangeOfDate(Functions.GOAL_START_DATE_EARLIEST, Functions.GOAL_START_DATE_LATEST);

        RuleFor(_ => _.Data.BodyFatGoal.EndDate)
            .Required()
            .InValidRangeOfDate(fromDateFunc: _ => _.Data.BodyFatGoal.StartDate);

        #endregion BodyFatGoal

        #region UserData

        RuleFor(_ => _.Data.Image)
            .Required()
            .IsValidImage()
            .IsReasonableSize(Constants.IMAGE_MAX_SIZE_MB);

        RuleFor(_ => _.Data.Description).MaximumLengthAuto(500, _ => _.Data.Description.IsNotNullOrWhiteSpace());

        RuleForEach(_ => _.Data.SocialMedia).SetValidator(new SocialMediaDtoValidator());

        RuleForEach(_ => _.Data.HealthInformation).SetValidator(new HealthInformationDtoValidator());

        #endregion UserData
    }
}
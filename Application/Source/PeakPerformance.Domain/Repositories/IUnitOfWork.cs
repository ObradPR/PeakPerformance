using PeakPerformance.Domain.Repositories.Application;

namespace PeakPerformance.Domain.Repositories;

public interface IUnitOfWork
{
    // Repositories

    IErrorLogRepository ErrorLogRepository { get; }

    IUserRepository UserRepository { get; }

    IUserActivityLogRepository UserActivityLogRepository { get; }

    IUserMeasurementPreferenceRepository UserMeasurementPreferenceRepository { get; }

    IWeightRepository WeightRepository { get; }

    IBodyMeasurementRepository BodyMeasurementRepository { get; }

    IUserTrainingGoalRepository UserTrainingGoalRepository { get; }

    IWeightGoalRepository WeightGoalRepository { get; }

    IBodyFatGoalRepository BodyFatGoalRepository { get; }

    ISocialMediaRepository SocialMediaRepository { get; }

    IHealthInformationRepository HealthInformationRepository { get; }

    // Methods

    Task SaveAsync();
}
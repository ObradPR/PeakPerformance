using PeakPerformance.Common.Exceptions;

namespace PeakPerformance.Persistence.Repositories;

public class UnitOfWork(ApplicationDbContext context) : BaseRepository(context), IUnitOfWork
{
    // Repositories

    public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(db);

    public IUserRepository UserRepository => new UserRepository(db);

    public IUserActivityLogRepository UserActivityLogRepository => new UserActivityLogRepository(db);

    public IUserMeasurementPreferenceRepository UserMeasurementPreferenceRepository => new UserMeasurementPreferenceRepository(db);

    public IWeightRepository WeightRepository => new WeightRepository(db);

    public IBodyMeasurementRepository BodyMeasurementRepository => new BodyMeasurementRepository(db);

    public IUserTrainingGoalRepository UserTrainingGoalRepository => new UserTrainingGoalRepository(db);

    public IWeightGoalRepository WeightGoalRepository => new WeightGoalRepository(db);

    public IBodyFatGoalRepository BodyFatGoalRepository => new BodyFatGoalRepository(db);

    public ISocialMediaRepository SocialMediaRepository => new SocialMediaRepository(db);

    public IHealthInformationRepository HealthInformationRepository => new HealthInformationRepository(db);

    // Methods

    public async Task SaveAsync()
    {
        if (!(await db.SaveChangesAsync() > 0))
            throw new ServerErrorException();
    }
}
namespace PeakPerformance.Domain.Entities.Application_lu;

[Lookup]
public class TrainingGoal : BaseLookupDomain<TrainingGoal, eTrainingGoal>, IConfigurableEntity
{
    #region Relationships

    [InverseProperty(nameof(TrainingGoal))]
    public virtual ICollection<UserTrainingGoal> UserTrainingGoals { get; set; } = [];

    #endregion Relationships

    public void Configure(ModelBuilder builder) => builder.Entity<TrainingGoal>(ConfigureLookup);
}
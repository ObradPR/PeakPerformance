namespace PeakPerformance.Domain.Entities.Application;

public class Challenge : BaseIndexAuditedDomain<Challenge, long>, IConfigurableEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? MaxParticipants { get; set; }

    public int? MinParticipants { get; set; }

    public eChallengeStatus StatusId { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedOn { get; set; }

    public bool IsRestricted { get; set; } = false;

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(StatusId))]
    public virtual ChallengeStatus Status { get; set; }

    [InverseProperty(nameof(Challenge))]
    public virtual ICollection<ChallengeParticipant> ChallengeParticipants { get; set; } = [];

    #endregion Relationships

    //
    // Indexes
    //

    #region Indexes

    public static IDatabaseIndex IX_Challenges_StatusId_StartDate => new DatabaseIndex(nameof(IX_Challenges_StatusId_StartDate))
    {
        Columns = { nameof(StatusId), nameof(StartDate) }
    };

    #endregion Indexes

    //
    // Configuration
    //

    public void Configure(ModelBuilder builder)
    {
        builder.Entity<Challenge>(_ =>
        {
            _.Property(_ => _.Name).HasMaxLength(100).IsRequired();
            _.Property(_ => _.Description).IsRequired();
            _.Property(_ => _.StartDate).IsRequired();
            _.Property(_ => _.EndDate).IsRequired();
        });
    }
}

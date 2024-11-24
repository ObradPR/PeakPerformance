namespace PeakPerformance.Domain.Entities.Application;

public class ChallengeParticipant : BaseIndexAuditedDomain<ChallengeParticipant, long>
{
    public long ChallengeId { get; set; }

    public long UserId { get; set; }

    public string DetailsJson { get; set; }

    public eChallengeParticipantStatus StatusId { get; set; }

    public DateTime JoinedOn { get; set; }

    public DateTime? CompletedOn { get; set; }

    //
    // Relationships
    //

    #region Relationships

    [ForeignKey(nameof(ChallengeId))]
    public virtual Challenge Challenge { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(StatusId))]
    public virtual ChallengeParticipantStatus Status { get; set; }

    #endregion Relationships

    //
    // Indexes
    //

    #region Indexes

    public static IDatabaseIndex IX_ChallengeParticipants_ChallengeId_UserId => new DatabaseIndex(nameof(IX_ChallengeParticipants_ChallengeId_UserId))
    {
        Columns = { nameof(ChallengeId), nameof(UserId) },
        IsUnique = true
    };

    public static IDatabaseIndex IX_ChallengeParticipants_StatusId_CompletedOn => new DatabaseIndex(nameof(IX_ChallengeParticipants_StatusId_CompletedOn))
    {
        Columns = { nameof(StatusId), nameof(CompletedOn) }
    };

    #endregion Indexes
}
#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK64_ADD_Triggers_Indexes_Challenge_ChallengeParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // REMOVED in PEAK-82_AppSimplificatino // PRESERVED in dev_old

            // Audit triggers

            //migrationBuilder.CreateAuditTriggersForTable<Challenge_aud, Challenge>();
            //migrationBuilder.CreateAuditTriggersForTable<ChallengeParticipant_aud, ChallengeParticipant>();

            // Indexes
            //migrationBuilder.Up(Challenge.IX_Challenges_StatusId_StartDate);
            //migrationBuilder.Up(ChallengeParticipant.IX_ChallengeParticipants_ChallengeId_UserId);
            //migrationBuilder.Up(ChallengeParticipant.IX_ChallengeParticipants_StatusId_CompletedOn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Down(Challenge.IX_Challenges_StatusId_StartDate);
            //migrationBuilder.Down(ChallengeParticipant.IX_ChallengeParticipants_ChallengeId_UserId);
            //migrationBuilder.Down(ChallengeParticipant.IX_ChallengeParticipants_StatusId_CompletedOn);
        }
    }
}
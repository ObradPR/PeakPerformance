#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK64_SEED_Lookups_ChallengeStasus_ChallengeParticipantStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SeedLookupTable<ChallengeStatus, eChallengeStatus>();
            migrationBuilder.SeedLookupTable<ChallengeParticipantStatus, eChallengeParticipantStatus>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
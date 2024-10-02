#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_SEED_Lookups_SystemUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // New methods
            migrationBuilder.SeedLookupTable<SystemRole, eSystemRole>();
            migrationBuilder.SeedLookupTable<ActionType, eActionType>();
            migrationBuilder.SeedLookupTable<MeasurementUnit, eMeasurementUnit>();
            migrationBuilder.SeedLookupTable<TrainingGoal, eTrainingGoal>();
            migrationBuilder.SeedLookupTable<SocialMediaPlatform, eSocialMediaPlatform>();
            migrationBuilder.SeedLookupTable<InjuryType, eInjuryType>();

            migrationBuilder.CreateSystemUser();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
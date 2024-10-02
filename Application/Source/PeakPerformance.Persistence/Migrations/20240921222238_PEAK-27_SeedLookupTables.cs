#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_SeedLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inefficiency
            // Due to Name being rendered as first column the seed was broken
            // Ef core would reorder perfect insert with Name(cause its first) as ASCII
            // Moved to PEAK-27_SEED_Lookups_SystemUser

            //Extensions.Extensions.SeedLookupTable<SystemRole, eSystemRole>();
            //Extensions.Extensions.SeedLookupTable<ActionType, eActionType>();
            //Extensions.Extensions.SeedLookupTable<MeasurementUnit, eMeasurementUnit>();
            //Extensions.Extensions.SeedLookupTable<TrainingGoal, eTrainingGoal>();
            //Extensions.Extensions.SeedLookupTable<SocialMediaPlatform, eSocialMediaPlatform>();
            //Extensions.Extensions.SeedLookupTable<InjuryType, eInjuryType>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
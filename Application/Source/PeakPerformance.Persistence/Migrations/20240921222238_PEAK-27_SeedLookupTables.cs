using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Common.Enums;
using PeakPerformance.Domain.Entities.Application_lu;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_SeedLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Extensions.Extensions.SeedLookupTable<SystemRole, eSystemRole>();
            Extensions.Extensions.SeedLookupTable<ActionType, eActionType>();
            Extensions.Extensions.SeedLookupTable<MeasurementUnit, eMeasurementUnit>();
            Extensions.Extensions.SeedLookupTable<TrainingGoal, eTrainingGoal>();
            Extensions.Extensions.SeedLookupTable<SocialMediaPlatform, eSocialMediaPlatform>();
            Extensions.Extensions.SeedLookupTable<InjuryType, eInjuryType>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
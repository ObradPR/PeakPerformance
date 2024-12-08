#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK72_ADD_Columns_FK_to_Audits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingGoalId",
                schema: "dbo",
                table: "UserTrainingGoals_aud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InjuryTypeId",
                schema: "dbo",
                table: "HealthInformation_aud",
                type: "int",
                nullable: true);

            migrationBuilder.CreateAuditTriggersForTable<HealthInformation_aud, HealthInformation>();
            migrationBuilder.CreateAuditTriggersForTable<UserTrainingGoal_aud, UserTrainingGoal>();
            migrationBuilder.CreateAuditTriggersForTable<UserMeasurementPreference_aud, UserMeasurementPreference>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingGoalId",
                schema: "dbo",
                table: "UserTrainingGoals_aud");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud");

            migrationBuilder.DropColumn(
                name: "WeightUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud");

            migrationBuilder.DropColumn(
                name: "InjuryTypeId",
                schema: "dbo",
                table: "HealthInformation_aud");
        }
    }
}

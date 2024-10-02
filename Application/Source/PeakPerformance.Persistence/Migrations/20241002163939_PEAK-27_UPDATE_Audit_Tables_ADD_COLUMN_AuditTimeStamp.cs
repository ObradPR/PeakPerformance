#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_UPDATE_Audit_Tables_ADD_COLUMN_AuditTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "UserTrainingGoals_aud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "Users_aud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "UserRoles_aud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "HealthInformation_aud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateAuditTriggersForTable<User_aud, User>();
            migrationBuilder.CreateAuditTriggersForTable<UserRole_aud, UserRole>();
            migrationBuilder.CreateAuditTriggersForTable<UserMeasurementPreference_aud, UserMeasurementPreference>();
            migrationBuilder.CreateAuditTriggersForTable<UserTrainingGoal_aud, UserTrainingGoal>();
            migrationBuilder.CreateAuditTriggersForTable<HealthInformation_aud, HealthInformation>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "UserTrainingGoals_aud");

            migrationBuilder.DropColumn(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "Users_aud");

            migrationBuilder.DropColumn(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "UserRoles_aud");

            migrationBuilder.DropColumn(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud");

            migrationBuilder.DropColumn(
                name: "AuditTimeStamp",
                schema: "dbo",
                table: "HealthInformation_aud");
        }
    }
}
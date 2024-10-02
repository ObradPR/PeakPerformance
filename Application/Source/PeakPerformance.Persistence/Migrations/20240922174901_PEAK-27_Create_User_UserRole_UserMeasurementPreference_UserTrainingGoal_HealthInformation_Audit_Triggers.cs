#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_Create_User_UserRole_UserMeasurementPreference_UserTrainingGoal_HealthInformation_Audit_Triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Moved to later migration cause of the added columns within Audits
            // Moved to - PEAK-27_UPDATE_Audit_Tables_ADD_COLUMN_AuditTimeStamp

            //migrationBuilder.CreateAuditTriggersForTable<User_aud, User>();
            //migrationBuilder.CreateAuditTriggersForTable<UserRole_aud, UserRole>();
            //migrationBuilder.CreateAuditTriggersForTable<UserMeasurementPreference_aud, UserMeasurementPreference>();
            //migrationBuilder.CreateAuditTriggersForTable<UserTrainingGoal_aud, UserTrainingGoal>();
            //migrationBuilder.CreateAuditTriggersForTable<HealthInformation_aud, HealthInformation>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
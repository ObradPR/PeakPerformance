using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Domain.Entities.Audits;
using PeakPerformance.Persistence.Extensions;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_Create_User_UserRole_UserMeasurementPreference_UserTrainingGoal_HealthInformation_Audit_Triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateAuditTriggersForTable<User_aud, User>();
            migrationBuilder.CreateAuditTriggersForTable<UserRole_aud, UserRole>();
            migrationBuilder.CreateAuditTriggersForTable<UserMeasurementPreference_aud, UserMeasurementPreference>();
            migrationBuilder.CreateAuditTriggersForTable<UserTrainingGoal_aud, UserTrainingGoal>();
            migrationBuilder.CreateAuditTriggersForTable<HealthInformation_aud, HealthInformation>();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

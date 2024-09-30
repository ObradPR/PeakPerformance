using Microsoft.EntityFrameworkCore.Migrations;
using PeakPerformance.Domain.Entities.Application;
using PeakPerformance.Persistence.Extensions;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_CREATE_Indexes_User_UserMeasurementPreference_UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Up([User.IX_Users_Email, User.IX_Users_Username, User.IX_Users_Name_DOB]);
            migrationBuilder.Up(UserRole.IX_UserRoles_UserId_RoleId);
            migrationBuilder.Up(UserMeasurementPreference.IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Down([User.IX_Users_Email, User.IX_Users_Username, User.IX_Users_Name_DOB]);
            migrationBuilder.Down(UserRole.IX_UserRoles_UserId_RoleId);
            migrationBuilder.Down(UserMeasurementPreference.IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId);
        }
    }
}
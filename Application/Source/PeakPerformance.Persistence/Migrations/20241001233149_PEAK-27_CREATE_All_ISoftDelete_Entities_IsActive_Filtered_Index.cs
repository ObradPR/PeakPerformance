using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_CREATE_All_ISoftDelete_Entities_IsActive_Filtered_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Weights_IsActive",
                schema: "dbo",
                table: "Weights",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_WeightGoals_IsActive",
                schema: "dbo",
                table: "WeightGoals",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingGoals_IsActive",
                schema: "dbo",
                table: "UserTrainingGoals",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsActive",
                schema: "dbo",
                table: "Users",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IsActive",
                schema: "dbo",
                table: "UserRoles",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_IsActive",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_IsActive",
                schema: "dbo",
                table: "SocialMedia",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_IsActive",
                schema: "dbo",
                table: "HealthInformation",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_IsActive",
                schema: "dbo",
                table: "BodyMeasurements",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_BodyFatGoals_IsActive",
                schema: "dbo",
                table: "BodyFatGoals",
                column: "IsActive",
                filter: "[IsActive] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Weights_IsActive",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropIndex(
                name: "IX_WeightGoals_IsActive",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropIndex(
                name: "IX_UserTrainingGoals_IsActive",
                schema: "dbo",
                table: "UserTrainingGoals");

            migrationBuilder.DropIndex(
                name: "IX_Users_IsActive",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_IsActive",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserMeasurementPreferences_IsActive",
                schema: "dbo",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedia_IsActive",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropIndex(
                name: "IX_HealthInformation_IsActive",
                schema: "dbo",
                table: "HealthInformation");

            migrationBuilder.DropIndex(
                name: "IX_BodyMeasurements_IsActive",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropIndex(
                name: "IX_BodyFatGoals_IsActive",
                schema: "dbo",
                table: "BodyFatGoals");
        }
    }
}

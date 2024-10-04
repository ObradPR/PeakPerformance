#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_CREATE_Lost_in_Migrations_Lookup_Unique_Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_lu_Name",
                table: "ActionTypes_lu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_lu_Name",
                table: "SystemRoles_lu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
               name: "IX_InjuryTypes_lu_Name",
               table: "InjuryTypes_lu",
               column: "Name",
               unique: true);

            migrationBuilder.CreateIndex(
               name: "IX_MeasurementUnits_lu_Name",
               table: "MeasurementUnits_lu",
               column: "Name",
               unique: true);

            migrationBuilder.CreateIndex(
               name: "IX_SocialMediaPlatforms_lu_Name",
               table: "SocialMediaPlatforms_lu",
               column: "Name",
               unique: true);

            migrationBuilder.CreateIndex(
               name: "IX_TrainingGoals_lu_Name",
               table: "TrainingGoals_lu",
               column: "Name",
               unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

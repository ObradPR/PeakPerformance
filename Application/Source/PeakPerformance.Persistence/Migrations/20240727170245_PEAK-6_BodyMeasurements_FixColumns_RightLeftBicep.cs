using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK6_BodyMeasurements_FixColumns_RightLeftBicep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightBiceps",
                table: "BodyMeasurements",
                newName: "RightBicep");

            migrationBuilder.RenameColumn(
                name: "LeftBiceps",
                table: "BodyMeasurements",
                newName: "LeftBicep");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightBicep",
                table: "BodyMeasurements",
                newName: "RightBiceps");

            migrationBuilder.RenameColumn(
                name: "LeftBicep",
                table: "BodyMeasurements",
                newName: "LeftBiceps");
        }
    }
}

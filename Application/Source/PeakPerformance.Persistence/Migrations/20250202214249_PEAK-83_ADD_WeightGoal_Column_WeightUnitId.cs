#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK83_ADD_WeightGoal_Column_WeightUnitId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeightUnitId",
                schema: "dbo",
                table: "WeightGoals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeightGoals_WeightUnitId",
                schema: "dbo",
                table: "WeightGoals",
                column: "WeightUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeightGoals_MeasurementUnits_lu_WeightUnitId",
                schema: "dbo",
                table: "WeightGoals",
                column: "WeightUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeightGoals_MeasurementUnits_lu_WeightUnitId",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropIndex(
                name: "IX_WeightGoals_WeightUnitId",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "WeightUnitId",
                schema: "dbo",
                table: "WeightGoals");
        }
    }
}

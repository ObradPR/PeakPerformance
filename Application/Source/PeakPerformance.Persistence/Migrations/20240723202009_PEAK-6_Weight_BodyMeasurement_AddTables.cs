#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK6_Weight_BodyMeasurement_AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Waist = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Hips = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Neck = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Chest = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Shoulders = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RightBiceps = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    LeftBiceps = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RightForearm = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    LeftForearm = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RightThigh = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    LeftThigh = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RightCalf = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    LeftCalf = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BodyMeasurements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    WeightUnitId = table.Column<int>(type: "int", nullable: false),
                    BodyFatPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weights_MeasurementUnits_lu_WeightUnitId",
                        column: x => x.WeightUnitId,
                        principalTable: "MeasurementUnits_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weights_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_MeasurementUnitId",
                table: "BodyMeasurements",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurements_UserId",
                table: "BodyMeasurements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weights_UserId",
                table: "Weights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weights_WeightUnitId",
                table: "Weights",
                column: "WeightUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurements");

            migrationBuilder.DropTable(
                name: "Weights");
        }
    }
}
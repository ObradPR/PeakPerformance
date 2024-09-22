using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK6_UserMeasurementPreference_MeasurementUnit_AddTables_User_ReceiveNews_AddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveAppNews",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MeasurementUnits_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMeasurementPreferences_aud",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ActionTypeId = table.Column<int>(type: "int", nullable: true),
                    DetailsJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeasurementPreferences_aud", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes_lu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMeasurementPreferences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    WeightUnitId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeasurementPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId",
                        column: x => x.WeightUnitId,
                        principalTable: "MeasurementUnits_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMeasurementPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_lu_Name",
                table: "MeasurementUnits_lu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_MeasurementUnitId",
                table: "UserMeasurementPreferences",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId",
                table: "UserMeasurementPreferences",
                columns: new[] { "UserId", "WeightUnitId", "MeasurementUnitId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_WeightUnitId",
                table: "UserMeasurementPreferences",
                column: "WeightUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_aud_ActionTypeId",
                table: "UserMeasurementPreferences_aud",
                column: "ActionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMeasurementPreferences");

            migrationBuilder.DropTable(
                name: "UserMeasurementPreferences_aud");

            migrationBuilder.DropTable(
                name: "MeasurementUnits_lu");

            migrationBuilder.DropColumn(
                name: "ReceiveAppNews",
                table: "Users");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
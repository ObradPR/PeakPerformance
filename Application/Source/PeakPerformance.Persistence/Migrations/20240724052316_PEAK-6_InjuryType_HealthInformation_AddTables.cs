#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK6_InjuryType_HealthInformation_AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthInformation_aud",
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
                    table.PrimaryKey("PK_HealthInformation_aud", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes_lu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InjuryTypes_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuryTypes_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    InjuryTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId",
                        column: x => x.InjuryTypeId,
                        principalTable: "InjuryTypes_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthInformation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_InjuryTypeId",
                table: "HealthInformation",
                column: "InjuryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_UserId",
                table: "HealthInformation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthInformation_aud_ActionTypeId",
                table: "HealthInformation_aud",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuryTypes_lu_Name",
                table: "InjuryTypes_lu",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthInformation");

            migrationBuilder.DropTable(
                name: "HealthInformation_aud");

            migrationBuilder.DropTable(
                name: "InjuryTypes_lu");
        }
    }
}
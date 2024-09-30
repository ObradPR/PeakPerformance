#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK6_TrainingGoal_UserTrainingGoal_WeightGoal_BodyFatGoal_AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyFatGoals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TargetBodyFatPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyFatGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyFatGoals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGoals_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGoals_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTrainingGoals_aud",
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
                    table.PrimaryKey("PK_UserTrainingGoals_aud", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionTypes_lu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeightGoals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TargetWeight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightGoals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrainingGoals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    TrainingGoalId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_UserTrainingGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId",
                        column: x => x.TrainingGoalId,
                        principalTable: "TrainingGoals_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTrainingGoals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyFatGoals_UserId",
                table: "BodyFatGoals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoals_lu_Name",
                table: "TrainingGoals_lu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingGoals_TrainingGoalId",
                table: "UserTrainingGoals",
                column: "TrainingGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingGoals_UserId",
                table: "UserTrainingGoals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingGoals_aud_ActionTypeId",
                table: "UserTrainingGoals_aud",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightGoals_UserId",
                table: "WeightGoals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyFatGoals");

            migrationBuilder.DropTable(
                name: "UserTrainingGoals");

            migrationBuilder.DropTable(
                name: "UserTrainingGoals_aud");

            migrationBuilder.DropTable(
                name: "WeightGoals");

            migrationBuilder.DropTable(
                name: "TrainingGoals_lu");
        }
    }
}
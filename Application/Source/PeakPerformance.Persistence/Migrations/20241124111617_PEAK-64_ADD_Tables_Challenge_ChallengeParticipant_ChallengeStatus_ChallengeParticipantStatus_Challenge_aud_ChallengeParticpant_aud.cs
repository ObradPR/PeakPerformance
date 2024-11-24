#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK64_ADD_Tables_Challenge_ChallengeParticipant_ChallengeStatus_ChallengeParticipantStatus_Challenge_aud_ChallengeParticpant_aud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChallengeParticipants_aud",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AuditTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_ChallengeParticipants_aud", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipants_aud_ActionTypes_lu_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalSchema: "dbo",
                        principalTable: "ActionTypes_lu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChallengeParticipantStatuses_lu",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeParticipantStatuses_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges_aud",
                schema: "dbo",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AuditTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Challenges_aud", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_Challenges_aud_ActionTypes_lu_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalSchema: "dbo",
                        principalTable: "ActionTypes_lu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChallengeStatuses_lu",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeStatuses_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: true),
                    MinParticipants = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRestricted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_ChallengeStatuses_lu_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "ChallengeStatuses_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeParticipants",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DetailsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipants_ChallengeParticipantStatuses_lu_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "ChallengeParticipantStatuses_lu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipants_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalSchema: "dbo",
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_ChallengeId",
                schema: "dbo",
                table: "ChallengeParticipants",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_IsActive",
                schema: "dbo",
                table: "ChallengeParticipants",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_StatusId",
                schema: "dbo",
                table: "ChallengeParticipants",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_UserId",
                schema: "dbo",
                table: "ChallengeParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_aud_ActionTypeId",
                schema: "dbo",
                table: "ChallengeParticipants_aud",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipantStatuses_lu_Name",
                schema: "dbo",
                table: "ChallengeParticipantStatuses_lu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_IsActive",
                schema: "dbo",
                table: "Challenges",
                column: "IsActive",
                filter: "[IsActive] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_StatusId",
                schema: "dbo",
                table: "Challenges",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_aud_ActionTypeId",
                schema: "dbo",
                table: "Challenges_aud",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeStatuses_lu_Name",
                schema: "dbo",
                table: "ChallengeStatuses_lu",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ChallengeParticipants_aud",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Challenges_aud",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ChallengeParticipantStatuses_lu",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Challenges",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ChallengeStatuses_lu",
                schema: "dbo");
        }
    }
}

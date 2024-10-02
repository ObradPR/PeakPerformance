#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_FIX_Lookup_Values : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraints referencing ActionTypes_lu
            migrationBuilder.DropForeignKey(name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId", table: "HealthInformation_aud");
            migrationBuilder.DropForeignKey(name: "FK_Users_aud_ActionTypes_lu_ActionTypeId", table: "Users_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId", table: "UserMeasurementPreferences_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId", table: "UserRoles_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId", table: "UserTrainingGoals_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId", table: "UserActivityLogs");

            // Drop foreign key constraints referencing InjuryTypes_lu
            migrationBuilder.DropForeignKey(name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId", table: "HealthInformation");

            // Drop foreign key constraints referencing MeasurementUnits_lu
            migrationBuilder.DropForeignKey(name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId", table: "UserMeasurementPreferences");
            migrationBuilder.DropForeignKey(name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId", table: "UserMeasurementPreferences");
            migrationBuilder.DropForeignKey(name: "FK_Weights_MeasurementUnits_lu_WeightUnitId", table: "Weights");
            migrationBuilder.DropForeignKey(name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId", table: "BodyMeasurements");

            // Drop foreign key constraints referencing SocialMediaPlatforms_lu
            migrationBuilder.DropForeignKey(name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId", table: "SocialMedia");

            // Drop foreign key constraints referencing SystemRoles_lu
            migrationBuilder.DropForeignKey(name: "FK_UserRoles_SystemRoles_lu_RoleId", table: "UserRoles");

            // Drop foreign key constraints referencing TrainingGoals_lu
            migrationBuilder.DropForeignKey(name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId", table: "UserTrainingGoals");

            // Drop lookup tables
            migrationBuilder.DropTable(name: "ActionTypes_lu");
            migrationBuilder.DropTable(name: "InjuryTypes_lu");
            migrationBuilder.DropTable(name: "MeasurementUnits_lu");
            migrationBuilder.DropTable(name: "SocialMediaPlatforms_lu");
            migrationBuilder.DropTable(name: "SystemRoles_lu");
            migrationBuilder.DropTable(name: "TrainingGoals_lu");

            // Create lookup tables
            migrationBuilder.CreateTable(
                name: "ActionTypes_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes_lu", x => x.Id);
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
                name: "SocialMediaPlatforms_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaPlatforms_lu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles_lu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles_lu", x => x.Id);
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

            // Recreate foreign keys for ActionTypes
            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId",
                table: "HealthInformation_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_aud_ActionTypes_lu_ActionTypeId",
                table: "Users_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId",
                table: "UserMeasurementPreferences_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId",
                table: "UserRoles_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId",
                table: "UserTrainingGoals_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId",
                table: "UserActivityLogs",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            // Recreate foreign keys for InjuryTypes
            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId",
                table: "HealthInformation",
                column: "InjuryTypeId",
                principalTable: "InjuryTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            // Recreate foreign keys for MeasurementUnits
            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId",
                table: "UserMeasurementPreferences",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
               name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId",
               table: "UserMeasurementPreferences",
               column: "WeightUnitId",
               principalTable: "MeasurementUnits_lu",
               principalColumn: "Id",
               onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weights_MeasurementUnits_lu_WeightUnitId",
                table: "Weights",
                column: "WeightUnitId",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId",
                table: "BodyMeasurements",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            // Recreate foreign keys for SocialMediaPlatforms
            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId",
                table: "SocialMedia",
                column: "PlatformId",
                principalTable: "SocialMediaPlatforms_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            // Recreate foreign keys for SystemRoles
            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_SystemRoles_lu_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "SystemRoles_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            // Recreate foreign keys for TrainingGoals
            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId",
                table: "UserTrainingGoals",
                column: "TrainingGoalId",
                principalTable: "TrainingGoals_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId", table: "HealthInformation_aud");
            migrationBuilder.DropForeignKey(name: "FK_Users_aud_ActionTypes_lu_ActionTypeId", table: "Users_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId", table: "UserMeasurementPreferences_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId", table: "UserRoles_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId", table: "UserTrainingGoals_aud");
            migrationBuilder.DropForeignKey(name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId", table: "UserActivityLogs");
            migrationBuilder.DropForeignKey(name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId", table: "HealthInformation");
            migrationBuilder.DropForeignKey(name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId", table: "UserMeasurementPreferences");
            migrationBuilder.DropForeignKey(name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId", table: "UserMeasurementPreferences");
            migrationBuilder.DropForeignKey(name: "FK_Weights_MeasurementUnits_lu_WeightUnitId", table: "Weights");
            migrationBuilder.DropForeignKey(name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId", table: "BodyMeasurements");
            migrationBuilder.DropForeignKey(name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId", table: "SocialMedia");
            migrationBuilder.DropForeignKey(name: "FK_UserRoles_SystemRoles_lu_RoleId", table: "UserRoles");
            migrationBuilder.DropForeignKey(name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId", table: "UserTrainingGoals");

            // Drop lookup tables
            migrationBuilder.DropTable(name: "ActionTypes_lu");
            migrationBuilder.DropTable(name: "InjuryTypes_lu");
            migrationBuilder.DropTable(name: "MeasurementUnits_lu");
            migrationBuilder.DropTable(name: "SocialMediaPlatforms_lu");
            migrationBuilder.DropTable(name: "SystemRoles_lu");
            migrationBuilder.DropTable(name: "TrainingGoals_lu");
        }
    }
}
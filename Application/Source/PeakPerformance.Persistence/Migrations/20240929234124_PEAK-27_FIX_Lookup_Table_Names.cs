#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_FIX_Lookup_Table_Names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_MeasurementUnitId",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_InjuryTypes_InjuryTypeId",
                schema: "dbo",
                table: "HealthInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "HealthInformation_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_PlatformId",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_MeasurementUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_WeightUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_SystemRoles_RoleId",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserRoles_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "Users_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_TrainingGoalId",
                schema: "dbo",
                table: "UserTrainingGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserTrainingGoals_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_Weights_MeasurementUnits_WeightUnitId",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingGoals",
                schema: "dbo",
                table: "TrainingGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemRoles",
                schema: "dbo",
                table: "SystemRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMediaPlatforms",
                schema: "dbo",
                table: "SocialMediaPlatforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnits",
                schema: "dbo",
                table: "MeasurementUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InjuryTypes",
                schema: "dbo",
                table: "InjuryTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionTypes",
                schema: "dbo",
                table: "ActionTypes");

            migrationBuilder.RenameTable(
                name: "TrainingGoals",
                schema: "dbo",
                newName: "TrainingGoals_lu",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SystemRoles",
                schema: "dbo",
                newName: "SystemRoles_lu",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SocialMediaPlatforms",
                schema: "dbo",
                newName: "SocialMediaPlatforms_lu",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                schema: "dbo",
                newName: "MeasurementUnits_lu",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InjuryTypes",
                schema: "dbo",
                newName: "InjuryTypes_lu",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ActionTypes",
                schema: "dbo",
                newName: "ActionTypes_lu",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingGoals_Name",
                schema: "dbo",
                table: "TrainingGoals_lu",
                newName: "IX_TrainingGoals_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SystemRoles_Name",
                schema: "dbo",
                table: "SystemRoles_lu",
                newName: "IX_SystemRoles_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaPlatforms_Name",
                schema: "dbo",
                table: "SocialMediaPlatforms_lu",
                newName: "IX_SocialMediaPlatforms_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_MeasurementUnits_Name",
                schema: "dbo",
                table: "MeasurementUnits_lu",
                newName: "IX_MeasurementUnits_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_InjuryTypes_Name",
                schema: "dbo",
                table: "InjuryTypes_lu",
                newName: "IX_InjuryTypes_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_ActionTypes_Name",
                schema: "dbo",
                table: "ActionTypes_lu",
                newName: "IX_ActionTypes_lu_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingGoals_lu",
                schema: "dbo",
                table: "TrainingGoals_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemRoles_lu",
                schema: "dbo",
                table: "SystemRoles_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMediaPlatforms_lu",
                schema: "dbo",
                table: "SocialMediaPlatforms_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnits_lu",
                schema: "dbo",
                table: "MeasurementUnits_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InjuryTypes_lu",
                schema: "dbo",
                table: "InjuryTypes_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionTypes_lu",
                schema: "dbo",
                table: "ActionTypes_lu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId",
                schema: "dbo",
                table: "BodyMeasurements",
                column: "MeasurementUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId",
                schema: "dbo",
                table: "HealthInformation",
                column: "InjuryTypeId",
                principalSchema: "dbo",
                principalTable: "InjuryTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "HealthInformation_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId",
                schema: "dbo",
                table: "SocialMedia",
                column: "PlatformId",
                principalSchema: "dbo",
                principalTable: "SocialMediaPlatforms_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserActivityLogs",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "MeasurementUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "WeightUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_SystemRoles_lu_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "SystemRoles_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserRoles_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "Users_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId",
                schema: "dbo",
                table: "UserTrainingGoals",
                column: "TrainingGoalId",
                principalSchema: "dbo",
                principalTable: "TrainingGoals_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserTrainingGoals_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weights_MeasurementUnits_lu_WeightUnitId",
                schema: "dbo",
                table: "Weights",
                column: "WeightUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId",
                schema: "dbo",
                table: "HealthInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "HealthInformation_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_SystemRoles_lu_RoleId",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserRoles_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "Users_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId",
                schema: "dbo",
                table: "UserTrainingGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId",
                schema: "dbo",
                table: "UserTrainingGoals_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_Weights_MeasurementUnits_lu_WeightUnitId",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingGoals_lu",
                schema: "dbo",
                table: "TrainingGoals_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemRoles_lu",
                schema: "dbo",
                table: "SystemRoles_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMediaPlatforms_lu",
                schema: "dbo",
                table: "SocialMediaPlatforms_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnits_lu",
                schema: "dbo",
                table: "MeasurementUnits_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InjuryTypes_lu",
                schema: "dbo",
                table: "InjuryTypes_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionTypes_lu",
                schema: "dbo",
                table: "ActionTypes_lu");

            migrationBuilder.RenameTable(
                name: "TrainingGoals_lu",
                schema: "dbo",
                newName: "TrainingGoals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SystemRoles_lu",
                schema: "dbo",
                newName: "SystemRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SocialMediaPlatforms_lu",
                schema: "dbo",
                newName: "SocialMediaPlatforms",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits_lu",
                schema: "dbo",
                newName: "MeasurementUnits",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InjuryTypes_lu",
                schema: "dbo",
                newName: "InjuryTypes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ActionTypes_lu",
                schema: "dbo",
                newName: "ActionTypes",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingGoals_lu_Name",
                schema: "dbo",
                table: "TrainingGoals",
                newName: "IX_TrainingGoals_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SystemRoles_lu_Name",
                schema: "dbo",
                table: "SystemRoles",
                newName: "IX_SystemRoles_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaPlatforms_lu_Name",
                schema: "dbo",
                table: "SocialMediaPlatforms",
                newName: "IX_SocialMediaPlatforms_Name");

            migrationBuilder.RenameIndex(
                name: "IX_MeasurementUnits_lu_Name",
                schema: "dbo",
                table: "MeasurementUnits",
                newName: "IX_MeasurementUnits_Name");

            migrationBuilder.RenameIndex(
                name: "IX_InjuryTypes_lu_Name",
                schema: "dbo",
                table: "InjuryTypes",
                newName: "IX_InjuryTypes_Name");

            migrationBuilder.RenameIndex(
                name: "IX_ActionTypes_lu_Name",
                schema: "dbo",
                table: "ActionTypes",
                newName: "IX_ActionTypes_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingGoals",
                schema: "dbo",
                table: "TrainingGoals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemRoles",
                schema: "dbo",
                table: "SystemRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMediaPlatforms",
                schema: "dbo",
                table: "SocialMediaPlatforms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnits",
                schema: "dbo",
                table: "MeasurementUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InjuryTypes",
                schema: "dbo",
                table: "InjuryTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionTypes",
                schema: "dbo",
                table: "ActionTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_MeasurementUnitId",
                schema: "dbo",
                table: "BodyMeasurements",
                column: "MeasurementUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_InjuryTypes_InjuryTypeId",
                schema: "dbo",
                table: "HealthInformation",
                column: "InjuryTypeId",
                principalSchema: "dbo",
                principalTable: "InjuryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "HealthInformation_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_PlatformId",
                schema: "dbo",
                table: "SocialMedia",
                column: "PlatformId",
                principalSchema: "dbo",
                principalTable: "SocialMediaPlatforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserActivityLogs",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_MeasurementUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "MeasurementUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_WeightUnitId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "WeightUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_SystemRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "SystemRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserRoles_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "Users_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_TrainingGoalId",
                schema: "dbo",
                table: "UserTrainingGoals",
                column: "TrainingGoalId",
                principalSchema: "dbo",
                principalTable: "TrainingGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_ActionTypeId",
                schema: "dbo",
                table: "UserTrainingGoals_aud",
                column: "ActionTypeId",
                principalSchema: "dbo",
                principalTable: "ActionTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weights_MeasurementUnits_WeightUnitId",
                schema: "dbo",
                table: "Weights",
                column: "WeightUnitId",
                principalSchema: "dbo",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
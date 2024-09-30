using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_REFACTORED_Domain_Persistence_Approach_Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId",
                table: "BodyMeasurements");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId",
                table: "HealthInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_Users_UserId",
                table: "HealthInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId",
                table: "HealthInformation_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId",
                table: "SocialMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId",
                table: "UserActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_Users_UserId",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId",
                table: "UserMeasurementPreferences_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_SystemRoles_lu_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId",
                table: "UserRoles_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_aud_ActionTypes_lu_ActionTypeId",
                table: "Users_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId",
                table: "UserTrainingGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_Users_UserId",
                table: "UserTrainingGoals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId",
                table: "UserTrainingGoals_aud");

            migrationBuilder.DropForeignKey(
                name: "FK_Weights_MeasurementUnits_lu_WeightUnitId",
                table: "Weights");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FirstName_MiddleName_LastName",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingGoals_lu",
                table: "TrainingGoals_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemRoles_lu",
                table: "SystemRoles_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMediaPlatforms_lu",
                table: "SocialMediaPlatforms_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementUnits_lu",
                table: "MeasurementUnits_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InjuryTypes_lu",
                table: "InjuryTypes_lu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionTypes_lu",
                table: "ActionTypes_lu");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Weights",
                newName: "Weights",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "WeightGoals",
                newName: "WeightGoals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserTrainingGoals_aud",
                newName: "UserTrainingGoals_aud",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserTrainingGoals",
                newName: "UserTrainingGoals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Users_aud",
                newName: "Users_aud",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRoles_aud",
                newName: "UserRoles_aud",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserMeasurementPreferences_aud",
                newName: "UserMeasurementPreferences_aud",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserMeasurementPreferences",
                newName: "UserMeasurementPreferences",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserActivityLogs",
                newName: "UserActivityLogs",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SocialMedia",
                newName: "SocialMedia",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HealthInformation_aud",
                newName: "HealthInformation_aud",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HealthInformation",
                newName: "HealthInformation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ErrorLogs",
                newName: "ErrorLogs",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BodyMeasurements",
                newName: "BodyMeasurements",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BodyFatGoals",
                newName: "BodyFatGoals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "TrainingGoals_lu",
                newName: "TrainingGoals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SystemRoles_lu",
                newName: "SystemRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SocialMediaPlatforms_lu",
                newName: "SocialMediaPlatforms",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits_lu",
                newName: "MeasurementUnits",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InjuryTypes_lu",
                newName: "InjuryTypes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ActionTypes_lu",
                newName: "ActionTypes",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "Weights",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "WeightGoals",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "UserActivityLogs",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "SocialMedia",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "ErrorLogs",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "BodyMeasurements",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "BodyFatGoals",
                newName: "CreatedOn");

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

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "dbo",
                table: "UserTrainingGoals_aud",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "UserTrainingGoals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "UserTrainingGoals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "dbo",
                table: "Users_aud",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "dbo",
                table: "UserRoles_aud",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "UserRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "dbo",
                table: "UserMeasurementPreferences_aud",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "dbo",
                table: "HealthInformation_aud",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "HealthInformation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "HealthInformation",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "HealthInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "dbo",
            //    table: "TrainingGoals",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "TrainingGoals");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TrainingGoals",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "TrainingGoals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "dbo",
            //    table: "SystemRoles",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "SystemRoles");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SystemRoles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "SystemRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "dbo",
            //    table: "SocialMediaPlatforms",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "SocialMediaPlatforms");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SocialMediaPlatforms",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "SocialMediaPlatforms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "dbo",
            //    table: "MeasurementUnits",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "MeasurementUnits");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MeasurementUnits",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "MeasurementUnits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "dbo",
            //    table: "InjuryTypes",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "InjuryTypes");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InjuryTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "InjuryTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    schema: "dbo",
            //    table: "ActionTypes",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "ActionTypes");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActionTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "ActionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "dbo",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_UserId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "UserId");

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
                name: "FK_HealthInformation_Users_UserId",
                schema: "dbo",
                table: "HealthInformation",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_Users_UserId",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
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
                name: "FK_UserRoles_Users_UserId",
                schema: "dbo",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
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
                name: "FK_UserTrainingGoals_Users_UserId",
                schema: "dbo",
                table: "UserTrainingGoals",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_HealthInformation_Users_UserId",
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
                name: "FK_UserMeasurementPreferences_Users_UserId",
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
                name: "FK_UserRoles_Users_UserId",
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
                name: "FK_UserTrainingGoals_Users_UserId",
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

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserMeasurementPreferences_UserId",
                schema: "dbo",
                table: "UserMeasurementPreferences");

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

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "TrainingGoals");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "SocialMediaPlatforms");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "MeasurementUnits");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "InjuryTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "ActionTypes");

            migrationBuilder.RenameTable(
                name: "Weights",
                schema: "dbo",
                newName: "Weights");

            migrationBuilder.RenameTable(
                name: "WeightGoals",
                schema: "dbo",
                newName: "WeightGoals");

            migrationBuilder.RenameTable(
                name: "UserTrainingGoals_aud",
                schema: "dbo",
                newName: "UserTrainingGoals_aud");

            migrationBuilder.RenameTable(
                name: "UserTrainingGoals",
                schema: "dbo",
                newName: "UserTrainingGoals");

            migrationBuilder.RenameTable(
                name: "Users_aud",
                schema: "dbo",
                newName: "Users_aud");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles_aud",
                schema: "dbo",
                newName: "UserRoles_aud");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "dbo",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserMeasurementPreferences_aud",
                schema: "dbo",
                newName: "UserMeasurementPreferences_aud");

            migrationBuilder.RenameTable(
                name: "UserMeasurementPreferences",
                schema: "dbo",
                newName: "UserMeasurementPreferences");

            migrationBuilder.RenameTable(
                name: "UserActivityLogs",
                schema: "dbo",
                newName: "UserActivityLogs");

            migrationBuilder.RenameTable(
                name: "SocialMedia",
                schema: "dbo",
                newName: "SocialMedia");

            migrationBuilder.RenameTable(
                name: "HealthInformation_aud",
                schema: "dbo",
                newName: "HealthInformation_aud");

            migrationBuilder.RenameTable(
                name: "HealthInformation",
                schema: "dbo",
                newName: "HealthInformation");

            migrationBuilder.RenameTable(
                name: "ErrorLogs",
                schema: "dbo",
                newName: "ErrorLogs");

            migrationBuilder.RenameTable(
                name: "BodyMeasurements",
                schema: "dbo",
                newName: "BodyMeasurements");

            migrationBuilder.RenameTable(
                name: "BodyFatGoals",
                schema: "dbo",
                newName: "BodyFatGoals");

            migrationBuilder.RenameTable(
                name: "TrainingGoals",
                schema: "dbo",
                newName: "TrainingGoals_lu");

            migrationBuilder.RenameTable(
                name: "SystemRoles",
                schema: "dbo",
                newName: "SystemRoles_lu");

            migrationBuilder.RenameTable(
                name: "SocialMediaPlatforms",
                schema: "dbo",
                newName: "SocialMediaPlatforms_lu");

            migrationBuilder.RenameTable(
                name: "MeasurementUnits",
                schema: "dbo",
                newName: "MeasurementUnits_lu");

            migrationBuilder.RenameTable(
                name: "InjuryTypes",
                schema: "dbo",
                newName: "InjuryTypes_lu");

            migrationBuilder.RenameTable(
                name: "ActionTypes",
                schema: "dbo",
                newName: "ActionTypes_lu");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Weights",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "WeightGoals",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "UserActivityLogs",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "SocialMedia",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "ErrorLogs",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "BodyMeasurements",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "BodyFatGoals",
                newName: "RecordDate");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingGoals_Name",
                table: "TrainingGoals_lu",
                newName: "IX_TrainingGoals_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SystemRoles_Name",
                table: "SystemRoles_lu",
                newName: "IX_SystemRoles_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaPlatforms_Name",
                table: "SocialMediaPlatforms_lu",
                newName: "IX_SocialMediaPlatforms_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_MeasurementUnits_Name",
                table: "MeasurementUnits_lu",
                newName: "IX_MeasurementUnits_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_InjuryTypes_Name",
                table: "InjuryTypes_lu",
                newName: "IX_InjuryTypes_lu_Name");

            migrationBuilder.RenameIndex(
                name: "IX_ActionTypes_Name",
                table: "ActionTypes_lu",
                newName: "IX_ActionTypes_lu_Name");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UserTrainingGoals_aud",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserTrainingGoals",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserTrainingGoals",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Users_aud",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UserRoles_aud",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "UserMeasurementPreferences_aud",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserMeasurementPreferences",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserMeasurementPreferences",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "HealthInformation_aud",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "HealthInformation",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "HealthInformation",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "HealthInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "TrainingGoals_lu",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "SystemRoles_lu",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "SocialMediaPlatforms_lu",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "MeasurementUnits_lu",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "InjuryTypes_lu",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "ActionTypes_lu",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");
            migrationBuilder.DropColumn(name: "Id", table: "TrainingGoals_lu");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TrainingGoals_lu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "SystemRoles_lu");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SystemRoles_lu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "SocialMediaPlatforms_lu");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SocialMediaPlatforms_lu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "MeasurementUnits_lu");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MeasurementUnits_lu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "InjuryTypes_lu");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InjuryTypes_lu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.DropColumn(name: "Id", table: "ActionTypes_lu");
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActionTypes_lu",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingGoals_lu",
                table: "TrainingGoals_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemRoles_lu",
                table: "SystemRoles_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMediaPlatforms_lu",
                table: "SocialMediaPlatforms_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementUnits_lu",
                table: "MeasurementUnits_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InjuryTypes_lu",
                table: "InjuryTypes_lu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionTypes_lu",
                table: "ActionTypes_lu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstName_MiddleName_LastName",
                table: "Users",
                columns: new[] { "FirstName", "MiddleName", "LastName" })
                .Annotation("SqlServer:Include", new[] { "DateOfBirth" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId",
                table: "UserMeasurementPreferences",
                columns: new[] { "UserId", "WeightUnitId", "MeasurementUnitId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId",
                table: "BodyMeasurements",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_InjuryTypes_lu_InjuryTypeId",
                table: "HealthInformation",
                column: "InjuryTypeId",
                principalTable: "InjuryTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_Users_UserId",
                table: "HealthInformation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId",
                table: "HealthInformation_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId",
                table: "SocialMedia",
                column: "PlatformId",
                principalTable: "SocialMediaPlatforms_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivityLogs_ActionTypes_lu_ActionTypeId",
                table: "UserActivityLogs",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_UserMeasurementPreferences_Users_UserId",
                table: "UserMeasurementPreferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId",
                table: "UserMeasurementPreferences_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_SystemRoles_lu_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "SystemRoles_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_aud_ActionTypes_lu_ActionTypeId",
                table: "UserRoles_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_aud_ActionTypes_lu_ActionTypeId",
                table: "Users_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_TrainingGoals_lu_TrainingGoalId",
                table: "UserTrainingGoals",
                column: "TrainingGoalId",
                principalTable: "TrainingGoals_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_Users_UserId",
                table: "UserTrainingGoals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingGoals_aud_ActionTypes_lu_ActionTypeId",
                table: "UserTrainingGoals_aud",
                column: "ActionTypeId",
                principalTable: "ActionTypes_lu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weights_MeasurementUnits_lu_WeightUnitId",
                table: "Weights",
                column: "WeightUnitId",
                principalTable: "MeasurementUnits_lu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_UPDATE_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "TrainingGoals_lu");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "SystemRoles_lu");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "SocialMediaPlatforms_lu");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "MeasurementUnits_lu");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "InjuryTypes_lu");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "ActionTypes_lu");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "UserActivityLogs",
                newName: "RecordDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "ErrorLogs",
                newName: "RecordDate");

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Weights",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "dbo",
                table: "Weights",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "dbo",
                table: "Weights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Weights",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "dbo",
                table: "Weights",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "dbo",
                table: "Weights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "WeightGoals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "dbo",
                table: "WeightGoals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "dbo",
                table: "WeightGoals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "WeightGoals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "dbo",
                table: "WeightGoals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "dbo",
                table: "WeightGoals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "UserTrainingGoals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "UserRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "UserMeasurementPreferences",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "SocialMedia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "dbo",
                table: "SocialMedia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "dbo",
                table: "SocialMedia",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "SocialMedia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "dbo",
                table: "SocialMedia",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "dbo",
                table: "SocialMedia",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "HealthInformation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "BodyMeasurements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "dbo",
                table: "BodyMeasurements",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "dbo",
                table: "BodyMeasurements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "BodyMeasurements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "dbo",
                table: "BodyMeasurements",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "dbo",
                table: "BodyMeasurements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                schema: "dbo",
                table: "BodyFatGoals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeletedBy",
                schema: "dbo",
                table: "BodyFatGoals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "dbo",
                table: "BodyFatGoals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "BodyFatGoals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                schema: "dbo",
                table: "BodyFatGoals",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                schema: "dbo",
                table: "BodyFatGoals",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "dbo",
                table: "Weights");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "dbo",
                table: "WeightGoals");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "UserTrainingGoals");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "UserMeasurementPreferences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "dbo",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "HealthInformation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "dbo",
                table: "BodyMeasurements");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "dbo",
                table: "BodyFatGoals");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "dbo",
                table: "BodyFatGoals");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "dbo",
                table: "BodyFatGoals");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "BodyFatGoals");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "dbo",
                table: "BodyFatGoals");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                schema: "dbo",
                table: "BodyFatGoals");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "UserActivityLogs",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                schema: "dbo",
                table: "ErrorLogs",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "TrainingGoals_lu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "SystemRoles_lu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "SocialMediaPlatforms_lu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "MeasurementUnits_lu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "InjuryTypes_lu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "dbo",
                table: "ActionTypes_lu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

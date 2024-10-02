#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_CREATE_SystemUser_UPDATE_User_DateOfBirth_Type_To_Date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Down(User.IX_Users_Name_DOB);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.Up(User.IX_Users_Name_DOB);

            // Moved to PEAK-27_SEED_Lookups_SystemUser - due to fixing db
            //migrationBuilder.CreateSystemUser();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Down(User.IX_Users_Name_DOB);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
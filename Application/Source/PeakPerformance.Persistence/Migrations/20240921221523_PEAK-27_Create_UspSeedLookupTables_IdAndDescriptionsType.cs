#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PEAK27_Create_UspSeedLookupTables_IdAndDescriptionsType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTableValuedParameterType("IdAndDescriptionsType");
            migrationBuilder.CreateStoreProcedure("usp_SeedLookupTables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
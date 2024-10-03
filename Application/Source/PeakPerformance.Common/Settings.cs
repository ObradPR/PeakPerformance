namespace PeakPerformance.Common;

public class Settings
{
    // Connection String

    public const string ConnectionString = "Data Source = localhost; Initial Catalog = PeakPerformance; TrustServerCertificate = True; Integrated security = True;";

    // Store Procedures

    public const string usp_CreateAuditTrigger = "[dbo].[usp_CreateAuditTrigger]";
    public const string usp_SeedLookupTables = "[dbo].[usp_SeedLookupTables]";

    // Table Value Types

    /// <summary>
    /// Type for seeding enums into lookup tables
    /// </summary>
    public const string IdAndDescriptionsType = "[dbo].[IdAndDescriptionsType]";
}
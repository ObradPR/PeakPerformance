CREATE PROCEDURE [dbo].[usp_SeedLookupTables]
	@TableName NVARCHAR(255),
	@IdAndDescriptions [dbo].[IdAndDescriptionsType] READONLY
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Query NVARCHAR(MAX);

	-- Build dynamic SQL for inserting lookup values
    SET @Query = N'
    INSERT INTO ' + QUOTENAME(@TableName) + ' (Id, Name)
    SELECT Id, Name
    FROM @IdAndDescriptions AS t
    WHERE NOT EXISTS (
        SELECT 1 
        FROM ' + QUOTENAME(@TableName) + ' AS a
        WHERE a.Id = t.Id
    )
    ORDER BY Id;';

    -- Execute the dynamic SQL
    EXEC sp_executesql @Query, N'@IdAndDescriptions [dbo].[IdAndDescriptionsType] READONLY', @IdAndDescriptions;
END
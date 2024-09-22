CREATE PROCEDURE [dbo].[usp_CreateAuditTrigger]
    @TriggerName NVARCHAR(255),
    @TableName NVARCHAR(255),
    @AuditTableName NVARCHAR(255),
    @Columns NVARCHAR(MAX),
    @InsertValues NVARCHAR(MAX),
    @DeleteValues NVARCHAR(MAX),
    @CreateAction INT,
    @UpdateAction INT,
    @DeleteAction INT,
    @DeactivateAction INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = '
        CREATE TRIGGER ' + QUOTENAME(@TriggerName) + '
        ON ' + QUOTENAME(@TableName) + '
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;

            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                -- Handle INSERT and UPDATE
                INSERT INTO ' + QUOTENAME(@AuditTableName) + ' (' + @Columns + ', ActionTypeId, DetailsJson)
                SELECT
                    ' + @InsertValues + ',
                    CASE
                        WHEN EXISTS (SELECT * FROM deleted) THEN
                            CASE
                                WHEN i.IsActive = 0 AND d.IsActive = 1
                                    THEN ' + CAST(@DeactivateAction AS NVARCHAR) + '
                                ELSE ' + CAST(@UpdateAction AS NVARCHAR) + '
                            END
                        ELSE ' + CAST(@CreateAction AS NVARCHAR) + '
                    END,
                    (SELECT CAST((SELECT * FROM inserted i FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                FROM inserted i
                LEFT JOIN deleted d ON i.Id = d.Id
                WHERE i.Id IS NOT NULL;
            END
            ELSE IF EXISTS (SELECT * FROM deleted)
            BEGIN
                -- Handle DELETE
                INSERT INTO ' + QUOTENAME(@AuditTableName) + ' (' + @Columns + ', ActionTypeId, DetailsJson)
                SELECT
                    ' + @DeleteValues + ',
                    ' + CAST(@DeleteAction AS NVARCHAR) + ',
                    (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                FROM deleted d;
            END
        END
    ';

    EXEC sp_executesql @SQL;
END
GO
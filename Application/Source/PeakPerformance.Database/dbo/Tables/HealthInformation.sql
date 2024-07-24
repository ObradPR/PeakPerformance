CREATE TABLE [dbo].[HealthInformation] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]       BIGINT         NULL,
    [InjuryTypeId] INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [StartDate]    DATETIME2 (7)  NULL,
    [EndDate]      DATETIME2 (7)  NULL,
    [CreatedOn]    DATETIME2 (7)  NOT NULL,
    [ModifiedOn]   DATETIME2 (7)  NULL,
    [ModifiedBy]   BIGINT         NULL,
    [DeletedOn]    DATETIME2 (7)  NULL,
    [DeletedBy]    BIGINT         NULL,
    [IsActive]     BIT            DEFAULT (CONVERT([bit],(1))) NOT NULL,
    CONSTRAINT [PK_HealthInformation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HealthInformation_InjuryTypes_lu_InjuryTypeId] FOREIGN KEY ([InjuryTypeId]) REFERENCES [dbo].[InjuryTypes_lu] ([Id]),
    CONSTRAINT [FK_HealthInformation_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_HealthInformation_UserId]
    ON [dbo].[HealthInformation]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_HealthInformation_InjuryTypeId]
    ON [dbo].[HealthInformation]([InjuryTypeId] ASC);


GO

            CREATE TRIGGER trg_HealthInformation_aud
            ON HealthInformation
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    -- Handle INSERT and UPDATE
                    INSERT INTO HealthInformation_aud (Id,UserId,CreatedOn,ModifiedOn,ModifiedBy,DeletedOn,DeletedBy,IsActive, ActionTypeId, DetailsJson)
                    SELECT
                        i.Id,i.UserId,i.CreatedOn,i.ModifiedOn,i.ModifiedBy,i.DeletedOn,i.DeletedBy,i.IsActive,
                        CASE
                            WHEN EXISTS (SELECT * FROM deleted) THEN
                                CASE
                                    WHEN i.IsActive = 0 AND d.IsActive = 1
                                        THEN 4
                                    ELSE 2
                                END
                            ELSE 1
                        END,
                        (SELECT CAST((SELECT * FROM inserted i FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM inserted i
                    LEFT JOIN deleted d ON i.Id = d.Id
                    WHERE i.Id IS NOT NULL;
                END
                ELSE IF EXISTS (SELECT * FROM deleted)
                BEGIN
                    -- Handle DELETE
                    INSERT INTO HealthInformation_aud (Id,UserId,CreatedOn,ModifiedOn,ModifiedBy,DeletedOn,DeletedBy,IsActive, ActionTypeId, DetailsJson)
                    SELECT
                        d.Id,d.UserId,d.CreatedOn,d.ModifiedOn,d.ModifiedBy,d.DeletedOn,d.DeletedBy,d.IsActive,
                        3,
                        (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM deleted d;
                END
            END
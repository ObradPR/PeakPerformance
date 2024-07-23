CREATE TABLE [dbo].[UserMeasurementPreferences] (
    [Id]                BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]            BIGINT        NULL,
    [WeightUnitId]      INT           NOT NULL,
    [MeasurementUnitId] INT           NOT NULL,
    [CreatedOn]         DATETIME2 (7) NOT NULL,
    [ModifiedOn]        DATETIME2 (7) NULL,
    [ModifiedBy]        BIGINT        NULL,
    [DeletedOn]         DATETIME2 (7) NULL,
    [DeletedBy]         BIGINT        NULL,
    [IsActive]          BIT           DEFAULT (CONVERT([bit],(1))) NOT NULL,
    CONSTRAINT [PK_UserMeasurementPreferences] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserMeasurementPreferences_MeasurementUnits_lu_MeasurementUnitId] FOREIGN KEY ([MeasurementUnitId]) REFERENCES [dbo].[MeasurementUnits_lu] ([Id]),
    CONSTRAINT [FK_UserMeasurementPreferences_MeasurementUnits_lu_WeightUnitId] FOREIGN KEY ([WeightUnitId]) REFERENCES [dbo].[MeasurementUnits_lu] ([Id]),
    CONSTRAINT [FK_UserMeasurementPreferences_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_UserMeasurementPreferences_WeightUnitId]
    ON [dbo].[UserMeasurementPreferences]([WeightUnitId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserMeasurementPreferences_UserId_WeightUnitId_MeasurementUnitId]
    ON [dbo].[UserMeasurementPreferences]([UserId] ASC, [WeightUnitId] ASC, [MeasurementUnitId] ASC) WHERE ([UserId] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [IX_UserMeasurementPreferences_MeasurementUnitId]
    ON [dbo].[UserMeasurementPreferences]([MeasurementUnitId] ASC);


GO

            CREATE TRIGGER trg_UserMeasurementPreferences_aud
            ON UserMeasurementPreferences
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    -- Handle INSERT and UPDATE
                    INSERT INTO UserMeasurementPreferences_aud (Id,UserId,CreatedOn,ModifiedOn,ModifiedBy,DeletedOn,DeletedBy,IsActive, ActionTypeId, DetailsJson)
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
                    INSERT INTO UserMeasurementPreferences_aud (Id,UserId,CreatedOn,ModifiedOn,ModifiedBy,DeletedOn,DeletedBy,IsActive, ActionTypeId, DetailsJson)
                    SELECT
                        d.Id,d.UserId,d.CreatedOn,d.ModifiedOn,d.ModifiedBy,d.DeletedOn,d.DeletedBy,d.IsActive,
                        3,
                        (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX)))
                    FROM deleted d;
                END
            END
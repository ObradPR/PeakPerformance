CREATE TABLE [dbo].[Challenges] (
    [Id]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100) NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [StartDate]       DATETIME2 (7)  NOT NULL,
    [EndDate]         DATETIME2 (7)  NOT NULL,
    [MaxParticipants] INT            NULL,
    [MinParticipants] INT            NULL,
    [StatusId]        INT            NOT NULL,
    [ApprovedBy]      BIGINT         NULL,
    [ApprovedOn]      DATETIME2 (7)  NULL,
    [IsRestricted]    BIT            NOT NULL,
    [CreatedOn]       DATETIME2 (7)  NOT NULL,
    [CreatedBy]       BIGINT         NOT NULL,
    [ModifiedOn]      DATETIME2 (7)  NULL,
    [ModifiedBy]      BIGINT         NULL,
    [DeletedOn]       DATETIME2 (7)  NULL,
    [DeletedBy]       BIGINT         NULL,
    [IsActive]        BIT            NOT NULL,
    CONSTRAINT [PK_Challenges] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Challenges_ChallengeStatuses_lu_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[ChallengeStatuses_lu] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Challenges_StatusId_StartDate]
    ON [dbo].[Challenges]([StatusId] ASC, [StartDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Challenges_StatusId]
    ON [dbo].[Challenges]([StatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Challenges_IsActive]
    ON [dbo].[Challenges]([IsActive] ASC) WHERE ([IsActive]=(1));


GO

        CREATE TRIGGER [trg_Challenges_aud]
        ON [Challenges]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;

            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                -- Handle INSERT and UPDATE
                INSERT INTO [Challenges_aud] (CreatedBy, Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    i.CreatedBy, i.Id, i.CreatedOn, i.ModifiedOn, i.ModifiedBy, i.DeletedOn, i.DeletedBy, i.IsActive,
                    CASE
                        WHEN EXISTS (SELECT * FROM deleted) THEN
                            CASE
                                WHEN i.IsActive = 0 AND d.IsActive = 1
                                    THEN 4
                                ELSE 2
                            END
                        ELSE 1
                    END,
                    (SELECT CAST((SELECT * FROM inserted i FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX))),
                    GETUTCDATE()
                FROM inserted i
                LEFT JOIN deleted d ON i.Id = d.Id
                WHERE i.Id IS NOT NULL;
            END
            ELSE IF EXISTS (SELECT * FROM deleted)
            BEGIN
                -- Handle DELETE
                INSERT INTO [Challenges_aud] (CreatedBy, Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    d.CreatedBy, d.Id, d.CreatedOn, d.ModifiedOn, d.ModifiedBy, d.DeletedOn, d.DeletedBy, d.IsActive,
                    3,
                    (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX))),
                    GETUTCDATE()
                FROM deleted d;
            END
        END
CREATE TABLE [dbo].[ChallengeParticipants] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [ChallengeId] BIGINT         NOT NULL,
    [UserId]      BIGINT         NOT NULL,
    [DetailsJson] NVARCHAR (MAX) NULL,
    [StatusId]    INT            NOT NULL,
    [JoinedOn]    DATETIME2 (7)  NOT NULL,
    [CompletedOn] DATETIME2 (7)  NULL,
    [CreatedOn]   DATETIME2 (7)  NOT NULL,
    [CreatedBy]   BIGINT         NOT NULL,
    [ModifiedOn]  DATETIME2 (7)  NULL,
    [ModifiedBy]  BIGINT         NULL,
    [DeletedOn]   DATETIME2 (7)  NULL,
    [DeletedBy]   BIGINT         NULL,
    [IsActive]    BIT            NOT NULL,
    CONSTRAINT [PK_ChallengeParticipants] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChallengeParticipants_ChallengeParticipantStatuses_lu_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[ChallengeParticipantStatuses_lu] ([Id]),
    CONSTRAINT [FK_ChallengeParticipants_Challenges_ChallengeId] FOREIGN KEY ([ChallengeId]) REFERENCES [dbo].[Challenges] ([Id]),
    CONSTRAINT [FK_ChallengeParticipants_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ChallengeParticipants_StatusId_CompletedOn]
    ON [dbo].[ChallengeParticipants]([StatusId] ASC, [CompletedOn] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ChallengeParticipants_ChallengeId_UserId]
    ON [dbo].[ChallengeParticipants]([ChallengeId] ASC, [UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ChallengeParticipants_UserId]
    ON [dbo].[ChallengeParticipants]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ChallengeParticipants_StatusId]
    ON [dbo].[ChallengeParticipants]([StatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ChallengeParticipants_IsActive]
    ON [dbo].[ChallengeParticipants]([IsActive] ASC) WHERE ([IsActive]=(1));


GO
CREATE NONCLUSTERED INDEX [IX_ChallengeParticipants_ChallengeId]
    ON [dbo].[ChallengeParticipants]([ChallengeId] ASC);


GO

        CREATE TRIGGER [trg_ChallengeParticipants_aud]
        ON [ChallengeParticipants]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;

            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                -- Handle INSERT and UPDATE
                INSERT INTO [ChallengeParticipants_aud] (ChallengeId, UserId, Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    i.ChallengeId, i.UserId, i.Id, i.CreatedOn, i.ModifiedOn, i.ModifiedBy, i.DeletedOn, i.DeletedBy, i.IsActive,
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
                INSERT INTO [ChallengeParticipants_aud] (ChallengeId, UserId, Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    d.ChallengeId, d.UserId, d.Id, d.CreatedOn, d.ModifiedOn, d.ModifiedBy, d.DeletedOn, d.DeletedBy, d.IsActive,
                    3,
                    (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX))),
                    GETUTCDATE()
                FROM deleted d;
            END
        END
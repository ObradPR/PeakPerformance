CREATE TABLE [dbo].[UserRoles] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]     BIGINT        DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    [RoleId]     INT           NOT NULL,
    [CreatedOn]  DATETIME2 (7) NOT NULL,
    [ModifiedOn] DATETIME2 (7) NULL,
    [ModifiedBy] BIGINT        NULL,
    [DeletedOn]  DATETIME2 (7) NULL,
    [DeletedBy]  BIGINT        NULL,
    [IsActive]   BIT           NOT NULL,
    [CreatedBy]  BIGINT        DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserRoles_SystemRoles_lu_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[SystemRoles_lu] ([Id]),
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserRoles_UserId_RoleId]
    ON [dbo].[UserRoles]([UserId] ASC, [RoleId] ASC);




GO
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId]
    ON [dbo].[UserRoles]([RoleId] ASC);


GO

        CREATE TRIGGER [trg_UserRoles_aud]
        ON [UserRoles]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;

            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                -- Handle INSERT and UPDATE
                INSERT INTO [UserRoles_aud] (UserId, RoleId, Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    i.UserId, i.RoleId, i.Id, i.CreatedOn, i.ModifiedOn, i.ModifiedBy, i.DeletedOn, i.DeletedBy, i.IsActive,
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
                INSERT INTO [UserRoles_aud] (UserId, RoleId, Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    d.UserId, d.RoleId, d.Id, d.CreatedOn, d.ModifiedOn, d.ModifiedBy, d.DeletedOn, d.DeletedBy, d.IsActive,
                    3,
                    (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX))),
                    GETUTCDATE()
                FROM deleted d;
            END
        END
GO
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId]
    ON [dbo].[UserRoles]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserRoles_IsActive]
    ON [dbo].[UserRoles]([IsActive] ASC) WHERE ([IsActive]=(1));


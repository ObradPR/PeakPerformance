CREATE TABLE [dbo].[Users] (
    [Id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]         NVARCHAR (20)  NOT NULL,
    [MiddleName]        NVARCHAR (20)  NULL,
    [LastName]          NVARCHAR (30)  NOT NULL,
    [Username]          NVARCHAR (30)  NOT NULL,
    [Email]             NVARCHAR (100) NOT NULL,
    [Password]          NVARCHAR (MAX) NOT NULL,
    [DateOfBirth]       DATE           NOT NULL,
    [PhoneNumber]       NVARCHAR (15)  NOT NULL,
    [CreatedOn]         DATETIME2 (7)  NOT NULL,
    [ModifiedOn]        DATETIME2 (7)  NULL,
    [ModifiedBy]        BIGINT         NULL,
    [DeletedOn]         DATETIME2 (7)  NULL,
    [DeletedBy]         BIGINT         NULL,
    [IsActive]          BIT            NOT NULL,
    [ReceiveAppNews]    BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    [Description]       NVARCHAR (500) NULL,
    [CreatedBy]         BIGINT         DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    [ProfilePictureUrl] NVARCHAR (MAX) NULL,
    [PublicId]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username]
    ON [dbo].[Users]([Username] ASC);


GO



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email]
    ON [dbo].[Users]([Email] ASC);


GO

        CREATE TRIGGER [trg_Users_aud]
        ON [Users]
        AFTER INSERT, UPDATE, DELETE
        AS
        BEGIN
            SET NOCOUNT ON;

            IF EXISTS (SELECT * FROM inserted)
            BEGIN
                -- Handle INSERT and UPDATE
                INSERT INTO [Users_aud] (Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    i.Id, i.CreatedOn, i.ModifiedOn, i.ModifiedBy, i.DeletedOn, i.DeletedBy, i.IsActive,
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
                INSERT INTO [Users_aud] (Id, CreatedOn, ModifiedOn, ModifiedBy, DeletedOn, DeletedBy, IsActive, ActionTypeId, DetailsJson, AuditTimeStamp)
                SELECT
                    d.Id, d.CreatedOn, d.ModifiedOn, d.ModifiedBy, d.DeletedOn, d.DeletedBy, d.IsActive,
                    3,
                    (SELECT CAST((SELECT * FROM deleted d FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) AS NVARCHAR(MAX))),
                    GETUTCDATE()
                FROM deleted d;
            END
        END
GO
CREATE NONCLUSTERED INDEX [IX_Users_Name_DOB]
    ON [dbo].[Users]([FirstName] ASC, [MiddleName] ASC, [LastName] ASC)
    INCLUDE([DateOfBirth]);


GO
CREATE NONCLUSTERED INDEX [IX_Users_IsActive]
    ON [dbo].[Users]([IsActive] ASC) WHERE ([IsActive]=(1));


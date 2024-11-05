CREATE TABLE [dbo].[SocialMedia] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]      BIGINT         NOT NULL,
    [PlatformId]  INT            NOT NULL,
    [Link]        NVARCHAR (255) NULL,
    [CreatedOn]   DATETIME2 (7)  NOT NULL,
    [CreatedBy]   BIGINT         DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    [DeletedBy]   BIGINT         NULL,
    [DeletedOn]   DATETIME2 (7)  NULL,
    [IsActive]    BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    [ModifiedBy]  BIGINT         NULL,
    [ModifiedOn]  DATETIME2 (7)  NULL,
    [PhoneNumber] NVARCHAR (15)  NULL,
    CONSTRAINT [PK_SocialMedia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SocialMedia_SocialMediaPlatforms_lu_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[SocialMediaPlatforms_lu] ([Id]),
    CONSTRAINT [FK_SocialMedia_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_SocialMedia_UserId]
    ON [dbo].[SocialMedia]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SocialMedia_PlatformId]
    ON [dbo].[SocialMedia]([PlatformId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SocialMedia_IsActive]
    ON [dbo].[SocialMedia]([IsActive] ASC) WHERE ([IsActive]=(1));


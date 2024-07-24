CREATE TABLE [dbo].[SocialMedia] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]     BIGINT         NOT NULL,
    [PlatformId] INT            NOT NULL,
    [Link]       NVARCHAR (255) NOT NULL,
    [RecordDate] DATETIME2 (7)  NOT NULL,
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


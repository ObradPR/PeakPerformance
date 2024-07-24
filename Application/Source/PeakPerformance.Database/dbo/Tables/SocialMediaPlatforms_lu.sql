CREATE TABLE [dbo].[SocialMediaPlatforms_lu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_SocialMediaPlatforms_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SocialMediaPlatforms_lu_Name]
    ON [dbo].[SocialMediaPlatforms_lu]([Name] ASC);


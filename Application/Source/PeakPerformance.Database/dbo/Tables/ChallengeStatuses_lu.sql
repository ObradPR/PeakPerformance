CREATE TABLE [dbo].[ChallengeStatuses_lu] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_ChallengeStatuses_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ChallengeStatuses_lu_Name]
    ON [dbo].[ChallengeStatuses_lu]([Name] ASC);


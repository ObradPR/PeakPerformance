CREATE TABLE [dbo].[ChallengeParticipantStatuses_lu] (
    [Id]   INT           NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_ChallengeParticipantStatuses_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ChallengeParticipantStatuses_lu_Name]
    ON [dbo].[ChallengeParticipantStatuses_lu]([Name] ASC);


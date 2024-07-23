CREATE TABLE [dbo].[BodyFatGoals] (
    [Id]                      BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]                  BIGINT         NOT NULL,
    [TargetBodyFatPercentage] DECIMAL (5, 2) NOT NULL,
    [StartDate]               DATETIME2 (7)  NOT NULL,
    [EndDate]                 DATETIME2 (7)  NOT NULL,
    [RecordDate]              DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_BodyFatGoals] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BodyFatGoals_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BodyFatGoals_UserId]
    ON [dbo].[BodyFatGoals]([UserId] ASC);


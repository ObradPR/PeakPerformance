CREATE TABLE [dbo].[BodyFatGoals] (
    [Id]                      BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]                  BIGINT         NOT NULL,
    [TargetBodyFatPercentage] DECIMAL (4, 2) NOT NULL,
    [StartDate]               DATE           NOT NULL,
    [EndDate]                 DATE           NOT NULL,
    [CreatedOn]               DATETIME2 (7)  NOT NULL,
    [CreatedBy]               BIGINT         DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    [DeletedBy]               BIGINT         NULL,
    [DeletedOn]               DATETIME2 (7)  NULL,
    [IsActive]                BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    [ModifiedBy]              BIGINT         NULL,
    [ModifiedOn]              DATETIME2 (7)  NULL,
    CONSTRAINT [PK_BodyFatGoals] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BodyFatGoals_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_BodyFatGoals_UserId]
    ON [dbo].[BodyFatGoals]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BodyFatGoals_IsActive]
    ON [dbo].[BodyFatGoals]([IsActive] ASC) WHERE ([IsActive]=(1));


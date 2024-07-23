CREATE TABLE [dbo].[UserActivityLogs] (
    [Id]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]       BIGINT        NOT NULL,
    [ActionTypeId] INT           NOT NULL,
    [RecordDate]   DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_UserActivityLogs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserActivityLogs_ActionTypes_lu_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes_lu] ([Id]),
    CONSTRAINT [FK_UserActivityLogs_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserActivityLogs_UserId]
    ON [dbo].[UserActivityLogs]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserActivityLogs_ActionTypeId]
    ON [dbo].[UserActivityLogs]([ActionTypeId] ASC);


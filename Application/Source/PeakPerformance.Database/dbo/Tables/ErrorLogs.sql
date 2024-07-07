CREATE TABLE [dbo].[ErrorLogs] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [Message]        NVARCHAR (MAX) NOT NULL,
    [StackTrace]     NVARCHAR (MAX) NULL,
    [InnerException] NVARCHAR (MAX) NULL,
    [RecordDate]     DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_ErrorLogs] PRIMARY KEY CLUSTERED ([Id] ASC)
);


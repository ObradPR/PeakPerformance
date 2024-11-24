CREATE TABLE [dbo].[Challenges_aud] (
    [AuditId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreatedBy]      BIGINT         NULL,
    [Id]             BIGINT         NOT NULL,
    [AuditTimeStamp] DATETIME2 (7)  NOT NULL,
    [CreatedOn]      DATETIME2 (7)  NULL,
    [ModifiedOn]     DATETIME2 (7)  NULL,
    [ModifiedBy]     BIGINT         NULL,
    [DeletedOn]      DATETIME2 (7)  NULL,
    [DeletedBy]      BIGINT         NULL,
    [IsActive]       BIT            NULL,
    [ActionTypeId]   INT            NULL,
    [DetailsJson]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Challenges_aud] PRIMARY KEY CLUSTERED ([AuditId] ASC),
    CONSTRAINT [FK_Challenges_aud_ActionTypes_lu_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes_lu] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Challenges_aud_ActionTypeId]
    ON [dbo].[Challenges_aud]([ActionTypeId] ASC);


CREATE TABLE [dbo].[HealthInformation_aud] (
    [AuditId]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [Id]           BIGINT         NULL,
    [UserId]       BIGINT         NULL,
    [CreatedOn]    DATETIME2 (7)  NULL,
    [ModifiedOn]   DATETIME2 (7)  NULL,
    [ModifiedBy]   BIGINT         NULL,
    [DeletedOn]    DATETIME2 (7)  NULL,
    [DeletedBy]    BIGINT         NULL,
    [IsActive]     BIT            NULL,
    [ActionTypeId] INT            NULL,
    [DetailsJson]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_HealthInformation_aud] PRIMARY KEY CLUSTERED ([AuditId] ASC),
    CONSTRAINT [FK_HealthInformation_aud_ActionTypes_lu_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes_lu] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_HealthInformation_aud_ActionTypeId]
    ON [dbo].[HealthInformation_aud]([ActionTypeId] ASC);


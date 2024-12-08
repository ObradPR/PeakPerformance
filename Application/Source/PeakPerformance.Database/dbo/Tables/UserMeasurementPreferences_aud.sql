CREATE TABLE [dbo].[UserMeasurementPreferences_aud] (
    [AuditId]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Id]                BIGINT         DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    [UserId]            BIGINT         NULL,
    [CreatedOn]         DATETIME2 (7)  NULL,
    [ModifiedOn]        DATETIME2 (7)  NULL,
    [ModifiedBy]        BIGINT         NULL,
    [DeletedOn]         DATETIME2 (7)  NULL,
    [DeletedBy]         BIGINT         NULL,
    [IsActive]          BIT            NULL,
    [ActionTypeId]      INT            NULL,
    [DetailsJson]       NVARCHAR (MAX) NULL,
    [AuditTimeStamp]    DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [MeasurementUnitId] INT            NULL,
    [WeightUnitId]      INT            NULL,
    CONSTRAINT [PK_UserMeasurementPreferences_aud] PRIMARY KEY CLUSTERED ([AuditId] ASC),
    CONSTRAINT [FK_UserMeasurementPreferences_aud_ActionTypes_lu_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes_lu] ([Id])
);






GO
CREATE NONCLUSTERED INDEX [IX_UserMeasurementPreferences_aud_ActionTypeId]
    ON [dbo].[UserMeasurementPreferences_aud]([ActionTypeId] ASC);


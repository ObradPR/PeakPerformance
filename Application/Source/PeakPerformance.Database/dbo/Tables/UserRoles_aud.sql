﻿CREATE TABLE [dbo].[UserRoles_aud] (
    [AuditId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Id]             BIGINT         DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    [UserId]         BIGINT         NULL,
    [RoleId]         INT            NULL,
    [CreatedOn]      DATETIME2 (7)  NULL,
    [ModifiedOn]     DATETIME2 (7)  NULL,
    [ModifiedBy]     BIGINT         NULL,
    [DeletedOn]      DATETIME2 (7)  NULL,
    [DeletedBy]      BIGINT         NULL,
    [IsActive]       BIT            NULL,
    [ActionTypeId]   INT            NULL,
    [DetailsJson]    NVARCHAR (MAX) NULL,
    [AuditTimeStamp] DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    CONSTRAINT [PK_UserRoles_aud] PRIMARY KEY CLUSTERED ([AuditId] ASC),
    CONSTRAINT [FK_UserRoles_aud_ActionTypes_lu_ActionTypeId] FOREIGN KEY ([ActionTypeId]) REFERENCES [dbo].[ActionTypes_lu] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_UserRoles_aud_ActionTypeId]
    ON [dbo].[UserRoles_aud]([ActionTypeId] ASC);


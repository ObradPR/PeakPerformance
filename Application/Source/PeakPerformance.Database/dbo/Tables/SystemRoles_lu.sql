CREATE TABLE [dbo].[SystemRoles_lu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_SystemRoles_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemRoles_lu_Name]
    ON [dbo].[SystemRoles_lu]([Name] ASC);




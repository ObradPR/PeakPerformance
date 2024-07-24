CREATE TABLE [dbo].[InjuryTypes_lu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_InjuryTypes_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_InjuryTypes_lu_Name]
    ON [dbo].[InjuryTypes_lu]([Name] ASC);


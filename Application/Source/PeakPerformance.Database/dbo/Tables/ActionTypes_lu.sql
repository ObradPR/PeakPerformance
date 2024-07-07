CREATE TABLE [dbo].[ActionTypes_lu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_ActionTypes_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ActionTypes_lu_Name]
    ON [dbo].[ActionTypes_lu]([Name] ASC) WHERE ([Name] IS NOT NULL);


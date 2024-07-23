CREATE TABLE [dbo].[TrainingGoals_lu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_TrainingGoals_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TrainingGoals_lu_Name]
    ON [dbo].[TrainingGoals_lu]([Name] ASC);


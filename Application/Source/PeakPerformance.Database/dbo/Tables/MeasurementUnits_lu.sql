CREATE TABLE [dbo].[MeasurementUnits_lu] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_MeasurementUnits_lu] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MeasurementUnits_lu_Name]
    ON [dbo].[MeasurementUnits_lu]([Name] ASC);


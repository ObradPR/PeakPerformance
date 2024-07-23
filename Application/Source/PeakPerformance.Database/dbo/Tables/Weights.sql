CREATE TABLE [dbo].[Weights] (
    [Id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]            BIGINT         NOT NULL,
    [Value]             DECIMAL (5, 2) NOT NULL,
    [WeightUnitId]      INT            NOT NULL,
    [BodyFatPercentage] DECIMAL (5, 2) NULL,
    [RecordDate]        DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Weights] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Weights_MeasurementUnits_lu_WeightUnitId] FOREIGN KEY ([WeightUnitId]) REFERENCES [dbo].[MeasurementUnits_lu] ([Id]),
    CONSTRAINT [FK_Weights_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Weights_WeightUnitId]
    ON [dbo].[Weights]([WeightUnitId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Weights_UserId]
    ON [dbo].[Weights]([UserId] ASC);


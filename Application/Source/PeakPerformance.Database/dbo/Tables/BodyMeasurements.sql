CREATE TABLE [dbo].[BodyMeasurements] (
    [Id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]            BIGINT         NOT NULL,
    [Waist]             DECIMAL (5, 2) NULL,
    [Hips]              DECIMAL (5, 2) NULL,
    [Neck]              DECIMAL (5, 2) NULL,
    [Chest]             DECIMAL (5, 2) NULL,
    [Shoulders]         DECIMAL (5, 2) NULL,
    [RightBiceps]       DECIMAL (5, 2) NULL,
    [LeftBiceps]        DECIMAL (5, 2) NULL,
    [RightForearm]      DECIMAL (5, 2) NULL,
    [LeftForearm]       DECIMAL (5, 2) NULL,
    [RightThigh]        DECIMAL (5, 2) NULL,
    [LeftThigh]         DECIMAL (5, 2) NULL,
    [RightCalf]         DECIMAL (5, 2) NULL,
    [LeftCalf]          DECIMAL (5, 2) NULL,
    [MeasurementUnitId] INT            NOT NULL,
    [RecordDate]        DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_BodyMeasurements] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BodyMeasurements_MeasurementUnits_lu_MeasurementUnitId] FOREIGN KEY ([MeasurementUnitId]) REFERENCES [dbo].[MeasurementUnits_lu] ([Id]),
    CONSTRAINT [FK_BodyMeasurements_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BodyMeasurements_UserId]
    ON [dbo].[BodyMeasurements]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BodyMeasurements_MeasurementUnitId]
    ON [dbo].[BodyMeasurements]([MeasurementUnitId] ASC);


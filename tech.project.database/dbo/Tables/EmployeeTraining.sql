CREATE TABLE [dbo].[EmployeeTraining] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [TrainingId] UNIQUEIDENTIFIER NOT NULL,
    [AttendDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[EmployeeTraining] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [TrainingId] UNIQUEIDENTIFIER NOT NULL,
    [AttendDate] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_EmployeeTraining_ToEmployee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_EmployeeTraining_ToTraining] FOREIGN KEY ([TrainingId]) REFERENCES [Training]([Id])
);


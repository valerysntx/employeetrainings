CREATE TABLE [dbo].[Employee] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (MAX)   NOT NULL,
    [Surname]   NVARCHAR (MAX)   NOT NULL,
    [Birthdate] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


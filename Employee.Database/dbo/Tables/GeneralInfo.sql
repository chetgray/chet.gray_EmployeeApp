CREATE TABLE [dbo].[GeneralInfo] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]             NVARCHAR (255) NULL,
    [MiddleName]            NVARCHAR (255) NULL,
    [LastName]              NVARCHAR (255) NULL,
    [Date of Birth]         NVARCHAR (255) NULL,
    [Employment Start Date] NVARCHAR (255) NULL,
    [Employment End Date]   NVARCHAR (255) NULL,
    [Address_ID]            INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Address_ID]) REFERENCES [dbo].[Address] ([Address_ID])
);


CREATE TABLE [dbo].[Address] (
    [Address_ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Street Address] NVARCHAR (255) NULL,
    [City]           NVARCHAR (255) NULL,
    [State]          NVARCHAR (255) NULL,
    [Zip]            VARCHAR (9)    NULL,
    PRIMARY KEY CLUSTERED ([Address_ID] ASC)
);


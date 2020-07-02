CREATE TABLE [dbo].[UserRegistration] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (50) NULL,
    [Username]     VARCHAR (50) NOT NULL,
    [Password]     VARCHAR (50) NOT NULL,
    [Gender]       VARCHAR (50) NULL,
    [City]         VARCHAR (50) NULL,
    [Email]        VARCHAR (50) UNIQUE NOT NULL,
    [CreatedDate]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


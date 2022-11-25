CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(150) NOT NULL, 
    [Password] NVARCHAR(150) NOT NULL, 
    [BirthDay] DATETIME NULL, 
    [Address] NVARCHAR(250) NULL, 
    [Email] NVARCHAR(250) NULL, 
    [Age] INT NULL, 
    [Gender] BIT NULL
)

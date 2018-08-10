CREATE TABLE [dbo].[Search Result]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Search file Result] NVARCHAR(400) NULL, 
    [Search folder Result] NVARCHAR(MAX) NULL
)

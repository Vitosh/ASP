CREATE TABLE [dbo].[PartyPeople]
(
	[Id] INT NOT NULL  IDENTITY(1, 1), 
    [NickName] NVARCHAR(50) NULL, 
    [FancyMail] NVARCHAR(50) NULL, 
    [FavouriteAnimal] NVARCHAR(50) NULL, 
    [AnimalName] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_PartyPeople] PRIMARY KEY ([Id]) 
)

 CREATE DATABASE TempoChallengeKnights
-- Declara o name do database
DECLARE @DatabaseName NVARCHAR(128) = 'TempoChallengeKnights';

-- Verifica if o database já existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = @DatabaseName)
BEGIN
    CREATE DATABASE TempoChallengeKnights
END



GO

USE TempoChallengeKnights
GO


-- Tabela Knight
CREATE TABLE dbo.Knights (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Nickname NVARCHAR(255) NOT NULL,
    Birthday DATE NOT NULL,
    KeyAttribute NVARCHAR(255) NOT NULL,
    CharacterType NVARCHAR(255) NOT NULL,
    HallOfHeroes BIT DEFAULT 0 NOT NULL,
	CombatTraining float DEFAULT 0.0 NOT NULL,
	CreatedBy NVARCHAR(255) NOT NULL,
	CreatedAt DATETIME NOT NULL,
    ModifiedBy NVARCHAR(255) NOT NULL,
    ModifiedAt DATETIME 
	 
);

-- Tabela Weapon
CREATE TABLE dbo.Weapons (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Mod INT,
    Attr NVARCHAR(255) NOT NULL,
    Equipped BIT NOT NULL,
    KnightId UNIQUEIDENTIFIER,
	CreatedBy NVARCHAR(255) NOT NULL,
	CreatedAt DATETIME2 NOT NULL,
    ModifiedBy NVARCHAR(255) NOT NULL,
    ModifiedAt DATETIME2, 
    FOREIGN KEY (KnightId) REFERENCES Knights(Id)
);

-- Tabela Attribute
CREATE TABLE dbo.Attributes (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,   
	Value INT NOT NULL,
	CreatedBy NVARCHAR(255) NOT NULL,
	CreatedAt DATETIME2 NOT NULL,
    ModifiedBy NVARCHAR(255) NOT NULL,
    ModifiedAt DATETIME 

);

-- Tabela KnightAttribute
CREATE TABLE dbo.KnightAttributes (
    Id UNIQUEIDENTIFIER ,
	KnightId UNIQUEIDENTIFIER NOT NULL,
    AttributeId UNIQUEIDENTIFIER NOT NULL,
	CreatedBy NVARCHAR(255) NOT NULL,
	CreatedAt DATETIME2 NOT NULL,
    ModifiedBy NVARCHAR(255) NOT NULL,
    ModifiedAt DATETIME2, 
    PRIMARY KEY (KnightId, AttributeId),
    FOREIGN KEY (KnightId) REFERENCES Knights(Id),
    FOREIGN KEY (AttributeId) REFERENCES Attributes(Id)
);
GO
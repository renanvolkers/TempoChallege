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
     HallOfHeroes BIT DEFAULT 0 NOT NULL
);

-- Tabela Weapon
CREATE TABLE dbo.Weapons (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Mod INT,
    Attr NVARCHAR(255) NOT NULL,
    Equipped BIT NOT NULL,
    KnightId UNIQUEIDENTIFIER,
    FOREIGN KEY (KnightId) REFERENCES Knights(Id)
);

-- Tabela Attribute
CREATE TABLE dbo.Attributes (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

-- Tabela KnightAttribute
CREATE TABLE dbo.KnightAttribute (
    KnightId UNIQUEIDENTIFIER NOT NULL,
    AttributeId UNIQUEIDENTIFIER NOT NULL,
    Value INT NOT NULL,
    PRIMARY KEY (KnightId, AttributeId),
    FOREIGN KEY (KnightId) REFERENCES Knights(Id),
    FOREIGN KEY (AttributeId) REFERENCES Attributes(Id)
);
GO
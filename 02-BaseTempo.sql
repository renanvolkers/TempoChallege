USE TempoChallengeKnights
GO

 -- Inserir um Knight
 INSERT INTO Knights (Id, Name, Nickname, Birthday, KeyAttribute, CharacterType, HallOfHeroes)
 VALUES (NEWID(), 'Arthur', 'The Brave', '1980-01-01', 'Strength', 'Warrior', 0);

 -- Inserir um Attribute
 INSERT INTO Attributes (Id, Name)
 VALUES (NEWID(), 'Strength');

 -- Inserir uma Weapon
 INSERT INTO Weapons (Id, Name, Mod, Attr, Equipped, KnightId)
 VALUES (NEWID(), 'Excalibur', 10, 'Strength', 1, (SELECT TOP 1 Id FROM Knights));

 -- Inserir um KnightAttribute
 INSERT INTO KnightAttribute (KnightId, AttributeId, Value)
 VALUES (
     (SELECT TOP 1 Id FROM Knights),
     (SELECT TOP 1 Id FROM Attributes),
     100
 );

GO
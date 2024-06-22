USE TempoChallengeKnights
GO

 -- Inserir um Knight
INSERT INTO Knights (Id, Name, Nickname, Birthday, KeyAttribute, CharacterType, HallOfHeroes)
VALUES
    (NEWID(), 'Arthur', 'The Brave', '1980-01-01', 'Strength', 'Warrior', 0),
    (NEWID(), 'Lancelot', 'The Gallant', '1975-05-15', 'Courage', 'Knight', 1),
    (NEWID(), 'Galahad', 'The Pure', '1990-03-20', 'Virtue', 'Paladin', 1),
    (NEWID(), 'Merlin', 'The Wise', '1950-11-11', 'Wisdom', 'Mage', 1),
    (NEWID(), 'Guinevere', 'The Fair', '1978-09-30', 'Charm', 'Royalty', 0),
    (NEWID(), 'Tristan', 'The Loyal', '1985-04-25', 'Loyalty', 'Knight', 0),
    (NEWID(), 'Isolde', 'The Beloved', '1982-07-15', 'Love', 'Lady', 0),
    (NEWID(), 'Gawain', 'The Valiant', '1970-02-18', 'Valor', 'Knight', 1),
    (NEWID(), 'Mordred', 'The Betrayer', '1988-06-05', 'Deception', 'Rogue', 0),
    (NEWID(), 'Percival', 'The Seeker', '1995-08-22', 'Quest', 'Paladin', 0),
    (NEWID(), 'Morgana', 'The Enchantress', '1965-12-03', 'Magic', 'Sorceress', 0),
    (NEWID(), 'Bors', 'The Faithful', '1973-03-08', 'Faith', 'Knight', 1),
    (NEWID(), 'Elaine', 'The Graceful', '1987-01-14', 'Grace', 'Lady', 0),
    (NEWID(), 'Nimue', 'The Mysterious', '1992-10-20', 'Mystery', 'Sorceress', 0),
    (NEWID(), 'Perceval', 'The Righteous', '1977-06-28', 'Justice', 'Paladin', 1);

 -- Inserir um Attribute
INSERT INTO Attributes (Id, Name, Value)
VALUES
    (NEWID(), 'Strength', 100),
    (NEWID(), 'Courage', 90),
    (NEWID(), 'Virtue', 95),
    (NEWID(), 'Wisdom', 85),
    (NEWID(), 'Charm', 80),
    (NEWID(), 'Loyalty', 88),
    (NEWID(), 'Love', 92),
    (NEWID(), 'Valor', 87),
    (NEWID(), 'Deception', 75),
    (NEWID(), 'Quest', 82),
    (NEWID(), 'Magic', 89),
    (NEWID(), 'Faith', 91),
    (NEWID(), 'Grace', 78),
    (NEWID(), 'Mystery', 86),
    (NEWID(), 'Justice', 84);

 -- Inserir uma Weapon
INSERT INTO Weapons (Id, Name, Mod, Attr, Equipped, KnightId)
VALUES
    (NEWID(), 'Excalibur', 10, 'Strength', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Arthur')),
    (NEWID(), 'Holy Lance', 8, 'Valor', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Gawain')),
    (NEWID(), 'Enchanted Bow', 7, 'Magic', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Tristan')),
    (NEWID(), 'Shield of Faith', 5, 'Faith', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Bors')),
    (NEWID(), 'Sword of Justice', 9, 'Justice', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Perceval'));

 -- Inserir um KnightAttribute
INSERT INTO KnightAttributes (KnightId, AttributeId)
VALUES
    ((SELECT TOP 1 Id FROM Knights WHERE Name = 'Arthur'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Strength')),
    ((SELECT TOP 1 Id FROM Knights WHERE Name = 'Lancelot'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Courage')),
    ((SELECT TOP 1 Id FROM Knights WHERE Name = 'Galahad'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Virtue')),
    ((SELECT TOP 1 Id FROM Knights WHERE Name = 'Merlin'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Wisdom')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Guinevere'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Charm')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Tristan'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Loyalty')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Isolde'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Love')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Gawain'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Valor')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Mordred'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Deception')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Percival'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Quest')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Morgana'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Magic')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Bors'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Faith')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Elaine'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Grace')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Nimue'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Mystery')),
    ((SELECT TOP 1  Id FROM Knights WHERE Name = 'Perceval'), (SELECT TOP 1 Id FROM Attributes WHERE Name = 'Justice'));


GO
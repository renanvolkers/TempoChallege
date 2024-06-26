USE TempoChallengeKnights
GO

-- Inserir um Knight com informações de auditoria
INSERT INTO Knights (Id, Name, Nickname, Birthday, KeyAttribute, CharacterType, HallOfHeroes, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt)
VALUES
    (NEWID(), 'Arthur', 'The Brave', '1980-01-01', 'Strength', 'heroes', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Lancelot', 'The Gallant', '1975-05-15', 'Courage', 'heroes', 1, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Galahad', 'The Pure', '1990-03-20', 'Virtue', 'Paladin', 1, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Merlin', 'The Wise', '1950-11-11', 'Wisdom', 'Mage', 1, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Guinevere', 'The Fair', '1978-09-30', 'Charm', 'Royalty', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Tristan', 'The Loyal', '1985-04-25', 'Loyalty', 'Knight', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Isolde', 'The Beloved', '1982-07-15', 'Love', 'Lady', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Gawain', 'The Valiant', '1970-02-18', 'Valor', 'Knight', 1, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Mordred', 'The Betrayer', '1988-06-05', 'Deception', 'Rogue', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Percival', 'The Seeker', '1995-08-22', 'Quest', 'Paladin', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Morgana', 'The Enchantress', '1965-12-03', 'Magic', 'Sorceress', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Bors', 'The Faithful', '1973-03-08', 'Faith', 'Knight', 1, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Elaine', 'The Graceful', '1987-01-14', 'Grace', 'Lady', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Nimue', 'The Mysterious', '1992-10-20', 'Mystery', 'Sorceress', 0, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Perceval', 'The Righteous', '1977-06-28', 'Justice', 'Paladin', 1, 'system', GETDATE(), 'system', GETDATE());


-- Inserir um Attribute com informações de auditoria
INSERT INTO Attributes (Id, Name, Value, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt)
VALUES
    (NEWID(), 'Strength', 100, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Courage', 90, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Virtue', 95, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Wisdom', 85, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Charm', 80, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Loyalty', 88, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Love', 92, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Valor', 87, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Deception', 75, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Quest', 82, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Magic', 89, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Faith', 91, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Grace', 78, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Mystery', 86, 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Justice', 84, 'system', GETDATE(), 'system', GETDATE());

-- Inserir uma Weapon com informações de auditoria
INSERT INTO Weapons (Id, Name, Mod, Attr, Equipped, KnightId, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt)
VALUES
    (NEWID(), 'Excalibur', 10, 'Strength', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Arthur'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Holy Lance', 8, 'Valor', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Gawain'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Enchanted Bow', 7, 'Magic', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Tristan'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Shield of Faith', 5, 'Faith', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Bors'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), 'Sword of Justice', 9, 'Justice', 1, (SELECT TOP 1 Id FROM Knights WHERE Name = 'Perceval'), 'system', GETDATE(), 'system', GETDATE());

-- Inserir um KnightAttribute com informações de auditoria
INSERT INTO KnightAttributes (Id, KnightId, AttributeId, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt)
VALUES
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Arthur'), (SELECT Id FROM Attributes WHERE Name = 'Strength'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Lancelot'), (SELECT Id FROM Attributes WHERE Name = 'Courage'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Galahad'), (SELECT Id FROM Attributes WHERE Name = 'Virtue'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Merlin'), (SELECT Id FROM Attributes WHERE Name = 'Wisdom'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Guinevere'), (SELECT Id FROM Attributes WHERE Name = 'Charm'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Tristan'), (SELECT Id FROM Attributes WHERE Name = 'Loyalty'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Isolde'), (SELECT Id FROM Attributes WHERE Name = 'Love'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Gawain'), (SELECT Id FROM Attributes WHERE Name = 'Valor'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Mordred'), (SELECT Id FROM Attributes WHERE Name = 'Deception'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Percival'), (SELECT Id FROM Attributes WHERE Name = 'Quest'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Morgana'), (SELECT Id FROM Attributes WHERE Name = 'Magic'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Bors'), (SELECT Id FROM Attributes WHERE Name = 'Faith'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Elaine'), (SELECT Id FROM Attributes WHERE Name = 'Grace'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Nimue'), (SELECT Id FROM Attributes WHERE Name = 'Mystery'), 'system', GETDATE(), 'system', GETDATE()),
    (NEWID(), (SELECT Id FROM Knights WHERE Name = 'Perceval'), (SELECT Id FROM Attributes WHERE Name = 'Justice'), 'system', GETDATE(), 'system', GETDATE());


GO
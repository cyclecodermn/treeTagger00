USE TaggerTree00

-- -  -   -    -     -      -       -        -
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN

	DELETE FROM TagCategoriesTable;

--	DELETE FROM AspNetUsers;
end
go

 DBCC CHECKIDENT('TagCategoriesTable', RESEED, 1)

-- -  -   -    -     -      -       -        -
	delete from TagCategoriesTable;
	SET IDENTITY_INSERT TagCategoriesTable ON;
	
	INSERT INTO TagCategoriesTable (TagNameId, TagParentId, TagName)
	VALUES
	(1,NULL,'Age'),
	(2,1,'Old'),
	(3,2,'Looking Back'),
	(4,3,'Good'),
	(5,3,'Bad'),
	(6,1,'Young'),
	(7,6,'Looking Forward'),
	(8,6,'Good'),
	(9,6,'Bad'),
	(10,1,'Middle Age'),
	(11,10,'Good'),
	(12,11,'Bad'),
	(13,11,'Letting go of yourth'),
	(14,3,'Aging'),
	(15,3,'Stages'),
	(16,3,'Retirement');

	SET IDENTITY_INSERT TagCategoriesTable OFF;
-- -  -   -    -     -      -       -        -

-- -  -   -    -     -      -       -        -
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ShowParentsAndChildren')
		DROP PROCEDURE ShowParentsAndChildren
GO

CREATE PROCEDURE ShowParentsAndChildren AS
BEGIN

	SELECT TagParentTable.TagName AS TagParent, TagChildTable.TagName AS TagChild
	FROM TagCategoriesTable TagParentTable 
	INNER JOIN TagCategoriesTable TagChildTable
	ON TagParentTable.TagNameId = TagChildTable.TagParentId

	ORDER BY TagParent, TagChild;

END
GO


-- -  -   -    -     -      -       -        -

-- -  -   -    -     -      -       -        -
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllTagTable')
		DROP PROCEDURE GetAllTagTable
GO

CREATE PROCEDURE GetAllTagTable AS
BEGIN

	SELECT * FROM TagCategoriesTable 

	ORDER BY TagParentId, TagNameId;

END
GO


-- -  -   -    -     -      -       -        -






-- -  -   -    -     -      -       -        -
---- Add code below after adding ASP Users
----delete from aspnetusers;
--	INSERT INTO AspNetUsers(Id, firstName, lastName, EmailConfirmed, PhoneNumberConfirmed, Email,TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
--	VALUES
--	('00000000-0000-0000-0000-000000000000', 'James', 'Carter', 1, 1, 'test@test.com', 0, 0, 0, 'test'),
--	('41cc81c5-5290-4bc5-864c-dfa43f2f8020', 'Sue', 'David', 1, 1, 'sue@sgul.ac.uk', 0, 0, 0, 'sue');
---- -  -   -    -     -      -       -        -



GO

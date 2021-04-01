CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Pesho', '123456', '05.23.2020', 0),
('Pesho1', '123456', '05.23.2020', 1),
('Pesho2', '123456', '05.23.2020', 0),
('Pesho3', '123456', '05.23.2020', 0),
('Pesho4', '123456', '05.23.2020', 1)

SELECT * FROM Users

DELETE FROM Users
WHERE Id = 5

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC0783DC045E]

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)
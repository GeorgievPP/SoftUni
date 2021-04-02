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

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK (LEN(Username) >= 3)


CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddresseText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
		Id INT PRIMARY KEY IDENTITY,
		FirstName NVARCHAR(50) NOT NULL,
		MiddleName NVARCHAR(50),
		LastName NVARCHAR(50) NOT NULL,
		JobTitle NVARCHAR(30) NOT NULL,
		DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
		HireDate DATE NOT NULL,
		Salary DECIMAL(7, 2) NOT NULL,
		AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)


INSERT INTO Towns([Name])
	VALUES
			('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')

INSERT INTO Departments([Name])
	VALUES 
			('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')



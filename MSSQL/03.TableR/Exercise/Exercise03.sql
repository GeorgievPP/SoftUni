
CREATE DATABASE EntityRelationsDemo

USE [EntityRelationsDemo]

-- Problem01

CREATE TABLE Passports(
	PassportId INT PRIMARY KEY, -- IDENTITY(100, 1)
	PassportNumber CHAR(8) NOT NULL
)

CREATE TABLE Persons(
	PersonId INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	PassportId INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportId) UNIQUE
)

INSERT INTO Passports(PassportId, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'Z657QP2')

INSERT INTO Persons(PersonId, [FirstName], Salary, PassportId)
VALUES
(1, 'Roberto', 43300, 102),
(2, 'Tom', 56100, 103), 
(3, 'Yana', 60200, 101) 

--- Problem02

CREATE TABLE Manufacturers(
	ManufacturerId INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelId INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerId INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerId)
)

INSERT INTO Manufacturers(ManufacturerId, [Name], EstablishedOn)
VALUES
(1, 'BMW', '03/07/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '05/01/1966')

INSERT INTO Models(ModelId, [Name], ManufacturerId)
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 1),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

-- Problem03

CREATE TABLE Students(
	StudentId INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamId INT PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(StudentId),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamId),
	PRIMARY KEY(StudentId, ExamId)
)

INSERT INTO Students(StudentId, [Name])
VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams(ExamId, [Name])
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentId, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--demo

SELECT s.[Name], e.[Name] FROM StudentsExams AS se
JOIN Students AS s ON se.StudentId = s.StudentId
JOIN Exams AS e ON se.ExamId = e.ExamId

--- Problem04

CREATE TABLE Teachers(
	TeacherId INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerId INT FOREIGN KEY REFERENCES Teachers(TeacherId)
)

INSERT INTO Teachers(TeacherId, [Name], ManagerId)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101),

--- Problem06

CREATE DATABASE University

USE [University]

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(10) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT NOT NULL FOREIGN KEY REFERENCES Majors(MajorID) 
)

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2),
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentId)
)

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(80) NOT NULL
)

CREATE TABLE Agenda(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)

--- Problem09

USE Geography

SELECT MountainRange, PeakName, Elevation FROM Peaks
JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC




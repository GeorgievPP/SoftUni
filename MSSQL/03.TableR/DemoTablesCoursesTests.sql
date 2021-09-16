-- CREATE DATABASE

CREATE DATABASE CoursesTest

-- CREATE TABLE

CREATE TABLE Students_2
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100),
	FacultyNumber CHAR(6) NOT NULL UNIQUE,
	Photo VARBINARY(MAX) NOT NULL,
	DateOfEnlistment DATE,
	Courses NVARCHAR(500)
)


CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Course
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	TownId INT REFERENCES Towns(Id)
)

-- MANY TO MANY

CREATE TABLE StubentsCourses
(
	StudentId INT REFERENCES Students(Id),
	CourseId INT REFERENCES Course(Id),
	Mark DECIMAL(3,2),
	CONSTRAINT PK_StudentsCourses
		PRIMARY KEY (StudentId, CourseId)
)
--- ---- ----

SELECT * FROM Course AS c
	JOIN Towns AS t
		ON c.TownId = t.Id

SELECT *
	FROM StubentsCourses sc
	JOIN Course c ON sc.CourseId = c.Id
	JOIN Students s ON sc.StudentId = s.Id
	JOIN Towns t ON c.TownId = t.Id


--- Problem USE Geography

SELECT  m.MountainRange, p.PeakName, p.Elevation 
	FROM Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	WHERE MountainRange = 'Rila'
	ORDER BY p.Elevation DESC

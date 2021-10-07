CREATE DATABASE [Services]

USE [Services]

-- joudje01

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	Password NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age >= 14 AND Age <= 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age >= 18 AND Age <= 110),
	DepartmentId INT REFERENCES Departments(Id)
	-- Description forgot
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	Label NVARCHAR(30) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(StatusId INT NOT NULL REFERENCES Status(Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description NVARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

-- joudje03

UPDATE Reports SET CloseDate = GETDATE()
WHERE [CloseDate] IS NULL

-- joudje04

DELETE FROM Reporst
WHERE StatsusId = 4


-- joudje05

SELECT Description,
	   FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
 FROM Reports AS r
 WHERE Employees IS NULL
 ORDER BY r.OpenDate ASC, Description ASC

-- joudje06

SELECT r.Description, c.Name AS CategoryName
 FROM Reports AS r
 JOIN Categories AS c ON c.Id = r.CategoryId
 ORDER BY r.Description , CategoryName

-- joudje07

SELECT TOP(5) c.Name, COUNT(*) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY CategoryId, c.Name
ORDER BY ReportsNumber DESC, Name ASC

-- joudje08

SELECT Username, c.Name AS CategoryName
 FROM Reports AS r
 JOIN Users AS u ON u.Id = r.UserId -- forgot
 JOIN Categories AS c ON c.Id = r.CategoryId
 WHERE 
	DATEPART(month, r.OpenData) = DATEPART(month, u.Birthdate) AND DATEPART(DAY, r.OpenDate)
ORDER BY Username ASC, c.Name ASC


-- joudje09

SELECT 
		FirstName + ' ' + LastName AS FullName,
		(SELECT COUNT(DISTINCT UserId) FROM Reports WHERE EmployeeId = e.Id) AS UsersCount
FROM Employees AS e
ORDER BY [UsersCount] DESC, FullName ASC


-- joudje10

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
		ISNULL(d.Name, 'None') AS Department,
		ISNULL(c.Name, 'None') AS Category,
		r.Description,
		r.OpenDate,
		FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		s.Label AS Status,
		ISNULL(u.Name, 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
LEFT JOIN Status AS s ON s.Id = r.StatusId
LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY 
	FirstName DESC, 
	LastName DESC,
	d.Name ASC,
	c.Name ASC,
	r.Description ASC, 
	r.OpenDate ASC,
	s.Label ASC, 
	u.Username ASC
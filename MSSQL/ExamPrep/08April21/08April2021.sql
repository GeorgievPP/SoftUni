CREATE DATABASE Service

Use Services

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Name VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK (Age BETWEEN 14 AND 111),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK (Age BETWEEN 18 AND 111),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)


CREATE TABLE Status (
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports (
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

 --PROB02

INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley',	1958-9-21, 1),
('Niki', 'Stanaghan', 1969-11-26, 4),
('Ayrton', 'Senna', 1960-03-21, 9),
('Ronnie', 'Peterson', 1944-02-14, 9),
('Giovanna', 'Amati',	1959-07-20, 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES
(1,  1,	2017-04-13, NULL, 'Stuck Road on Str.133', 6, 2),
(6,  3,	2015-09-05,	2015-12-06,	'Charity trail running', 3, 5),
(14, 2,	2015-09-07,	NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3,	2017-07-03,	2017-07-06,	'Cut off streetlight on Str.11', 1, 1)

 --PROB03

 UPDATE Reports
 SET CloseDate = GETDATE()
 WHERE CloseDate IS NULL

 --PROB04

 DELETE FROM Reports WHERE StatusId = 4 

 --PROB05

SELECT Description, CONVERT(varchar, OpenDate, 105)
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, Description

 --PROB06

 SELECT r.Description, c.Name
 FROM Reports AS r
 JOIN Categories AS c ON c.Id = r.CategoryId
 ORDER BY r.Description, c.Name

 --PROB07

 SELECT TOP(5) c.Name AS CategoryName, COUNT(*) AS ReportsNumber
 FROM Reports AS r
 JOIN Categories AS c ON c.Id = r.CategoryId 
 GROUP BY  r.CategoryId, c.Name
 ORDER BY ReportsNumber DESC, c.Name

 --PROB08

 SELECT u.Username, c.Name
 FROM Reports AS r
 JOIN Categories AS c ON c.Id = r.CategoryId
 JOIN Users AS u ON u.Id = r.UserId
 WHERE DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate) AND
	   DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
ORDER BY u.Username, c.Name


 --PROB09

 SELECT e.FirstName + ' ' + e.LastName AS FullName,
	    COUNT(DISTINCT r.UserId) AS UsersCount
 FROM Reports AS r
 RIGHT JOIN Employees AS e ON e.Id = r.EmployeeId
 GROUP BY EmployeeId, FirstName, LastName
 ORDER BY UsersCount DESC, FullName 

 --PROB10

 SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
	    ISNULL(d.Name, 'None') AS Department,
		ISNULL(c.Name, 'None') AS Category,
		r.Description,
		FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		s.Label AS [Status],
		u.Name AS [User]
 FROM Reports AS r
 LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
 LEFT JOIN Categories AS c ON c.Id = r.CategoryId
 LEFT JOIN Status AS s ON s.Id = r.StatusId
 LEFT JOIN Users AS u ON u.Id = r.UserId
 LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
 ORDER BY  e.FirstName DESC,
		   e.LastName DESC,
		   d.Name,
		   c.Name,
		   r.Description,
		   r.OpenDate,
		   s.Label,
		   u.Username

USE [SoftUni]		

-- Problem02

SELECT * FROM [Departments]

-- Problem03

SELECT [Name] FROM [Departments]

-- Problem04

SELECT FirstName, LastName, Salary FROM Employees

-- Problem05

SELECT FirstName, MiddleName, LastName FROM Employees

-- Problem06

SELECT (FirstName + '.' + LastName + '@softuni.bg') AS [Full Email Address]
 FROM Employees

SELECT CONCAT(FirstName, '.', LastName, '@', 'softuni.bg') AS [Full Email Address]
FROM Employees

	-- Problem07

SELECT DISTINCT Salary FROM Employees

-- Problem08

SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

-- Problem09

SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

-- Problem10 
	-- ...MiddleName + ' '

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)


-- Problem11

SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

-- Problem12

SELECT FirstName, LastName, Salary 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- Problem13

SELECT TOP(5) FirstName, LastName FROM Employees
ORDER BY Salary DESC

--Problem14

SELECT FirstName, LastName FROM Employees
WHERE DepartmentID != 4

		--OFFSET, FETCH NEXT

SELECT FirstName, LastName FROM Employees
ORDER BY Salary DESC
OFFSET 5 ROWS
FETCH NEXT 10 ROWS ONLY


-- Problem15

SELECT * FROM Employees
ORDER BY Salary DESC, 
		 FirstName ASC, 
		 LastName DESC, 
		 MiddleName ASC


-- Problem16

GO

CREATE VIEW V_EmployeesSalaries
AS 
(SELECT 
	FirstName, 
	LastName, 
	Salary
FROM Employees)

GO



-- Problem17

GO

CREATE VIEW V_EmployeeNameJobTitle 
AS 
(SELECT 
	CONCAT(FirstName, ' ', ISNULL(MiddleName, ''),' ', LastName) AS [Full Name], 
	JobTitle 
FROM Employees)

GO

--SELECT * FROM V_EmployeeNameJobTitle

-- extra

SELECT SUM(Salary) AS [SalarySum] FROM (
	SELECT TOP (5) Salary FROM Employees
	ORDER BY Salary DESC
) AS [TopFiveSalaries]


-- Problem18

SELECT DISTINCT JobTitle FROM Employees


-- Problem19

SELECT TOP (10) * FROM Projects
ORDER BY StartDate ASC, [Name] ASC

-- Problem20

SELECT TOP (7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC


-- Problem21

UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentID IN (1, 2, 4, 11)

SELECT Salary FROM Employees

---

USE [Geography]
-- Problem22

SELECT PeakName FROM Peaks
ORDER BY PeakName ASC

-- Problem23

SELECT TOP(30) [CountryName], [Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC,
		 CountryName ASC


-- Problem24 

SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM Countries
ORDER BY CountryName ASC

----

USE Diablo
-- Problem25

SELECT [Name] FROM Characters
ORDER BY [Name] ASC
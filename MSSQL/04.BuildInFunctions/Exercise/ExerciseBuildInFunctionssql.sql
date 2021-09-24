USE SoftUni

--pROBLEM01

SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'sa%'

-- Problem02


SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'

--Problem04

SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--pROBLEM06

SELECT *
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY Name

--PROBLEM08

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

--PROBLEM09

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--PROBLEM10

SELECT EmployeeID, FirstName, LastName, Salary, 
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) 
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- Problem11

SELECT * FROM(
SELECT EmployeeID, FirstName, LastName, Salary, 
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Ranked
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
) AS Result
WHERE Ranked = 2
ORDER BY Salary DESC

USE Geography

-- Problem12

SELECT CountryName, IsoCode
 FROM Countries
 WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--PROBLEM13

SELECT PeakName,
	   RiverName,
	   LOWER(LEFT(PeakName, LEN(PeakName) - 1) + RiverName) AS Mix	 
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix



USE Diablo
--PROBLEM14

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--PROBLEM15

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
	AS EmailProvider
FROM Users
ORDER BY EmailProvider, Username

--PROBLEM16

SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username


--PROBLEM17

SELECT [Name],
	CASE
	 WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11 THEN 'Morning'
	 WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
	 WHEN DATEPART(HOUR, Start) BETWEEN 18 AND 23 THEN 'Evening'
	END
	 AS [Part of the Day],
	 CASE 
	  WHEN Duration <= 3 THEN 'Extra Short'
	  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	  WHEN Duration > 6 THEN 'Long'
	  ELSE 
	  'Extra Long'
	 END AS [Duration]
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]

--PROBLEM18

SELECT ProductName,
	   OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Delivery Due]
FROM Orders



--Problem03, 05, 07
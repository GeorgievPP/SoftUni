

SELECT GETDATE(), DATEPART(YEAR, GETDATE())
s
USE SoftUniDemo

SELECT FirstName, LastName, GETDATE()
FROM Employees



SELECT FirstName, LastName, LEFT(FirstName, 2)
FROM Employees

SELECT * FROM Employees

SELECT DepartmentID, AVG(Salary)
  FROM Employees
  GROUP BY DepartmentID

  
SELECT DepartmentID, MIN(Salary)
  FROM Employees
  GROUP BY DepartmentID


SELECT FirstName, Salary, DepartmentID,
	PERCENTILE_CONT(0.5)
	WITHIN GROUP (ORDER BY Salary DESC)
	OVER (PARTITION BY DepartmentId) AS MedianCont
FROM Employees




SELECT
	FirstName, MiddleName, LastName,
	CONCAT(FirstName, ' ', MiddleName, ' ' ,LastName),
	CONCAT_WS(' ', FirstName, MiddleName, LastName)
 FROM Employees


 --SUBSTRING(String, StartIndex, Length)
 SELECT SUBSTRING('SoftUni123', 5, 3)

  --REPLACE(String, Pattern, Replacement)
 SELECT REPLACE('SoftUni123', 'Soft', 'Hard')


 --Problem: Obfuscate CC Numbers
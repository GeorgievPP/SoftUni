SELECT DISTINCT 
	FirstName + ' ' + LastName AS [Full Name], 
	JobTitle AS [Job Title], 
	Salary
FROM Employees

SELECT * 
	FROM Employees
	WHERE 
		Salary BETWEEN 20000 AND 40000
--	WHERE Salary >= 20000 AND Salary <= 40000

SELECT *
	FROM Employees
	WHERE
		DepartmentID IN (1, 2, 3, 4, 5)
		/*
		DepartmentID = 1 OR
		DepartmentID = 2 OR
		DepartmentID = 3 OR
		DepartmentID = 4 OR
		DepartmentID = 5 
		*/ 


SELECT *
	FROM Employees
	WHERE
		ManagerID IS NULL


		
SELECT *
	FROM Employees
	WHERE
		JobTitle LIKE '%Manager%'

		
SELECT *
	FROM Employees
	WHERE
		FirstName LIKE '%a%b%'

		
SELECT *
	FROM Employees
	WHERE Salary > 20000
	ORDER BY Salary DESC

	
SELECT *
	FROM Employees
	WHERE Salary > 20000
	ORDER BY FirstName ASC, LastName DESC


SELECT FirstName, LastName, FirstName + ' ' + LastName AS [Full Name]
	FROM Employees
	WHERE Salary > 50000
	ORDER BY newid()

	-- Highest Salaries
CREATE VIEW v_EmployeesWithHighestSalaries AS
SELECT FirstName, LastName, FirstName + ' ' + LastName AS [Full Name], Salary
	FROM Employees
	WHERE Salary > 40000


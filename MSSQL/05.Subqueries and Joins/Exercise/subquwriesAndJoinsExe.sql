-- Problem01

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY a.AddressID

--Problem02

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

--Problem05

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

--Problem06

SELECT e.FirstName, e.LastName, e.HireDate, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate

--Problem07

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '08/13/2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem08

SELECT e.EmployeeID, 
	   e.FirstName,
	   CASE
			WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
			ELSE p.Name
		END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24


--Problem09

SELECT emp.EmployeeID, emp.FirstName, emp.LastName, emp.ManagerID, '<>',
	   mng.EmployeeID, mng.FirstName, mng.LastName, mng.ManagerID
FROM  Employees AS emp
JOIN Employees AS mng ON mng.EmployeeID = emp.ManagerID


--Problem10

SELECT TOP(50) emp.EmployeeID, emp.FirstName + ' ' + emp.LastName,
mng.FirstName + ' ' + mng.LastName, d.Name
FROM Employees AS emp
JOIN Employees AS mng ON mng.EmployeeID = emp.ManagerID
JOIN Departments AS d ON d.DepartmentID = emp.DepartmentID
ORDER BY emp.EmployeeID

--Problem11

SELECT TOP(1) AVG(Salary) AS AverageSalary
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
GROUP BY e.DepartmentID
ORDER BY AverageSalary

-----

USE Geography

--Problem12

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	JOIN Mountains AS m ON m.Id = mc.MountainId
	JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem13

SELECT c.CountryCode, COUNT(*)
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode


--Problem14

SELECT TOP(5) CountryName, RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode= 'AF'
ORDER BY c.CountryName

--Problem15

SELECT ContinentCode, CurrencyCode, Total FROM(
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS Total,
	DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
 FROM Countries
 GROUP BY ContinentCode, CurrencyCode) AS k
	WHERE Ranked = 1 AND Total > 1
ORDER BY ContinentCode

--Problem16

SELECT COUNT(*)
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = C.CountryCode
WHERE mc.MountainId IS NULL


--Problem17

SELECT TOP(5) CountryName, MAX(p.Elevation) AS HighestPeak, MAX(r.Length) AS LongestRiver
 FROM Countries AS c
 LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
 LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
 LEFT JOIN Peaks AS p ON p.MountainId = m.Id
 LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
 LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
 GROUP BY CountryName
 ORDER BY HighestPeak DESC, LongestRiver DESC, CountryName

--Problem18

SELECT TOP(5) k.CountryName, k.PeakName, k.HighestPeak, k.MountainRange
FROM (SELECT CountryName,
	ISNULL(p.PeakName, '(no highest peak)') AS PeakName,
	ISNULL(m.MountainRange, '(no mountain)') AS MountainRange,
	ISNULL(MAX(p.Elevation), 0) AS HighestPeak,
	DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
	FROM Countries AS c
	 LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	 LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	 LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY CountryName, p.PeakName, m.MountainRange) AS k
WHERE Ranked = 1
ORDER BY CountryName, PeakName

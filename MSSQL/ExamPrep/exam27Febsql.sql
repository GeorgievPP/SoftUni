CREATE DATABASE [WMS]

USE [WMS]

CREATE TABLE [Clients] (
	ClientId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL CHECK (LEN(Phone) = 12)
)

CREATE TABLE Mechanics (
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Vendors (
	VendorId INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) UNIQUE NOT NULL 
)

CREATE TABLE Jobs 
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) DEFAULT 'Pending' CHECK(Status IN ('Pending', 'In Progress', 'Finished')) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price DECIMAL(15,2) CHECK(Price > 0 AND Price <= 9999.99) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT DEFAULT 0 CHECK(StockQty >=0)
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0)

	CONSTRAINT PK_OrdersParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0)

	CONSTRAINT PK_JobsParts PRIMARY KEY (JobId, PartId)
)

--prob05

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, j.Status AS Status, j.IssueDate AS IssueDate 
 FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--prob06

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client, 
		DATEDIFF(DAY, j.IssueDate, '04/24/2017') AS [Days Going],
		j.Status
 FROM Clients AS c
LEFT JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [Days Going] DESC, j.ClientId


--prob07

SELECT m.FirstName + ' ' + m.LastName,
	AVG(DATEDIFF(DAY, IssueDate, FinishDate))
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY j.MechanicId, (m.FirstName + ' ' + m.LastName)
ORDER BY j.MechanicId

--prob08

SELECT (m.FirstName + ' ' + m.LastName)
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
							FROM Jobs
							WHERE Status <> 'Finished' AND MechanicId = m.MechanicId
							GROUP BY MechanicId, Status) IS NULL
GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName)

--prob09

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS TotalOrder
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE Status = 'Finished'
GROUP BY j.JobId
ORDER BY TotalOrder DESC, j.JobId


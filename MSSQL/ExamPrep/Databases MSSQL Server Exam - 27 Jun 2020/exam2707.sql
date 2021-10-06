CREATE DATABASE WMS

USE WMS

--Section01

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics 
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)


CREATE TABLE Models 
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
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

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(50) UNIQUE NOT NULL
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

--Section02
--joudge 02

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, Description, Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive',  6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)


SELECT * FROM Jobs

--joudge 03

UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE Status = 'Pending'

--joudge 04

DELETE FROM OrderParts WHERE OrderId = 19
DELETE FROM Orders WHERE OrderId = 19

------------------------

--joudge 05

SELECT m.FirstName + ' ' + m.LastName,
	   j.Status,
	   j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--joudge 06

SELECT c.FirstName + ' ' + c.LastName, 
	   DATEDIFF(DAY, j.IssueDate, '04/24/2017') AS TimeLength,
	   j.Status
FROM Jobs AS j
JOIN Clients AS c ON c.ClientId = j.ClientId
WHERE j.Status != 'Finished'
ORDER BY TimeLength DESC, j.ClientId

--joudge 07

SELECT m.FirstName + ' ' + m.LastName,
	AVG(DATEDIFF(DAY, IssueDate, FinishDate))
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY j.MechanicId, (m.FirstName + ' ' + m.LastName)
ORDER BY j.MechanicId


--joudge 08

SELECT m.FirstName + ' ' + m.LastName
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
						FROM Jobs
						WHERE Status <> 'Finished' AND MechanicId = m.MechanicId
						GROUP BY MechanicId, Status) IS NULL
GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName)

--joudge 09

SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS TotalOrder
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE Status = 'Finished'
GROUP BY j.JobId
ORDER BY TotalOrder DESC, j.JobId
 
--joudge 10

 SELECT p.PartId,
	    p.Description,
		pn.Quantity AS [Required],
		p.StockQty as [In Stock],
		IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
 FROM Parts AS p
LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
 WHERE j.Status != 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
 ORDER BY PartId

--joudge 11

CREATE PROCEDURE usp_PlaceOrder
(
@jobId INT,
@serialNumber VARCHAR(50),
@qty INT
)
AS

DECLARE @status VARCHAR(10) =
		 (SELECT Status FROM Jobs WHERE JobId = @jobId)
DECLARE @partId VARCHAR(10) = 
		(SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

 IF (@qty <= 0)
THROW 50012, 'Part quantity must be more than zero!', 1
ELSE IF (@status IS NULL)
THROW 50013, 'Job not found!', 1
ELSE IF (@status = 'Finished')
THROW 50011, 'This job is not active!', 1
ELSE IF (@partId IS NULL)
THROW 50014, 'Part not found!', 1

DECLARE @orderId INT = (SELECT o.OrderId 
						FROM Orders AS o 
						WHERE JobId = @jobId AND o.IssueDate IS NULL)

IF(@orderId IS NULL)
BEGIN
	INSERT INTO Orders (JobId, IssueDate) VALUES (@jobId, NULL)
END
	SET @orderId = 
		(SELECT o.OrderId FROM Orders AS o 
		WHERE JobId = @jobId AND o.IssueDate IS NULL)
	DECLARE @orderPartExist INT = (SELECT OrderId FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId)
IF (@orderPartExist IS NULL)
BEGIN
	INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
	(@orderId, @partId, @qty)
END
ELSE 
BEGIN
		UPDATE OrderParts
		SET Quantity += @qty
		WHERE OrderId = @orderId AND PartId = @partId 
END

--joudge 12

CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
DECLARE @result DECIMAL(15,2);
SET @result = (SELECT SUM(p.Price * op.Quantity) AS totalSum
	FROM Jobs AS j
	JOIN Orders AS o ON o.JobId = j.JobId
	JOIN OrderParts AS op ON op.OrderId = o.OrderId
	JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.JobId = @jobId
GROUP BY j.JobId)
IF(@result IS NULL)
SET @result = 0;

RETURN @result

END
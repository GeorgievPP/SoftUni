CREATE DATABASE Bakery

USE Bakery

--PROB01

CREATE TABLE Countries (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Gender CHAR(1) CHECK(Gender = 'M' OR Gender = 'F') NOT NULL,
	Age INT NOT NULL,
	PhoneNumber VARCHAR(10) CHECK(LEN(PhoneNumber) = 10) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Products (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(25) NOT NULL UNIQUE,
	Description VARCHAR(250) NOT NULL,
	Recipe VARCHAR(MAX) NOT NULL,
	Price DECIMAL(18, 2) CHECK(Price >= 0) NOT NULL
)

CREATE TABLE Feedbacks (
	Id INT PRIMARY KEY IDENTITY,
	Description VARCHAR(250),
	Rate DECIMAL(18, 2) CHECK(Rate >= 0 AND Rate <= 10) NOT NULL,
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(25) NOT NULL UNIQUE,
	AddressText VARCHAR(30) NOT NULL,
	Summary VARCHAR(200) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	Description VARCHAR(200) NOT NULL,
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
) 

CREATE TABLE ProductsIngredients (
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id)
	PRIMARY KEY (ProductId, IngredientId)
)

 --PROB02

 INSERT INTO Distributors (Name, CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave','Quality-focused 4th generation hardware')


INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399',	5),
('Kendra', 'Loud', 22,	'F', '0063631526',	11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686',	1),
('Tom', 'Loeza', 31, 'M', '0144876096',	23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793',	29),
('Hiu', 'Portaro', 25,	'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F',  '0197887645', 17)

 --PROB03

 UPDATE Ingredients
 SET DistributorId = 35
 WHERE Name = 'Bay Leaf' OR Name = 'Paprika' OR Name = 'Poppy'

 UPDATE Ingredients
 SET OriginCountryId = 14
 WHERE OriginCountryId = 8

 --PROB04

DELETE FROM Feedbacks WHERE CustomerId = 14
DELETE FROM Feedbacks WHERE ProductId = 5

 --PROB05

 SELECT Name, Price, Description
 FROM Products
 ORDER BY Price DESC, Name

 --PROB06

 SELECT f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender
 FROM Feedbacks AS f
 JOIN Customers AS c ON c.Id = f.CustomerId
 WHERE f.Rate < 5.00
 ORDER BY f.ProductId DESC, f.Rate

 --PROB07

 SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName , c.PhoneNumber, c.Gender
 FROM Customers AS c
 LEFT JOIN Feedbacks AS f ON f.CustomerId = c.Id 
 WHERE f.CustomerId IS NULL
 ORDER BY c.Id

  --PROB08

  SELECT c.FirstName, c.Age, c.PhoneNumber
  FROM Customers AS c
  JOIN Countries AS cnt ON cnt.Id = c.CountryId
  WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR 
		(c.PhoneNumber LIKE '%38' AND cnt.Name != 'Greece')
 ORDER BY c.FirstName, c.Age DESC

  --PROB09


  SELECT DistributorName, IngredientName, ProductName, AverageRate
  FROM (SELECT 
  d.Name AS DistributorName, 
  i.Name AS IngredientName,
   p.Name AS ProductName,
   AVG(f.Rate) AS AverageRate
		FROM Distributors AS d
		JOIN Ingredients AS i ON i.DistributorId = d.Id
		JOIN ProductsIngredients AS pIng ON pIng.IngredientId = i.Id
		JOIN Products AS p ON p.Id = pIng.ProductId
		JOIN Feedbacks AS f ON f.ProductId = p.Id
		GROUP BY d.Name, i.Name, p.Name) AS Result
WHERE AverageRate BETWEEN 5.0 AND 8.0
ORDER BY DistributorName,
		 IngredientName,
		 ProductName

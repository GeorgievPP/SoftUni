CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FullName VARCHAR(100) NOT NULL UNIQUE,
	Email VARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL UNIQUE,
	LastName VARCHAR(30) NOT NULL UNIQUE,
	Age TINYINT NOT NULL CONSTRAINT CH_Age_In_Range CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CONSTRAINT CH_Rating_In_Range CHECK(Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)  


CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)

 
CREATE TABLE PilotsAircraft
(
AircraftId INT NOT NULL CONSTRAINT FK_PilotsAircraft_Aircraft FOREIGN KEY REFERENCES Aircraft(Id),
PilotId INT NOT NULL CONSTRAINT FK_PilotsAircraft_Cigars FOREIGN KEY REFERENCES Pilots(Id),

CONSTRAINT PK_PilotsAircraft PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports 
(
	Id INT PRIMARY KEY IDENTITY ,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
) 

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(16,2) DEFAULT 15 NOT NULL
)  
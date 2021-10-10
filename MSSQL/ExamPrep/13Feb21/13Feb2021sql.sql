CREATE DATABASE Bitbucket2

USE Bitbucket2

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY ,
Username VARCHAR(30)  NOT NULL ,
Password VARCHAR(30)  NOT NULL ,
Email    VARCHAR(50)  NOT NULL
)

CREATE TABLE Repositories
(
Id   INT PRIMARY KEY IDENTITY ,
Name VARCHAR(50)  NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId  INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
Id           INT PRIMARY KEY IDENTITY ,
Title        VARCHAR(MAX) NOT NULL ,
IssueStatus  CHAR(6) NOT NULL,
RepositoryId INT  NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
AssigneeId   INT  NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits
(
Id INT PRIMARY KEY IDENTITY ,
Message VARCHAR(MAX) NOT NULL ,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId  INT NOT NULL FOREIGN KEY REFERENCES Users(Id)

)

CREATE TABLE Files
(
Id   INT PRIMARY KEY IDENTITY ,
Name VARCHAR(100)  NOT NULL ,
Size DECIMAL(18,2) NOT NULL ,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)

--prob02

INSERT INTO Files(Name, Size, ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open', 1,	4),
('Typo fix in Judge.html', 'open',	4, 3),
('Implement documentation for UsersService.cs',	'closed', 8, 2),
('Unreachable code in Index.cs', 'open',	9, 8)

--prob03

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6


--prob04

DELETE FROM RepositoriesContributors WHERE RepositoryId = 3
DELETE FROM Issues WHERE RepositoryId = 3

--prob05

SELECT Id, Message, RepositoryId, ContributorId
FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId

--prob06

SELECT Id, Name, Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id ASC, Name ASC

--prob07

SELECT i.Id, u.Username + ' : ' + i.Title AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, i.AssigneeId ASC


--prob08

SELECT fl.Id, fl.Name, CONCAT(fl.Size , 'KB') AS Size
FROM Files AS f
RIGHT JOIN Files AS fl ON fl.Id = f.ParentId
WHERE f.ParentId IS NULL
ORDER BY fl.Id, fl.Name, fl.Size


--prob09

SELECT TOP(5) r.Id, r.Name, COUNT(c.Id) AS Commits
FROM Repositories AS r
JOIN Commits AS c ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name
ORDER BY Commits DESC, r.Id, r.Name 

--prob10

SELECT U.Username, AVG(F.Size) AS Size
FROM Users AS U
JOIN Commits AS C ON C.ContributorId = U.Id
JOIN Files AS F ON F.CommitId = C.Id
GROUP BY U.Username
ORDER BY Size DESC, U.Username ASC


--prob11




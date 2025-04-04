
CREATE TABLE Clients (
    Id BIGINT PRIMARY KEY,
    ClientName NVARCHAR(200)
);

CREATE TABLE ClientContacts (
    Id BIGINT PRIMARY KEY,
    ClientId BIGINT,
    ContactType NVARCHAR(255),
    ContactValue NVARCHAR(255),
    CONSTRAINT FK_ClientContacts_Clients FOREIGN KEY (ClientId) REFERENCES Clients(Id)
)

-- 1. client names, count and their contacts
SELECT C.ClientName, Count(CC.Id) as ContactCount
FROM Clients C
LEFT JOIN ClientContacts CC ON C.Id = CC.ClientId
GROUP BY C.ClientName, C.Id
ORDER BY C.ClientName;

-- 2. list of clients with more then 2 contacts
SELECT C.ClientName
FROM Clients C
JOIN ClientContacts CC ON C.Id == CC.ClientId
GROUP BY C.ClientName, C.Id
HAVING COUNT(CC.Id) > 2
ORDER BY C.ClientName;
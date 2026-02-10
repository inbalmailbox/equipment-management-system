CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Locations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Equipment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    SerialNumber NVARCHAR(50) NOT NULL UNIQUE,
    PurchaseDate DATE NOT NULL,
    Status INT NOT NULL,
    CategoryId INT NOT NULL,
    LocationId INT NOT NULL,
    CONSTRAINT FK_Equipment_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    CONSTRAINT FK_Equipment_Locations FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);

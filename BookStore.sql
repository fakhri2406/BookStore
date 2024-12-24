CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

CREATE TABLE Books (
    BookId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Publisher NVARCHAR(100) NOT NULL,
    Pages INT NOT NULL,
    Genre NVARCHAR(50) NOT NULL,
    PublicationYear INT NOT NULL,
    Cost DECIMAL(10, 2) NOT NULL,
    SalePrice DECIMAL(10, 2) NOT NULL,
    IsContinuation BIT NOT NULL,
    ContinuationOf INT NULL,
    SalesCount INT NOT NULL DEFAULT 0,
    FOREIGN KEY (ContinuationOf) REFERENCES Books(BookId)
);

CREATE TABLE Purchases (
    PurchaseId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    PurchaseDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);

INSERT INTO Users (Username, Password) VALUES ('admin', 'admin');

SELECT * FROM Users;
SELECT * FROM Books;
SELECT * FROM Purchases;

DROP TABLE Users;
DROP TABLE Books;
DROP TABLE Purchases;
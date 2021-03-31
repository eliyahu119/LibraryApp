
--Create propeties for the Book's table
CREATE TABLE Genres (
    GenreID int IDENTITY(1,1) PRIMARY KEY,
    Genre nvarchar(100) NOT NULL,
);

CREATE TABLE Authors (
    AuthorID int IDENTITY(1,1) PRIMARY KEY,
    Author nvarchar(100) NOT NULL,
);
CREATE TABLE Publishers (
    PublisherID int IDENTITY(1,1) PRIMARY KEY,
    Publisher nvarchar(100) NOT NULL,
);
GO

CREATE TABLE Books (
    BookID int IDENTITY(1,1) PRIMARY KEY,
    Bookname nvarchar(100) NOT NULL,
    GenreID int FOREIGN KEY REFERENCES Genres(GenreID) NOT NULL,
    AuthorID int FOREIGN KEY REFERENCES Authors(AuthorID)  NOT NULL,
    PublisherID int FOREIGN KEY REFERENCES Publishers (PublisherID) NOT NULL,
    PublicationYear smallint NOT NULL
);
GO

--this table Makes every copy of the book as an entety 
CREATE TABLE BooksCopies (
BooksCopyID int IDENTITY(1,1) PRIMARY KEY,
BookID int FOREIGN KEY REFERENCES Books(BookID) NOT NULL,
);

CREATE TABLE Members (
MemberID int IDENTITY(1,1) PRIMARY KEY,
MemberName varchar(100) NOT NULL,
Phone nvarchar(20) NOT NULL,
Adress nvarchar(50) NOT NULL
);
GO

CREATE TABLE Loans(
LoanID int IDENTITY(1,1) PRIMARY KEY,
MemberID int FOREIGN KEY REFERENCES Members(MemberID) NOT NUll,
BooksCopyID int FOREIGN KEY REFERENCES BooksCopies(BooksCopyID) NOT NUll,
LoanDate datetime NOT NULL
)

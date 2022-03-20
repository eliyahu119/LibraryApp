
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
IsAvailable bit DEFAULT 1 NOT NULL, DEFAULT  1
);

CREATE TABLE Members (
MemberID int IDENTITY(1,1) PRIMARY KEY,
MemberName nvarchar(100) NOT NULL,
Phone nvarchar(20) NOT NULL,
Adress nvarchar(50) NOT NULL,
Email nvarchar(50),
personID  bigint NOT NULL UNIQUE 
);
GO

CREATE TABLE Loans(
LoanID int IDENTITY(1,1) PRIMARY KEY,
MemberID int FOREIGN KEY REFERENCES Members(MemberID) NOT NUll,
BooksCopyID int FOREIGN KEY REFERENCES BooksCopies(BooksCopyID) NOT NUll,
LoanDate datetime NOT NULL
);
GO

sp_addmessage @msgnum = 50001,  
              @severity = 16,  
              @msgtext ='can not make the loan, the book is not Available';  
GO
sp_addmessage @msgnum = 50002,  
              @severity = 16,  
              @msgtext = 'can not make the loan, there is more than 2 Lons active';  
GO
--the trigger check if book availble if not it raise an error, else it updates  the Availability of the cop
CREATE TRiGGER CencelLoanIfNotAvailable  ON Loans 
	AFTER INSERT AS 
		BEGIN 
			IF  exists (SELECT * FROM BooksCopies JOIN inserted AS I ON BooksCopies.BooksCopyID =I.BooksCopyID AND BooksCopies.IsAvailable=0)
				BEGIN 
					RAISERROR('can not make the loan, the book is not Available',16,1)
					ROLLBACK TRANSACTION
					RETURN 
				END
			 ELSE 
				BEGIN
					DECLARE @memberID INT;
				    SELECT @memberID= MemberID FROM inserted;
					IF((SELECT dbo.SelectCountActiveLoans(@memberID))>3)
						BEGIN
							RAISERROR('can not make the loan, there is more than 2 Loans active',16,1)
							ROLLBACK TRANSACTION
							RETURN 
						END
					ELSE
						BEGIN 
							SET NOCOUNT ON;
							UPDATE [BooksCopies] SET IsAvailable=0
							FROM INSERTED i
							WHERE [BooksCopies].BooksCopyID=i.BooksCopyID
						END
				END
		END
GO
--returns the number of activeLoans the user Has Made
CREATE FUNCTION dbo.SelectActiveLoans (@memberID INT)
RETURNS INT
AS BEGIN

DECLARE @returnValue INT
SELECT @returnValue=COUNT(*)  FROM Loans T1
		INNER JOIN (SELECT  BooksCopyID , max(LoanDate) AS maxDate FROM Loans GROUP BY BooksCopyID ) tm ON T1.LoanDate=tm.maxDate  
		INNER JOIN BooksCopies ON BooksCopies.BooksCopyID=tm.BooksCopyID
		INNER JOIN Books ON Books.BookID=BooksCopies.BookID
		WHERE BooksCopies.IsAvailable=0 AND T1.MemberID=@memberID;
	
RETURN (@returnValue);
END
Go

-- Declare the variable to be used.
DECLARE @memberID INT;

-- Initialize the variable.
SET @memberID = 5;


SELECT  T1.LoanID,BooksCopies.BooksCopyID,Books.Bookname,T1.LoanDate  FROM Loans T1
INNER JOIN (SELECT  BooksCopyID , max(LoanDate) AS maxDate FROM Loans GROUP BY BooksCopyID ) tm ON T1.LoanDate=tm.maxDate  
INNER JOIN BooksCopies ON BooksCopies.BooksCopyID=tm.BooksCopyID
INNER JOIN Books ON Books.BookID=BooksCopies.BookID
WHERE BooksCopies.IsAvailable=0 AND Loans.MemberID=@memberID;
GO



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
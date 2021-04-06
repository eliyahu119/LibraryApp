-- Declare the variable to be used.
DECLARE @memberID INT;

-- Initialize the variable.
SET @memberID = 5;


SELECT  T1.LoanID,BooksCopies.BooksCopyID,Books.Bookname,T1.LoanDate  from Loans T1
inner join (select  BooksCopyID , max(LoanDate) as maxDate from Loans Group by BooksCopyID ) tm on T1.LoanDate=tm.maxDate  
inner join BooksCopies on BooksCopies.BooksCopyID=tm.BooksCopyID
inner join Books on Books.BookID=BooksCopies.BookID
where BooksCopies.IsAvailable=0 AND MemberID=@memberID;
GO






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
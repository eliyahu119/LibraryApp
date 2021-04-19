sp_addmessage @msgnum = 50001,  
              @severity = 16,  
              @msgtext ='can not make the loan, the book is not Available';  
GO
sp_addmessage @msgnum = 50002,  
              @severity = 16,  
              @msgtext = 'can not make the loan, there is more than 2 Lons active';  
GO
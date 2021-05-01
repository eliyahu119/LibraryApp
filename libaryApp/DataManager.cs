using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace libaryApp
{

    enum SqlErrors
    {
        MAX_LOAN = 50002,
        NOT_AVAILABLE = 50001,
        NOT_EXIST = 547

    }
    /// <summary>
    /// this class is the manager that connects between the DB and the entire project
    /// </summary>
    static public class DataManager
    {

        private static string connectionString;
        const string DbLocation = @"..\..\..\libaryDb.mdf";
        private static string absPAth;
        //   private static SqlConnection connection;
        /// <summary>
        /// private static costructor
        /// </summary>
        static DataManager()
        {

            absPAth = Path.GetFullPath(DbLocation);
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
                                        AttachDbFilename={absPAth};
                                        Integrated Security=True";

        }



        #region loan'sData
        public static List<Loan> getAllLoans(int memberID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT  T1.LoanID,BooksCopies.BooksCopyID,Books.Bookname,T1.LoanDate  FROM Loans T1  
                            INNER JOIN BooksCopies ON BooksCopies.BooksCopyID=T1.BooksCopyID
                            INNER JOIN Books ON Books.BookID=BooksCopies.BookID
                            WHERE  T1.MemberID=@memberID;";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@memberID", memberID);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                var LoanList = new List<Loan>();
                //turn the data into list Of Books.
                while (reader.Read())
                {
                    Loan Loan = GetLoanFromReader(reader);

                    LoanList.Add(Loan);
                }
                return LoanList;

            }
        }

        /// <summary>
        /// check if this book has been loaned  before.
        /// </summary>
        /// <param name="copyID"></param>
        /// <param name="memberID"></param>
        /// <returns></returns>
        internal static bool ifHadBeenLoanBefore(int copyID, int memberID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // l.BooksCopyID = @BooksCopyID AND
                string query = @"SELECT COUNT(*) FROM Loans  l 
              INNER JOIN BooksCopies b on l.BooksCopyID=b.BooksCopyID
              INNER JOIN BOOKS on b.BookID=BOOKS.BookID
              WHERE l.memberID=@memberID AND @BooksCopyID IN (SELECT BooksCopyID FROM BooksCopies WHERE BookID=b.BookID) ;";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@BooksCopyID", copyID);
                sqlCommand.Parameters.AddWithValue("@memberID", memberID);
                var NumberOfRows = (int)sqlCommand.ExecuteScalar();
                return NumberOfRows > 0;
            }
        }


        /// <summary>
        /// get the last member who loan this copy.
        /// </summary>
        /// <param name="BoocCopyID"></param>
        /// <returns></returns>
        public static Member getLastUserUseTheBook(int BoocCopyID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT  Members.MemberID,Members.MemberName,Members.Phone,Members.Adress,Members.PersonID, Members.Email FROM Loans T1
                            INNER JOIN (SELECT  BooksCopyID , max(LoanDate) AS maxDate FROM Loans GROUP BY BooksCopyID ) tm ON T1.LoanDate=tm.maxDate  
                            INNER JOIN Members ON Members.MemberID=T1.MemberID
                            WHERE T1.BooksCopyID=@BoocCopyID;";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@BoocCopyID", BoocCopyID);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                //turn the data into list Of Books.
                Member member = null;
                while (reader.Read())
                {
                    member = getMemberFromReader(reader);
                }


                return member;
            }
        }

        /// <summary>
        /// creates  a loan.
        /// the availability of the book is auto updated do to the trigger UpdateAvailability.
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="copyID"></param>
        static public string CreateLoan(int memberID, int copyID)
        {
            string errString = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Loans(MemberID,BooksCopyID,LoanDate) VALUES (@memberID,@booksCopyID, GETDATE());";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@memberID", memberID);
                    sqlCommand.Parameters.AddWithValue("@booksCopyID", copyID);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();

                }
                catch (SqlException error)
                {
                    switch (error.Number)
                    {
                        case (int)SqlErrors.NOT_AVAILABLE:
                            errString = "עותק זה לא זמין להשאלה";
                            break;
                        case (int)SqlErrors.MAX_LOAN:
                            errString = "לא ניתן לבצע השאלה נוספת, מספר השאלות מקסימלי הגיע למנוי זה";
                            break;
                        case (int)SqlErrors.NOT_EXIST:
                            if (error.Message.Contains("BooksCopies"))
                            {
                                errString = "עותק אינו קיים במערכת";

                            }
                            if (error.Message.Contains("Members"))
                            {
                                errString = " מספר מנוי זה אינו תקין ";
                            }
                            break;
                        default:
                            errString = "שגיאה בהשאלה";
                            break;

                    }

                }
                return errString;

            }
        }

            /// <summary>
            /// get the list of active loans base on memberID
            /// </summary>
            /// <param name="memberID"></param>
            /// <returns></returns>
            public static List<Loan> GetActiveLoans(int memberID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT  T1.LoanID,BooksCopies.BooksCopyID,Books.Bookname,T1.LoanDate  FROM Loans T1
                            INNER JOIN (select  BooksCopyID , max(LoanDate) AS maxDate FROM Loans GROUP BY BooksCopyID ) tm ON T1.LoanDate=tm.maxDate  
                            INNER JOIN BooksCopies ON BooksCopies.BooksCopyID=tm.BooksCopyID
                            INNER JOIN Books ON Books.BookID=BooksCopies.BookID
                            WHERE BooksCopies.IsAvailable=0 AND T1.MemberID=@memberID;";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@memberID", memberID);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    var LoanList = new List<Loan>();
                    //turn the data into list Of Books.
                    while (reader.Read())
                    {
                        Loan Loan = GetLoanFromReader(reader);

                        LoanList.Add(Loan);
                    }
                    connection.Close();
                    return LoanList;
                }
            }
            /// <summary>
            /// get Loan From Reader
            /// </summary>
            /// <param name="reader"></param>
            /// <returns></returns>
            private static Loan GetLoanFromReader(SqlDataReader reader)
            {
                var Loan = new Loan();
                Loan.LoanID = (int)reader["LoanID"];
                Loan.CopyID = (int)reader["BooksCopyID"];
                Loan.BookName = reader["Bookname"].ToString();
                Loan.dateOfLoan = (DateTime)reader["LoanDate"];
                return Loan;
            }
            #endregion



            #region book's Data
            /// <summary>
            /// edit the book in the db
            /// </summary>
            /// <param name="bookId"></param>
            /// <param name="bookName"></param>
            /// <param name="genere"></param>
            /// <param name="author"></param>
            /// <param name="publisher"></param>
            /// <param name="publicationYear"></param>
            /// <returns></returns>
            public static Book EditBookInDB(int bookId, string bookName, Generes genere, Authors author, Publishers publisher, short publicationYear)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Books
                SET BookName=@BookName,GenreID=@GenereID,AuthorID=@AuthorID,PublisherID=@PublisherID,PublicationYear=@PublicationYear
                OUTPUT inserted.Bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,inserted.PublicationYear, inserted.BookID, Genres.GenreID, Publishers.PublisherID, Authors.AuthorID
                FROM Books b
                INNER JOIN Genres ON  b.GenreID = Genres.GenreID 
                INNER JOIN Publishers ON  Publishers.PublisherID = b.PublisherID 
                INNER JOIN Authors ON Authors.AuthorID = b.AuthorID
                WHERE b.BookID=@Bookid;";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@BookName", bookName);
                    sqlCommand.Parameters.AddWithValue("@GenereID", genere.ID);
                    sqlCommand.Parameters.AddWithValue("@AuthorID", author.ID);
                    sqlCommand.Parameters.AddWithValue("@PublisherID", publisher.ID);
                    sqlCommand.Parameters.AddWithValue("@PublicationYear", publicationYear);
                    sqlCommand.Parameters.AddWithValue("@Bookid", bookId);
                    Book Updated = null;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {

                        Updated = getBookFromReader(reader);
                    }
                    connection.Close();
                    return Updated;

                }
            }


            public static Book AddBookToDB(string bookName, Generes genere, Authors author, Publishers publisher, short publicationYear)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Book book = null;
                    SqlCommand insertTODB = new SqlCommand(@"WITH Source
     AS (SELECT v.Bookname,v.GenreID,v.AuthorID,v.PublisherID,v.PublicationYear,Genres.Genre,Publishers.Publisher,Authors.Author
         FROM  (VALUES(@Bookname,@GenreID,@AuthorID,@PublisherID,@PublicationYear)) 
                    V(Bookname,GenreID,AuthorID,PublisherID,PublicationYear)
					INNER JOIN Genres ON  v.GenreID =Genres.GenreID 
					INNER JOIN Publishers ON  Publishers.PublisherID = v.PublisherID 
					INNER JOIN Authors ON Authors.AuthorID = v.AuthorID)
MERGE INTO Books
USING Source
ON 1 = 0
WHEN NOT MATCHED THEN
  INSERT (Bookname,
           GenreID,
           AuthorID,
		   PublisherID,
		   PublicationYear)
  VALUES (Bookname,
		  GenreID,
		  AuthorID,
		  PublisherID,
		  PublicationYear)

OUTPUT Source.*,INSERTED.BookID;", connection);
                    insertTODB.Parameters.AddWithValue("@Bookname", bookName);
                    insertTODB.Parameters.AddWithValue("@GenreID", genere.ID);
                    insertTODB.Parameters.AddWithValue("@AuthorID", author.ID);
                    insertTODB.Parameters.AddWithValue("@PublisherID", publisher.ID);
                    insertTODB.Parameters.AddWithValue("@PublicationYear", publicationYear);
                    var reader = insertTODB.ExecuteReader();
                    while (reader.Read())
                    {
                        book = getBookFromReader(reader);
                    }
                    connection.Close();
                    return book;
                }
            }

            public static void DeleteBookFromDB(int bookID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"DELETE FROM Loans WHERE BooksCopyID IN (SELECT BooksCopyID FROM BooksCopies WHERE BookID=@BookID)
                             DELETE FROM BooksCopies WHERE BookID=@BookID;
                             DELETE FROM Books WHERE BookID=@BookID;";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@BookID", bookID);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }

            /// <summary>
            /// search the books base on the Author or the name of the book.
            /// </summary>
            /// <param name="condition"></param>
            /// <returns></returns>
            static public List<Book> GetBooksFromDB(string condition = "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //get the data from the sql
                    string query = "SELECT b.bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,b.PublicationYear, b.BookID, Genres.GenreID, Publishers.PublisherID, Authors.AuthorID "
                                                      + "FROM Books b "
                                                      + "INNER JOIN Genres ON  b.GenreID = Genres.GenreID "
                                                      + "INNER JOIN Publishers ON  Publishers.PublisherID = b.PublisherID "
                                                      + "INNER JOIN Authors ON Authors.AuthorID = b.AuthorID";
                    query = $"{query} WHERE b.bookname LIKE N'%'+@c+'%'  OR Authors.Author LIKE N'%'+@c+'%'";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@c", condition);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    var booksList = new List<Book>();
                    //turn the data into list Of Books.
                    while (reader.Read())
                    {
                        Book Book = getBookFromReader(reader);

                        booksList.Add(Book);
                    }
                    connection.Close();
                    return booksList;
                }
            }

            /// <summary>
            /// gets the book From the reader
            /// </summary>
            /// <param name="reader"></param>
            /// <returns></returns>
            private static Book getBookFromReader(SqlDataReader reader)
            {
                var Book = new Book();
                Book.BookName = reader["bookname"].ToString();
                Book.Genre = new Generes((int)reader["GenreID"], reader["Genre"].ToString());
                Book.Author = new Authors((int)reader["AuthorID"], reader["Author"].ToString());
                Book.Publisher = new Publishers((int)reader["PublisherID"], reader["Publisher"].ToString());
                Book.PublicationYear = (short)reader["PublicationYear"];
                Book.bookId = (int)reader["BookID"];
                return Book;
            }




            #endregion


            #region Member's Data

            /// <summary>
            /// add member to Db and returning his memberID and if added or not.
            /// </summary>
            /// <param name="memberName"></param>
            /// <param name="personID"></param>
            /// <param name="phoneNunber"></param>
            /// <param name="Adress"></param>
            /// <param name="isAdded"></param>
            /// <returns></returns>
            public static Member AddMember(string memberName, string personID, string phoneNunber, string Adress, out bool isAdded, string EmailtextBox = null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    bool IfExist = IfItemExist(personID, "Members", "PersonID");
                    if (IfExist)
                    {
                        isAdded = false;
                        return null;
                    }
                    string query = @"INSERT INTO Members(MemberName,Phone,Adress,PersonID,Email) 
                             OUTPUT Inserted.MemberID,Inserted.MemberName,Inserted.Phone,Inserted.Adress,Inserted.PersonID,Inserted.Email
                             VALUES(@MemberName,@Phone,@Adress,@PersonID,@Email)";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@MemberName", memberName);
                    sqlCommand.Parameters.AddWithValue("@Phone", phoneNunber);
                    sqlCommand.Parameters.AddWithValue("@PersonID", personID);
                    sqlCommand.Parameters.AddWithValue("@Adress", Adress);
                    sqlCommand.Parameters.AddWithValue("@Email", EmailtextBox);
                    SqlDataReader reader = sqlCommand.ExecuteReader();


                    Member member = null;

                    while (reader.Read())
                    {
                        member = getMemberFromReader(reader);

                    }

                    isAdded = member != null;


                    connection.Close();
                    return member;
                }
            }

            /// <summary>
            /// edit member query.
            /// </summary>
            /// <param name="member"></param>
            /// <param name="FullName"></param>
            /// <param name="personID"></param>
            /// <param name="phone"></param>
            /// <param name="Adress"></param>
            /// <param name="isUpdate"></param>
            /// <returns></returns>
            public static Member EditMember(Member member, string FullName, long personID, string phone, string Adress, string Email, out bool isUpdate)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Members
                            SET MemberName=@MemberName,Phone=@phone,Adress=@Adress,PersonID=@personID,Email=@Email
                            OUTPUT INSERTED.MemberID,INSERTED.MemberName,INSERTED.Phone,INSERTED.Adress,INSERTED.PersonID,INSERTED.Email
                            WHERE MemberID=@MemberID";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@MemberName", FullName);
                    sqlCommand.Parameters.AddWithValue("@Phone", phone);
                    sqlCommand.Parameters.AddWithValue("@PersonID", personID);
                    sqlCommand.Parameters.AddWithValue("@Adress", Adress);
                    sqlCommand.Parameters.AddWithValue("@MemberID", member.MemberID);
                    sqlCommand.Parameters.AddWithValue("@Email", Email);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    Member UpdatedMember = null;
                    try
                    {
                        while (reader.Read())
                        {

                            UpdatedMember = getMemberFromReader(reader);




                        }
                    }
                    catch
                    {

                    }
                    isUpdate = !(UpdatedMember == null);
                    connection.Close();
                    return UpdatedMember;

                }
            }
            /// <summary>
            /// get member data from sqlReader.
            /// </summary>
            /// <param name="reader"></param>
            /// <returns></returns>
            private static Member getMemberFromReader(SqlDataReader reader)
            {

                var member = new Member();
                member.MemberID = (int)reader["MemberID"];
                member.memberName = reader["MemberName"].ToString();
                member.Phone = reader["Phone"].ToString();
                member.Adress = reader["Adress"].ToString();
                member.PersonID = (long)reader["PersonID"];
                member.Email = reader["Email"].ToString();
                return member;
            }


            /// <summary>
            /// get Member base on his memberId
            /// </summary>
            /// <param name="ID"></param>
            /// <returns></returns>
            public static Member GetMemberByMemberID(long ID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MemberID,MemberName,Phone,Adress,PersonID,Email FROM Members";
                    query = $"{query} WHERE MemberID=@ID";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //turn the data into list Of Books.
                    Member member = null;

                    while (reader.Read())
                    {
                        member = getMemberFromReader(reader);
                    }
                    connection.Close();
                    return member;

                }
            }
            /// <summary>
            /// search by person id as well as member id
            /// </summary>
            /// <param name="ID"></param>
            /// <returns></returns>
            public static List<Member> GetMembersByID(long ID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MemberID,MemberName,Phone,Adress,PersonID,Email FROM Members";
                    query = $"{query} WHERE MemberID=@ID OR PersonID=@ID ";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@ID", ID);
                    SqlDataReader reader = sqlCommand.ExecuteReader();


                    var memberList = new List<Member>();
                    //turn the data into list Of members.
                    while (reader.Read())
                    {
                        var member = getMemberFromReader(reader);
                        memberList.Add(member);
                    }
                    connection.Close();
                    return memberList;
                }
            }



            /// <summary>
            /// search the Member base on the Member's name..
            /// </summary>
            /// <param name="condition"></param>
            /// <returns></returns>
            static public List<Member> GetMembersFromDb(string condition = "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //get the data from the sql
                    string query = "SELECT MemberID,MemberName,Phone,Adress,PersonID,Email FROM Members";
                    query = $"{query} WHERE MemberName LIKE N'%'+@c+'%'";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@c", condition);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    var memberList = new List<Member>();
                    //turn the data into list Of members.
                    while (reader.Read())
                    {
                        var member = getMemberFromReader(reader);
                        memberList.Add(member);
                    }
                    connection.Close();
                    return memberList;
                }
            }
            /// <summary>
            /// delete the member from the db
            /// </summary>
            /// <param name="memberID"></param>
            public static void DeleteMemberFromDB(int memberID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"DELETE FROM Loans WHERE MemberID=@memberID;
                             DELETE FROM Members WHERE MemberID=@memberID;";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@memberID", memberID);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }


            #endregion


            #region copy's data
            /// <summary>
            /// sets the availability of the book to true in DB.
            /// </summary>
            /// <param name="bookCopyID"></param>
            /// <returns></returns>
            public static bool returnCopyToShelf(int bookCopyID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE[BooksCopies] SET IsAvailable = 1 WHERE [BooksCopies].BooksCopyID = @ID AND IsAvailable = 0";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@ID", bookCopyID);
                    var NumberOfRows = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    return NumberOfRows > 0;
                }

            }

            /// <summary>
            /// sets the availability of the book to true in DB. and gets the book name.
            /// </summary>
            /// <param name="bookCopyID"></param>
            /// <param name="bookName"></param>
            /// <returns></returns>
            public static bool returnCopyToShelf(int bookCopyID, out string bookName)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE [BooksCopies] SET IsAvailable = 1  
                            OUTPUT B.Bookname 
                            FROM [BooksCopies] BC
                            JOIN Books B ON B.BookID=BC.BookID WHERE BC.BooksCopyID = @ID AND IsAvailable = 0  ";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@ID", bookCopyID);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    bookName = "";

                    while (reader.Read())
                    {
                        bookName = reader[0].ToString();
                    }
                    connection.Close();
                    return bookName != "" ? true : false;

                }
            }



            ///// <summary>
            ///// check if book is avialbe base on  ISAvailable column
            ///// </summary>
            ///// <param name="copyID"></param>
            ///// <returns></returns>
            //public static bool IsCopyAvailable(int copyID)
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        string query = $"SELECT COUNT(*) FROM BooksCopies WHERE BooksCopyID=@ID AND ISAvailable=0;";
            //        SqlCommand sqlCommand = new SqlCommand(query, connection);
            //        sqlCommand.Parameters.AddWithValue("@ID", copyID);
            //        var NumberOfRows = (int)sqlCommand.ExecuteScalar();
            //        connection.Close();
            //        return !(NumberOfRows > 0);
            //    }

            //}







            /// <summary>
            /// get the number of book's copy available
            /// </summary>
            /// <param name="bookID"></param>
            /// <returns></returns>
            static public int GetNumberOfCopiesavailable(int bookID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(IsAvailable)  FROM  BooksCopies WHERE BookID=@BookID AND IsAvailable=@true";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@BookID", bookID);
                    sqlCommand.Parameters.AddWithValue("@true", 1);
                    int AvailableBooks = (Int32)sqlCommand.ExecuteScalar();
                    connection.Close();
                    return AvailableBooks;
                }
            }

            public static void AddCopiesToDb(int numberOfCopies, int bookid)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    ///add the copies to db
                    SqlCommand insertCopies = new SqlCommand("INSERT INTO [BooksCopies]([BookID]) VALUES(@bookID)", connection);
                    insertCopies.Parameters.AddWithValue("@bookID", bookid);
                    for (int j = 0; j < numberOfCopies; j++)
                    {
                        insertCopies.ExecuteNonQuery();

                    }
                    connection.Close();
                }
            }

            /// <summary>
            /// makes a query to the db and get all the copies ralated to the book.
            /// </summary>
            /// <param name="bookID"></param>
            /// <returns></returns>
            static public List<BookCopies> getBookCopiesFromDB(int bookID)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT  BooksCopyID, IsAvailable  FROM  BooksCopies WHERE BookID=@BookID";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@BookID", bookID);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    var bookCopiesList = new List<BookCopies>();
                    while (reader.Read())
                    {
                        var bookCopy = new BookCopies(bookID, (int)reader[0], (bool)reader[1]);

                        bookCopiesList.Add(bookCopy);

                    }
                    connection.Close();
                    return bookCopiesList;
                }
            }
            #endregion










            /// <summary>
            /// check if item  exist in db
            /// </summary>
            /// <param name="Element"></param>
            /// <param name="table"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public static bool IfItemExist(object Element, string table, string column)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT COUNT(*) FROM {table} WHERE {column}=@ID;";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@ID", Element);
                    var NumberOfRows = (int)sqlCommand.ExecuteScalar();
                    connection.Close();

                    return NumberOfRows > 0;
                }
            }



            /// <summary>
            /// adds the book to Db
            /// </summary>
            /// <param name="bookName"></param>
            /// <param name="genere"></param>
            /// <param name="author"></param>
            /// <param name="publisher"></param>
            /// <param name="publicationYear"></param>
            /// <param name="numberOfCopies"></param>
            public static Book AddBookToDBAndUpdateCopies(string bookName, Generes genere, Authors author, Publishers publisher, short publicationYear, int numberOfCopies)
            {
                Book book = AddBookToDB(bookName, genere, author, publisher, publicationYear);
                AddCopiesToDb(numberOfCopies, book.getBookID());
                return book;
            }


            /// <summary>
            /// get BookAttributes classes's bindingList from DB
            /// </summary>
            /// <returns></returns>
            static public BindingList<BookAttributes> GetAttributesFromDB<T>() where T : BookAttributes
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //check which subClasses T is.
                    string table, idcolumn, valuecolumn;
                    getDBStructureDataBaseOnType(out table, out idcolumn, out valuecolumn, typeof(T));

                    string query = $"SELECT  {idcolumn}, {valuecolumn}  FROM {table}";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    //using polymorphism and using T as BookAttributes
                    var List = new BindingList<BookAttributes>();
                    while (reader.Read())
                    {
                        var item = (T)Activator.CreateInstance(typeof(T), new object[] { (int)reader[0], (string)reader[1] });
                        List.Add(item);

                    }
                    connection.Close();
                    return List;
                }
            }

            /// <summary>
            /// insert bookAttirbute to the DB
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="value"></param>
            static public void AddBookAttributesToDB(string value, Type t)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string table, idcolumn, valuecolumn;
                    getDBStructureDataBaseOnType(out table, out idcolumn, out valuecolumn, t);
                    string query = $"INSERT INTO  {table} ( {valuecolumn}) VALUES(@value) ";
                    connection.Open();
                    SqlCommand insertTODB = new SqlCommand(query, connection);
                    insertTODB.Parameters.AddWithValue("@value", value);
                    insertTODB.ExecuteNonQuery();
                    connection.Close();

                }
            }

            /// <summary>
            /// get db structure data like tableName based on the type.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="table"></param>
            /// <param name="idcolumn"></param>
            /// <param name="valuecolumn"></param>
            private static void getDBStructureDataBaseOnType(out string table, out string idcolumn, out string valuecolumn, Type T)
            {
                table = "";
                idcolumn = "";
                valuecolumn = "";
                if (T.Equals(typeof(Generes)))
                {
                    table = "Genres";
                    idcolumn = "GenreID";
                    valuecolumn = "Genre";
                }
                else if (T.Equals(typeof(Authors)))
                {
                    table = "Authors";
                    idcolumn = "AuthorId";
                    valuecolumn = "Author";
                }
                else if (T.Equals(typeof(Publishers)))
                {
                    table = "Publishers";
                    idcolumn = "PublisherID";
                    valuecolumn = "Publisher";
                }
            }


        }

    }
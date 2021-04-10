using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace libaryApp
{

    /// <summary>
    /// this class is the manager that connects between the DB and the entire project
    /// </summary>
    static public class DataManager
    {

        private static SqlConnection Connection;
        const string DbLocation = @"..\..\..\libaryDb.mdf";

        public static List<Loan> getAllLoans(int memberID)
        {

            string query = @"SELECT  T1.LoanID,BooksCopies.BooksCopyID,Books.Bookname,T1.LoanDate  FROM Loans T1  
                            INNER JOIN BooksCopies ON BooksCopies.BooksCopyID=T1.BooksCopyID
                            INNER JOIN Books ON Books.BookID=BooksCopies.BookID
                            WHERE  T1.MemberID=@memberID;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@memberID", memberID);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var LoanList = new List<Loan>();
            //turn the data into list Of Books.
            while (reader.Read())
            {
                Loan Loan = GetLoanFromReader(reader);

                LoanList.Add(Loan);
            }
            Connection.Close();
            return LoanList;

        }

        /// <summary>
        /// check if this book has been loaned  before.
        /// </summary>
        /// <param name="copyID"></param>
        /// <param name="memberID"></param>
        /// <returns></returns>
        internal static bool ifHadBeenLoanBefore(int copyID, int memberID)
        {

            string query = @"SELECT COUNT(*) FROM Loans  l 
              LEFT JOIN BooksCopies b on l.BooksCopyID=b.BooksCopyID
              LEFT JOIN BOOKS on b.BookID=BOOKS.BookID
              WHERE l.BooksCopyID=@BooksCopyID AND l.memberID=@memberID;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@BooksCopyID", copyID);
            sqlCommand.Parameters.AddWithValue("@memberID", memberID);
            var NumberOfRows = (int)sqlCommand.ExecuteScalar();
            Connection.Close();
            if (NumberOfRows > 0)
            {
                return true;
            }
            return false ;
        }

        /// <summary>
        /// private static costructor
        /// </summary>
        static DataManager()
        {
            string absPAth = Path.GetFullPath(DbLocation);
            string ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
                                        AttachDbFilename={absPAth};
                                        Integrated Security=True";
            Connection = new SqlConnection(ConnectionString);
        }


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
            bool IfExist = IfItemExist(personID, "Members", "PersonID");
            if (IfExist)
            {
                isAdded = false;
                return null;
            }
            string query = @"INSERT INTO Members(MemberName,Phone,Adress,PersonID,Email) 
                             OUTPUT Inserted.MemberID,Inserted.MemberName,Inserted.Phone,Inserted.Adress,Inserted.PersonID
                             VALUES(@MemberName,@Phone,@Adress,@PersonID,@Email)";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@MemberName", memberName);
            sqlCommand.Parameters.AddWithValue("@Phone", phoneNunber);
            sqlCommand.Parameters.AddWithValue("@PersonID", personID);
            sqlCommand.Parameters.AddWithValue("@Adress", Adress);
            sqlCommand.Parameters.AddWithValue("@Email", Adress);
            SqlDataReader reader = sqlCommand.ExecuteReader();


            Member member = null;

            while (reader.Read())
            {
                member = getMemberFromReader(reader);

            }
            if (member == null)
            {
                isAdded = false;
            }
            else
            {
                isAdded = true;
            }
            Connection.Close();
            return member;
        }

        public static void EditBookInDB(int bookId, string bookName, Generes genere, Authors author, Publishers publisher, short publicationYear)
        {
            string query = @"UPDATE Books
                            SET BookName=@BookName,GenereID=@phone,AuthorID=@AuthorID,PublisherID=@PublisherID,PublicationYear=@PublicationYear
   
                              OUTPUT B.Bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,b.PublicationYear, b.BookID, Genres.GenreID, Publishers.PublisherID, Authors.AuthorID
                            FROM [Bookname] B
                            LEFT JOIN Genres ON  b.GenreID = Genres.GenreID 
                            LEFT JOIN Publishers ON  Publishers.PublisherID = b.PublisherID 
                            LEFT JOIN Authors ON Authors.AuthorID = b.AuthorID; ";
            OUTPUT INSERTED.MemberID,INSERTED.MemberName,INSERTED.Phone,INSERTED.Adress,INSERTED.PersonID,INSERTED.Email
                            
                            WHERE MemberID=@MemberID";

            sqlCommand.Parameters.AddWithValue("@BookName", bookName);
            sqlCommand.Parameters.AddWithValue("@GenereID", genere.ID);
            sqlCommand.Parameters.AddWithValue("@AuthorID", author.ID);
            sqlCommand.Parameters.AddWithValue("@PublisherID", publisher.ID);
            sqlCommand.Parameters.AddWithValue("@PublicationYear", publicationYear) ;

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
        public static Member EditMember(Member member, string FullName, long personID, string phone, string Adress,string Email, out bool isUpdate)
        {

            string query = @"UPDATE Members
                            SET MemberName=@MemberName,Phone=@phone,Adress=@Adress,PersonID=@personID,Email=@Email
                            OUTPUT INSERTED.MemberID,INSERTED.MemberName,INSERTED.Phone,INSERTED.Adress,INSERTED.PersonID,INSERTED.Email
                            WHERE MemberID=@MemberID";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
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
            if (UpdatedMember == null)
            {
                isUpdate = false;
            }
            else
            {
                isUpdate = true;
            }
            Connection.Close();
            return UpdatedMember;

        }


        /// <summary>
        /// get the last member who loan this copy.
        /// </summary>
        /// <param name="BoocCopyID"></param>
        /// <returns></returns>
        public static Member getLastUserUseTheBook(int BoocCopyID)
        {
            string query = @"SELECT  Members.MemberID,Members.MemberName,Members.Phone,Members.Adress,Members.PersonID  FROM Loans T1
                            INNER JOIN (SELECT  BooksCopyID , max(LoanDate) AS maxDate FROM Loans GROUP BY BooksCopyID ) tm ON T1.LoanDate=tm.maxDate  
                            INNER JOIN Members ON Members.MemberID=T1.MemberID
                            WHERE T1.BooksCopyID=@BoocCopyID;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@BoocCopyID", BoocCopyID);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //turn the data into list Of Books.
            Member member = null;
            while (reader.Read())
            {
                member = getMemberFromReader(reader);
            }

            Connection.Close();
            return member;
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
            member.Email= reader["Email"].ToString(); 
            return member;
        }

        /// <summary>
        /// get the list of active loans base on memberID
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public static List<Loan> GetActiveLoans(int memberID)
        {

            string query = @"SELECT  T1.LoanID,BooksCopies.BooksCopyID,Books.Bookname,T1.LoanDate  FROM Loans T1
                            INNER JOIN (select  BooksCopyID , max(LoanDate) AS maxDate FROM Loans GROUP BY BooksCopyID ) tm ON T1.LoanDate=tm.maxDate  
                            INNER JOIN BooksCopies ON BooksCopies.BooksCopyID=tm.BooksCopyID
                            INNER JOIN Books ON Books.BookID=BooksCopies.BookID
                            WHERE BooksCopies.IsAvailable=0 AND T1.MemberID=@memberID;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@memberID", memberID);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var LoanList = new List<Loan>();
            //turn the data into list Of Books.
            while (reader.Read())
            {
                Loan Loan = GetLoanFromReader(reader);

                LoanList.Add(Loan);
            }
            Connection.Close();
            return LoanList;
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

        /// <summary>
        /// get Member base on his memberId
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Member GetMemberByID(long ID)
        {
            string query = "SELECT MemberID,MemberName,Phone,Adress,PersonID,Email FROM Members";
            query = $"{query} WHERE MemberID=@ID";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //turn the data into list Of Books.
            Member member = null;

            while (reader.Read())
            {
                member = getMemberFromReader(reader);
            }
            Connection.Close();
            return member;

        }
        /// <summary>
        /// search by person id as well as member id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static List<Member> GetMembersByID(long ID)
        {
            string query = "SELECT MemberID,MemberName,Phone,Adress,PersonID,Email FROM Members";
            query = $"{query} WHERE MemberID=@ID OR PersonID=@ID ";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@ID", ID);
            SqlDataReader reader = sqlCommand.ExecuteReader();

      
            var memberList = new List<Member>();
            //turn the data into list Of members.
            while (reader.Read())
            {
                var member = getMemberFromReader(reader);
                memberList.Add(member);
            }
            Connection.Close();
            return memberList;

        }

        /// <summary>
        /// sets the availability of the book to true in DB.
        /// </summary>
        /// <param name="bookCopyID"></param>
        /// <returns></returns>
        public static bool returnBookToShelf(int bookCopyID)
        {
            string query = "UPDATE[BooksCopies] SET IsAvailable = 1 WHERE [BooksCopies].BooksCopyID = @ID AND IsAvailable = 0";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@ID", bookCopyID);
            var NumberOfRows = sqlCommand.ExecuteNonQuery();
            Connection.Close();
            if (NumberOfRows > 0)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// sets the availability of the book to true in DB. and gets the book name.
        /// </summary>
        /// <param name="bookCopyID"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public static bool returnBookToShelf(int bookCopyID, out string bookName)
        {
            string query = @"UPDATE [BooksCopies] SET IsAvailable = 1  
                            OUTPUT B.Bookname 
                            FROM [BooksCopies] BC
                            JOIN Books B ON B.BookID=BC.BookID WHERE BC.BooksCopyID = @ID AND IsAvailable = 0  ";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@ID", bookCopyID);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bookName = "";

            while (reader.Read())
            {
                bookName = reader[0].ToString();
            }
            Connection.Close();
            if (bookName != "")
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// check if item  exist in db
        /// </summary>
        /// <param name="Element"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool IfItemExist(object Element, string table, string column)
        {
            string query = $"SELECT COUNT(*) FROM {table} WHERE {column}=@ID;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@ID", Element);
            var NumberOfRows = (int)sqlCommand.ExecuteScalar();
            Connection.Close();
            if (NumberOfRows > 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// check if book is avialbe base on  ISAvailable column
        /// </summary>
        /// <param name="copyID"></param>
        /// <returns></returns>
        public static bool IsBookAvailable(int copyID)
        {
            string query = $"SELECT COUNT(*) FROM BooksCopies WHERE BooksCopyID=@ID AND ISAvailable=0;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@ID", copyID);
            var NumberOfRows = (int)sqlCommand.ExecuteScalar();
            Connection.Close();
            if (NumberOfRows > 0)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// creates  a loan.
        /// the availability of the book is auto updated do to the trigger UpdateAvailability.
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="copyID"></param>
        static public void CreateLoan(int memberID, int copyID)
        {
            string query = "INSERT INTO Loans(MemberID,BooksCopyID,LoanDate) VALUES (@memberID,@booksCopyID, GETDATE());";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@memberID", memberID);
            sqlCommand.Parameters.AddWithValue("@booksCopyID", copyID);
            sqlCommand.ExecuteNonQuery();
            Connection.Close();

        }

        /// <summary>
        /// search the books base on the Author or the name of the book.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        static public List<Book> GetBooksFromDB(string condition = "")
        {
            //get the data from the sql
            string query = "SELECT b.bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,b.PublicationYear, b.BookID, Genres.GenreID, Publishers.PublisherID, Authors.AuthorID "
                                                  + "FROM Books b "
                                                  + "LEFT JOIN Genres ON  b.GenreID = Genres.GenreID "
                                                  + "LEFT JOIN Publishers ON  Publishers.PublisherID = b.PublisherID "
                                                  + "LEFT JOIN Authors ON Authors.AuthorID = b.AuthorID";
            query = $"{query} WHERE b.bookname LIKE N'%'+@c+'%'  OR Authors.Author LIKE N'%'+@c+'%'";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@c", condition);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var booksList = new List<Book>();
            //turn the data into list Of Books.
            while (reader.Read())
            {
                var Book = new Book();
                Book.BookName = reader["bookname"].ToString();
                Book.Genre =new Generes((int)reader["GenreID"], reader["Genre"].ToString());
                Book.Author =new Authors((int)reader["AuthorID"], reader["Author"].ToString());
                Book.Publisher = new Publishers((int)reader["PublisherID"], reader["Publisher"].ToString());
                Book.PublicationYear = (short)reader["PublicationYear"];
                Book.bookId = (int)reader["BookID"];
                

                booksList.Add(Book);
            }
            Connection.Close();
            return booksList;

        }


        /// <summary>
        /// search the Member base on the Member's name..
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        static public List<Member> GetMembersFromDb(string condition = "")
        {
            //get the data from the sql
            string query = "SELECT MemberID,MemberName,Phone,Adress,PersonID,Email FROM Members";
            query = $"{query} WHERE MemberName LIKE N'%'+@c+'%'";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@c", condition);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var memberList = new List<Member>();
            //turn the data into list Of members.
            while (reader.Read())
            {
                var member = getMemberFromReader(reader);
                memberList.Add(member);
            }
            Connection.Close();
            return memberList;
        }

        /// <summary>
        /// get the number of book's copy available
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        static public int GetNumberOfCopiesavailable(int bookID)
        {
            Connection.Open();
            string query = "SELECT COUNT(IsAvailable)  FROM  BooksCopies WHERE BookID=@BookID AND IsAvailable=@true";
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@BookID", bookID);
            sqlCommand.Parameters.AddWithValue("@true", 1);
            int AvailableBooks = (Int32)sqlCommand.ExecuteScalar();
            Connection.Close();
            return AvailableBooks;
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
        internal static void AddBookToDB(string bookName, Generes genere, Authors author, Publishers publisher, short publicationYear, int numberOfCopies)
        {
            Connection.Open();
            SqlCommand insertTODB = new SqlCommand(@"INSERT INTO [Books]([Bookname],[GenreID],[AuthorID],[PublisherID],[PublicationYear] )
                                                    OUTPUT Inserted.BookID VALUES(@Bookname,@GenreID,@AuthorID,@PublisherID,@PublicationYear)", Connection);
            insertTODB.Parameters.AddWithValue("@Bookname", bookName);
            insertTODB.Parameters.AddWithValue("@GenreID", genere.ID);
            insertTODB.Parameters.AddWithValue("@AuthorID", author.ID);
            insertTODB.Parameters.AddWithValue("@PublisherID", publisher.ID);
            insertTODB.Parameters.AddWithValue("@PublicationYear", publicationYear);
            int BookID = (int)insertTODB.ExecuteScalar();

            ///add the copies to db
            SqlCommand insertCopies = new SqlCommand("INSERT INTO [BooksCopies]([BookID]) VALUES(@bookID)", Connection);
            insertCopies.Parameters.AddWithValue("@bookID", BookID);
            for (int j = 0; j < numberOfCopies; j++)
            {
                insertCopies.ExecuteNonQuery();


            }
            Connection.Close();

        }

        /// <summary>
        /// makes a query to the db and get all the copies ralated to the book.
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        static public List<BookCopies> getBookCopiesFromDB(int bookID)
        {

            string query = "SELECT  BooksCopyID, IsAvailable  FROM  BooksCopies WHERE BookID=@BookID";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@BookID", bookID);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var bookCopiesList = new List<BookCopies>();
            while (reader.Read())
            {
                var bookCopy = new BookCopies(bookID, (int)reader[0], (bool)reader[1]);

                bookCopiesList.Add(bookCopy);

            }
            Connection.Close();
            return bookCopiesList;
        }




        /// <summary>
        /// get BookAttributes classes's bindingList from DB
        /// </summary>
        /// <returns></returns>
        static public BindingList<BookAttributes> GetAttributesFromDB<T>() where T : BookAttributes
        {
            //check which subClasses T is.
            string table, idcolumn, valuecolumn;
            getDBStructureDataBaseOnType(out table, out idcolumn, out valuecolumn, typeof(T));

            string query = $"SELECT  {idcolumn}, {valuecolumn}  FROM {table}";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            //using polymorphism and using T as BookAttributes
            var List = new BindingList<BookAttributes>();
            while (reader.Read())
            {
                var item = (T)Activator.CreateInstance(typeof(T), new object[] { (int)reader[0], (string)reader[1] });
                List.Add(item);

            }
            Connection.Close();
            return List;
        }

        /// <summary>
        /// insert bookAttirbute to the DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        static public void AddBookAttributesToDB(string value, Type t)
        {
            string table, idcolumn, valuecolumn;
            getDBStructureDataBaseOnType(out table, out idcolumn, out valuecolumn, t);
            string query = $"INSERT INTO  {table} ( {valuecolumn}) VALUES(@value) ";
            Connection.Open();
            SqlCommand insertTODB = new SqlCommand(query, Connection);
            insertTODB.Parameters.AddWithValue("@value", value);
            insertTODB.ExecuteNonQuery();
            Connection.Close();

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
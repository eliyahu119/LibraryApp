using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace libaryApp
{

    /// <summary>
    /// This class is the manager that connects between the DB and the entire project.
    /// </summary>
    static public class DataManager
    {

        private static SqlConnection Connection;
        const string DbLocation = @"..\..\..\libaryDb.mdf";

        /// <summary>
        /// Gets all loans for a specific member.
        /// </summary>
        /// <param name="memberID">The member's ID.</param>
        /// <returns>A list of loans.</returns>
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
        /// Checks if this book has been loaned before by this member.
        /// </summary>
        /// <param name="copyID">The copy's ID.</param>
        /// <param name="memberID">The member's ID.</param>
        /// <returns>True if the book has been loaned before, false otherwise.</returns>
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
            return false;
        }

        /// <summary>
        /// Initializes the <see cref="DataManager"/> class.
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
        /// Adds a member to the database and returns their member ID and whether they were added or not.
        /// </summary>
        /// <param name="memberName">The member's name.</param>
        /// <param name="personID">The member's personal ID.</param>
        /// <param name="phoneNunber">The member's phone number.</param>
        /// <param name="Adress">The member's address.</param>
        /// <param name="isAdded">Outputs whether the member was added.</param>
        /// <param name="EmailtextBox">The member's email address.</param>
        /// <returns>The new member.</returns>
        public static Member AddMember(string memberName, string personID, string phoneNunber, string Adress, out bool isAdded, string EmailtextBox = null)
        {
            bool IfExist = IfItemExist(personID, "Members", "PersonID");
            if (IfExist)
            {
                isAdded = false;
                return null;
            }
            string query = @"INSERT INTO Members(MemberName,Phone,Adress,PersonID,Email) 
                             OUTPUT Inserted.MemberID,Inserted.MemberName,Inserted.Phone,Inserted.Adress,Inserted.PersonID,Inserted.Email
                             VALUES(@MemberName,@Phone,@Adress,@PersonID,@Email)";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
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

        /// <summary>
        /// Edits a book in the database.
        /// </summary>
        /// <param name="bookId">The book's ID.</param>
        /// <param name="bookName">The book's name.</param>
        /// <param name="genere">The book's genre.</param>
        /// <param name="author">The book's author.</param>
        /// <param name="publisher">The book's publisher.</param>
        /// <param name="publicationYear">The book's publication year.</param>
        /// <returns>The updated book.</returns>
        public static Book EditBookInDB(int bookId, string bookName, Generes genere, Authors author, Publishers publisher, short publicationYear)
        {

         string  query = @"UPDATE Books
                SET BookName=@BookName,GenreID=@GenereID,AuthorID=@AuthorID,PublisherID=@PublisherID,PublicationYear=@PublicationYear
                OUTPUT inserted.Bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,inserted.PublicationYear, inserted.BookID, Genres.GenreID, Publishers.PublisherID, Authors.AuthorID
                FROM Books b
                LEFT JOIN Genres ON  b.GenreID = Genres.GenreID 
                LEFT JOIN Publishers ON  Publishers.PublisherID = b.PublisherID 
                LEFT JOIN Authors ON Authors.AuthorID = b.AuthorID
                WHERE b.BookID=@Bookid;";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
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
            Connection.Close();
            return Updated;

        }

        /// <summary>
        /// Edits a member's details in the database.
        /// </summary>
        /// <param name="member">The member to edit.</param>
        /// <param name="FullName">The member's full name.</param>
        /// <param name="personID">The member's personal ID.</param>
        /// <param name="phone">The member's phone number.</param>
        /// <param name="Adress">The member's address.</param>
        /// <param name="isUpdate">Outputs whether the member was updated.</param>
        /// <returns>The updated member.</returns>
        public static Member EditMember(Member member, string FullName, long personID, string phone, string Adress, string Email, out bool isUpdate)
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
        /// Gets the last member who loaned this copy.
        /// </summary>
        /// <param name="BoocCopyID">The book copy's ID.</param>
        /// <returns>The member who last loaned the book.</returns>
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
        /// Gets member data from a SqlDataReader.
        /// </summary>
        /// <param name="reader">The SqlDataReader.</param>
        /// <returns>A member object.</returns>
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
        /// Gets the list of active loans based on member ID.
        /// </summary>
        /// <param name="memberID">The member's ID.</param>
        /// <returns>A list of active loans.</returns>
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
        /// Gets a loan from a SqlDataReader.
        /// </summary>
        /// <param name="reader">The SqlDataReader.</param>
        /// <returns>A loan object.</returns>
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
        /// Gets a member based on their member ID.
        /// </summary>
        /// <param name="ID">The member's ID.</param>
        /// <returns>The member.</returns>
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
        /// Searches by person ID as well as member ID.
        /// </summary>
        /// <param name="ID">The ID to search for.</param>
        /// <returns>A list of members.</returns>
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
        /// Sets the availability of the book to true in the database.
        /// </summary>
        /// <param name="bookCopyID">The book copy's ID.</param>
        /// <returns>True if the book was returned, false otherwise.</returns>
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
        /// Sets the availability of the book to true in the database and gets the book name.
        /// </summary>
        /// <param name="bookCopyID">The book copy's ID.</param>
        /// <param name="bookName">Outputs the book's name.</param>
        /// <returns>True if the book was returned, false otherwise.</returns>
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
        /// Checks if an item exists in the database.
        /// </summary>
        /// <param name="Element">The element to check for.</param>
        /// <param name="table">The table to check in.</param>
        /// <param name="column">The column to check in.</param>
        /// <returns>True if the item exists, false otherwise.</returns>
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
        /// Checks if a book is available based on the ISAvailable column.
        /// </summary>
        /// <param name="copyID">The copy's ID.</param>
        /// <returns>True if the book is available, false otherwise.</returns>
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
        /// Creates a loan.
        /// The availability of the book is auto-updated due to the UpdateAvailability trigger.
        /// </summary>
        /// <param name="memberID">The member's ID.</param>
        /// <param name="copyID">The copy's ID.</param>
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
        /// Searches for books based on the author or the name of the book.
        /// </summary>
        /// <param name="condition">The search condition.</param>
        /// <returns>A list of books.</returns>
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
                Book Book = getBookFromReader(reader);

                booksList.Add(Book);
            }
            Connection.Close();
            return booksList;

        }

        /// <summary>
        /// Gets a book from a SqlDataReader.
        /// </summary>
        /// <param name="reader">The SqlDataReader.</param>
        /// <returns>A book object.</returns>
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


        /// <summary>
        /// Searches for a member based on the member's name.
        /// </summary>
        /// <param name="condition">The search condition.</param>
        /// <returns>A list of members.</returns>
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
        /// Gets the number of available copies of a book.
        /// </summary>
        /// <param name="bookID">The book's ID.</param>
        /// <returns>The number of available copies.</returns>
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
        /// Adds a book to the database.
        /// </summary>
        /// <param name="bookName">The book's name.</param>
        /// <param name="genere">The book's genre.</param>
        /// <param name="author">The book's author.</param>
        /// <param name="publisher">The book's publisher.</param>
        /// <param name="publicationYear">The book's publication year.</param>
        /// <param name="numberOfCopies">The number of copies to add.</param>
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
        /// Makes a query to the database and gets all the copies related to the book.
        /// </summary>
        /// <param name="bookID">The book's ID.</param>
        /// <returns>A list of book copies.</returns>
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
        /// Gets a BindingList of BookAttributes classes from the database.
        /// </summary>
        /// <returns>A BindingList of book attributes.</returns>
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
        /// Inserts a book attribute into the database.
        /// </summary>
        /// <typeparam name="T">The type of the book attribute.</typeparam>
        /// <param name="value">The value of the book attribute.</param>
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
        /// Gets database structure data like table name based on the type.
        /// </summary>
        /// <param name="table">Outputs the table name.</param>
        /// <param name="idcolumn">Outputs the ID column name.</param>
        /// <param name="valuecolumn">Outputs the value column name.</param>
        /// <param name="T">The type to get the database structure for.</param>
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
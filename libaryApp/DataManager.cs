using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace libaryApp
{

    static public class DataManager
    {

        private static SqlConnection Connection;
        const string DbLocation = @"C:\Users\eliyahu\Desktop\פרוייקט מדעי המחשב\libaryApp\libaryApp\libaryDb.mdf";
        static DataManager()
        {

            string ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename={DbLocation};
                Integrated Security=True";
            Connection = new SqlConnection(ConnectionString);
        }
        /// <summary>
        /// search the books base on the Author or the name of the book.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        static public List<Book> GetBooksFromDB(string condition = "")
        {
            //get the data from the sql
            string query = "SELECT b.bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,b.PublicationYear, b.BookID "
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
                Book.BookName = reader[0].ToString();
                Book.Genre = reader[1].ToString();
                Book.Author = reader[2].ToString();
                Book.Publisher = reader[3].ToString();
                Book.PublicationYear = (short)reader[4];
                Book.bookId = (int)reader[5];

                booksList.Add(Book);
            }
            Connection.Close();
            return booksList;

        }

        static public List<Member> GetMemberFromDb(string condition = "")
        {
            //get the data from the sql
            string query = "select MemberID,MemberName,Phone,Adress,PersonID from Members";
            query = $"{query} WHERE MemberName LIKE N'%'+@c+'%'";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            sqlCommand.Parameters.AddWithValue("@c", condition);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var memberList = new List<Member>();
            //turn the data into list Of Books.
            while (reader.Read())
            {
                var member = new Member();
                member.MemberID = (int)reader[0];
                member.memberName = reader[1].ToString();
                member.Phone = reader[2].ToString();
                member.Adress = reader[3].ToString();
                member.PersonID = (int)reader[4];
                memberList.Add(member);
            }
            Connection.Close();
            return memberList;
        }





        static public int GetNumberOfCopiesAvaible(int bookID)
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
            SqlCommand insertTODB = new SqlCommand("INSERT INTO [Books]([Bookname],[GenreID],[AuthorID],[PublisherID],[PublicationYear] )  " +
               " OUTPUT Inserted.BookID " + "VALUES(@Bookname,@GenreID,@AuthorID,@PublisherID,@PublicationYear)", Connection);
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
        static public BindingList<BookAttributes>  GetAttributesFromDB<T>() where T: BookAttributes
        {
            //check which subClasses T is.
            string table, idcolumn, valuecolumn;
            getDBStructureDataBaseOnType(out table, out idcolumn, out valuecolumn,typeof(T));

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
        static public void AddBookAttributesToDB(string value ,Type t)
        {
            string table, idcolumn, valuecolumn;
            getDBStructureDataBaseOnType(out table, out idcolumn, out valuecolumn,t);
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
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
        static public List<Book> getBooksFromDB(string condition = "")
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
            insertTODB.Parameters.AddWithValue("@GenreID", genere.GenereID);
            insertTODB.Parameters.AddWithValue("@AuthorID", author.AuthorID);
            insertTODB.Parameters.AddWithValue("@PublisherID", publisher.PublishersID);
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
        /// get genere bindingList for comboBox from DB
        /// </summary>
        /// <returns></returns>
        static public BindingList<Generes> GetGeneresFromDB()
        {

            string query = "SELECT  GenreID, Genre FROM Genres";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var GeneresList = new BindingList<Generes>();
            while (reader.Read())
            {
                var Generes = new Generes() { GenereID = (int)reader[0], Genere = (string)reader[1] };

                GeneresList.Add(Generes);

            }
            Connection.Close();
            return GeneresList;
        }

        /// <summary>
        /// get publisher bindingList for comboBox from DB
        /// </summary>
        /// <returns></returns>
        static public BindingList<Publishers> GetPublishersFromDB()
        {

            string query = "SELECT PublisherID, Publisher  FROM Publishers";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var PublisherList = new BindingList<Publishers>();
            while (reader.Read())
            {
                var Publishers = new Publishers() { PublishersID = (int)reader[0], Publisher = (string)reader[1] };

                PublisherList.Add(Publishers);

            }
            Connection.Close();
            return PublisherList;
        }

        /// <summary>
        /// get publisher bindingList for comboBox from DB
        /// </summary>
        /// <returns></returns>
        static public BindingList<Authors> GetAuthorsFromDB()
        {

            string query = "SELECT  AuthorId, Author  FROM Authors";
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var List = new BindingList<Authors>();
            while (reader.Read())
            {
                var item = new Authors() { AuthorID = (int)reader[0], Author = (string)reader[1] };

                List.Add(item);

            }
            Connection.Close();
            return List;
        }

    }

}
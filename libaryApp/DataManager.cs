using System;
using System.Collections.Generic;
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
        static public List<Book> getBooksFromDB(string condition="")
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
                var bookCopy = new BookCopies(bookID,(int)reader[0],(bool)reader[1]) ;
               
                bookCopiesList.Add(bookCopy);

            }
            Connection.Close();
            return bookCopiesList;
        }



    }

}
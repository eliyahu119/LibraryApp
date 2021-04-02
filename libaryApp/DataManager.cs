using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace libaryApp
{
    public struct Book
    {
        public int bookId { private get; set; }
        public string BookName { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public short PublicationYear { get; set; }
        public int getBookID()
        {
            return bookId;
        }
    }
    static public class DataManager
    {

        private static SqlConnection Connection;
        const string DbLocation = @"C:\Users\eliyahu\source\repos\libaryApp\libaryApp\libaryDb.mdf";
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
        static public List<Book> getBooks(string condition="")
        {
            string command = "SELECT b.bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,b.PublicationYear, b.BookID "
                                                    +"FROM Books b "
                                                    +"LEFT JOIN Genres ON  b.GenreID = Genres.GenreID "
                                                    +"LEFT JOIN Publishers ON  Publishers.PublisherID = b.PublisherID "
                                                    +"LEFT JOIN Authors ON Authors.AuthorID = b.AuthorID";
           command = $"{command} WHERE b.bookname LIKE N'%'+@c+'%'  OR Authors.Author LIKE N'%'+@c+'%'";
            var booksList = new List<Book>();
            Connection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, Connection);
            sqlCommand.Parameters.AddWithValue("@c", condition);
            SqlDataReader reader = sqlCommand.ExecuteReader();
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

     
    }

}
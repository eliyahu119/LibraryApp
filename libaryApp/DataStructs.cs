using System;
using System.Collections.Generic;
using System.Text;

namespace libaryApp
{
    public class Book
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

    public class BookCopies
    {
     
        public int CopyID { get; set; }

        private bool isAvailable;
        public string _isAvailable { get {return isAvailable ? "נמצא" : "לא נמצא"; }}
        public int bookId { private get; set; }
        public BookCopies(int bookId, int CopyID, bool isAvailable)

        {
            this.isAvailable = isAvailable;
            this.CopyID = CopyID;
            this.bookId = bookId;

        }
      
        public int getBookID()
        {
            return bookId;
        }

    }
    public  abstract class BookAttributes {

         public int ID { get; set; }
        public string Value { get; set; }
       public BookAttributes(int id, string value) {
            ID = id;
            Value = value;
        }
    }

    public class Generes: BookAttributes
    {
        public Generes(int id, string value) : base(id, value)
        {

        }
    }
    public class Publishers :BookAttributes
    {
        public Publishers(int id, string value) : base(id, value)
        {

        }

    }
    public class Authors : BookAttributes
    {
        public Authors(int id, string value) : base(id, value)
        {

        }

    }

}

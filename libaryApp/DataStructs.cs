using System;
using System.Collections.Generic;
using System.Text;

namespace libaryApp
{

    #region bookClasses

    /// <summary>
    /// Represents a book with all its properties.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the book's ID.
        /// </summary>
        public int bookId { private get; set; }
        /// <summary>
        /// Gets or sets the book's name.
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// Gets or sets the book's genre.
        /// </summary>
        public Generes Genre { get; set; }
        /// <summary>
        /// Gets or sets the book's author.
        /// </summary>
        public Authors Author { get; set; }
        /// <summary>
        /// Gets or sets the book's publisher.
        /// </summary>
        public Publishers Publisher { get; set; }
        /// <summary>
        /// Gets or sets the book's publication year.
        /// </summary>
        public short PublicationYear { get; set; }
     
        /// <summary>
        /// Gets the book's ID.
        /// </summary>
        /// <returns>The book's ID.</returns>
        public int getBookID()
        {
            return bookId;
        }
    }

    /// <summary>
    /// Represents a copy of a book.
    /// </summary>
    public class BookCopies
    {

        /// <summary>
        /// Gets or sets the copy's ID.
        /// </summary>
        public int CopyID { get; set; }

        private bool _isAvailable;
        /// <summary>
        /// Gets a string indicating whether the copy is available.
        /// </summary>
        public string isAvailable { get { return _isAvailable ? "נמצא" : "לא נמצא"; } }
        /// <summary>
        /// Gets or sets the book's ID.
        /// </summary>
        public int bookId { private get;  set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BookCopies"/> class.
        /// </summary>
        /// <param name="bookId">The book's ID.</param>
        /// <param name="CopyID">The copy's ID.</param>
        /// <param name="isAvailable">Whether the copy is available.</param>
        public BookCopies(int bookId, int CopyID, bool isAvailable)

        {
            this._isAvailable = isAvailable;
            this.CopyID = CopyID;
            this.bookId = bookId;

        }

        /// <summary>
        /// Gets the book's ID.
        /// </summary>
        /// <returns>The book's ID.</returns>
        public int getBookID()
        {
            return bookId;
        }

    }

    /// <summary>
    /// An abstract structure for a book's attribute.
    /// </summary>
    public abstract class BookAttributes
    {
        /// <summary>
        /// Gets the attribute's ID.
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Gets the attribute's value.
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BookAttributes"/> class.
        /// </summary>
        /// <param name="id">The attribute's ID.</param>
        /// <param name="value">The attribute's value.</param>
        public BookAttributes(int id, string value)
        {
            ID = id;
            Value = value;
        }
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() 
        {
            return Value;
        }
        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                BookAttributes p = (BookAttributes)obj;
                return (ID == p.ID) && (Value == p.Value);
            }
        }
        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode() + Value.GetHashCode();
        }
    }


    /// <summary>
    /// Represents a book's genre.
    /// </summary>
    public class Generes : BookAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Generes"/> class.
        /// </summary>
        /// <param name="id">The genre's ID.</param>
        /// <param name="value">The genre's name.</param>
        public Generes(int id, string value) : base(id, value)
        {

        }
    }
    /// <summary>
    /// Represents a book's publisher.
    /// </summary>
    public class Publishers : BookAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Publishers"/> class.
        /// </summary>
        /// <param name="id">The publisher's ID.</param>
        /// <param name="value">The publisher's name.</param>
        public Publishers(int id, string value) : base(id, value)
        {

        }

    }
    /// <summary>
    /// Represents a book's author.
    /// </summary>
    public class Authors : BookAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Authors"/> class.
        /// </summary>
        /// <param name="id">The author's ID.</param>
        /// <param name="value">The author's name.</param>
        public Authors(int id, string value) : base(id, value)
        {

        }

    }
    #endregion


    /// <summary>
    /// Represents a library member.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Gets or sets the member's name.
        /// </summary>
        public string memberName { get; set; }
        /// <summary>
        /// Gets or sets the member's ID.
        /// </summary>
        public int MemberID { get; set; }
        /// <summary>
        /// Gets or sets the member's personal ID.
        /// </summary>
        public long PersonID { get; set; }
        /// <summary>
        /// Gets or sets the member's phone number.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the member's address.
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Gets or sets the member's email address.
        /// </summary>
        public string Email { get;  set; }
    }

    /// <summary>
    /// Represents a loan of a book.
    /// </summary>
    public class Loan
    {
        /// <summary>
        /// Gets or sets the loan's ID.
        /// </summary>
        public int LoanID { get; set; }
        /// <summary>
        /// Gets or sets the copy's ID.
        /// </summary>
        public int CopyID { get; set; }
        /// <summary>
        /// Gets or sets the book's name.
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// Gets or sets the date of the loan.
        /// </summary>
        public DateTime dateOfLoan { get; set; }
    }

}

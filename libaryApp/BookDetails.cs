using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class BookDetails : Form
    {
        public BookDetails(Book book)
        {
            InitializeComponent();
            this.book = book;
            BookName.Text = this.book.BookName;
            Author.Text = this.book.Author.ToString();
           
        }
        private void BookDetails_Load(object sender, EventArgs e)
        {
            List<BookCopies> li = DataManager.getBookCopiesFromDB(book.getBookID());
            CopiesGrid.DataSource = li;
            CopiesGrid.Columns["CopyID"].HeaderText = "קוד עותק";
            CopiesGrid.Columns["isAvailable"].HeaderText = "האם נמצא";
            int number= DataManager.GetNumberOfCopiesavailable(book.getBookID());
            availableBooks.Text = string.Format(availableBooks.Text, number);
        }


        private void EditBook_Click(object sender, EventArgs e)
        {
            AddBooks addBooks =  new AddBooks(book);
            Utils.SwitchBetweenWindows(this, addBooks);
            
        }

     
    }
}

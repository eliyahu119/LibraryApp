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
        Book book;
        public BookDetails(Book book)
        {
            InitializeComponent();
            this.book = book;
            BookName.Text = this.book.BookName;
            Author.Text = this.book.Author;
           
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
        private void Author_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BookName_Click(object sender, EventArgs e)
        {

        }

        private void Author_Click_1(object sender, EventArgs e)
        {

        }

        private void CopiesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditBook_Click(object sender, EventArgs e)
        {

        }
    }
}

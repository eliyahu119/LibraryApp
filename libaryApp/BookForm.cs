using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class BookForm : Form
    {
        // public List<Book>
        public BookForm()
        {

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //set the search button to react enter preses
            searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }
        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchAndDisplayBooks();
            }
        }
        private void BookForm_Load(object sender, EventArgs e)
        {

            BookGrid.DataSource = new List<Book>();
            BookGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Utils.Grid_RowPostPaint);
            ChangeColumnsHeaders();

        }



        /// <summary>
        /// translate the header of the Columns to hebrew 
        /// </summary>
        private void ChangeColumnsHeaders()
        {
            BookGrid.Columns["BookName"].HeaderText = "שם הספר";
            BookGrid.Columns["Genre"].HeaderText = "ז'אנר";
            BookGrid.Columns["Author"].HeaderText = "סופר";
            BookGrid.Columns["Publisher"].HeaderText = "הוצאה לאור";
            BookGrid.Columns["PublicationYear"].HeaderText = "שנת יציאה";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());
        }


        /// <summary>
        /// get the search  data from the DB.
        /// </summary>
        private void SearchAndDisplayBooks(object sender=null, EventArgs e=null)
        {
            var searchText = searchTextBox.Text;
            BookGrid.DataSource = DataManager.GetBooksFromDB(searchText);
        }

        private void BookGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Book book = (Book)this.BookGrid.CurrentRow.DataBoundItem;
            var form = new BookDetails((Book)(book));
            form.Show();
        }

        private void BookGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            AddBooks addBooks = AddBooks.Instance;
            addBooks.Show();
        }

       
    }
}

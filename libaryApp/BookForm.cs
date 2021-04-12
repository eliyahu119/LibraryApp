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

        private static BookForm instance = null;
        //implenting singelton pattern to this class
        public static BookForm Instance()
        {

            if (instance == null)
            {
                instance = new BookForm();
            }
            instance.SetAsNewWindow();
            return instance;

        }

        private  void SetAsNewWindow()
        {

            BookGrid.DataSource = new List<Book>();
            searchTextBox.Text = "שורת חיפוש";
        
        }

        private BookForm()
        {

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //set the search button to react enter preses
            searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            //add place holder
            searchTextBox.GotFocus += new System.EventHandler(Utils.RemoveText);
            searchTextBox.LostFocus += new System.EventHandler(Utils.AddText);
            BookGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Utils.Grid_RowPostPaint);
         

        }
        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchAndDisplayBooks();
            }
        }
   



        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, MainWindow.Instance());
        }


        /// <summary>
        /// get the search  data from the DB.
        /// </summary>
        private void SearchAndDisplayBooks(object sender = null, EventArgs e = null)
        {
            var searchText = searchTextBox.Text;
            BookGrid.DataSource = DataManager.GetBooksFromDB(searchText);
        }

        /// <summary>
        /// in case double click on cell the book detail form will open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Book book = (Book)this.BookGrid.CurrentRow.DataBoundItem;
            DialogResult dialogResult = MessageBox.Show($"האם תרצה לעבור לפרטי הספר {book.BookName} ", "השאלת ספר", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var form =  BookDetails.Instance((Book)(book));
                Utils.SwitchBetweenWindows(this, form);
            }

        }

        /// <summary>
        /// opens the singelton instance of addbook form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBook_Click(object sender, EventArgs e)
        {
            AddBooks addBooks = AddBooks.Instance();
            Utils.SwitchBetweenWindows(this, addBooks);
            // addBooks.ShowDialog();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            Utils.ChangeColumnsNameOfGrid(BookGrid,
         new Tuple<string, string>[] {
                new Tuple<string, string>("BookName", "שם הספר"),
                new Tuple<string, string>("Genre","ז'אנר"),
                new Tuple<string, string>("Author","סופר"),
                new Tuple<string, string>("PublicationYear","שנת יציאה"),
                new Tuple<string, string>("Publisher","סופר")
         });
        }
    }
}

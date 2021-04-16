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

        private static BookDetails instance = null;
        //implenting singelton pattern to this class
        public static BookDetails Instance(Book book)
        {

            if (instance == null)
            {
                instance = new BookDetails();
            }
            instance.SetAsNewWindow(book);
            return instance;

        }


        private void SetAsNewWindow(Book book)
        {
            this.book = book;
            BookName.Text = this.book.BookName;
            Author.Text = this.book.Author.ToString();
            List<BookCopies> li = DataManager.getBookCopiesFromDB(book.getBookID());
            CopiesGrid.DataSource = li;
            int number = DataManager.GetNumberOfCopiesavailable(book.getBookID());
            availableBooks.Text = string.Format("{0}: עותקים זמינים", number);
            bookCodeLabel.Text = string.Format("{0}: קוד ספר", book.getBookID());
        }

        Book book;
        public BookDetails()
        {
            InitializeComponent();
        }
        private void BookDetails_Load(object sender, EventArgs e)
        {
            Utils.ChangeColumnsNameOfGrid(CopiesGrid,

                new Tuple<string, string>[] {
                new Tuple<string, string>( "CopyID","קוד עותק"  ),
                new Tuple<string, string>( "isAvailable","האם נמצא"  ),
                });



        }


        private void EditBook_Click(object sender, EventArgs e)
        {
            AddBooks addBooks = AddBooks.Instance(book);
            Utils.SwitchBetweenWindows(this, addBooks);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, BookForm.Instance());
        }

        private void DeleteBook_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("האם אתה רוצה למחוק ספר זה\n? מחיקת הספר תמחק את כל ההשאלות וכל העותקים הקשורים לספר זה.", "מחיקת ספר", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;

            }
            DataManager.DeleteBookFromDB(book.getBookID());
            MessageBox.Show("הספר נמחק בהצלחה");
            Utils.SwitchBetweenWindows(this, MainWindow.Instance());
        }

        private void bookCodeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    /// <summary>
    /// This form is for returning a book.
    /// </summary>
    public partial class ReturnBook : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnBook"/> class.
        /// </summary>
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());
        }

        /// <summary>
        /// Checks if the book is on the shelf. If not, it returns the book and switches to the member loan of the person who loaned it.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SubmitReturn_Click(object sender, EventArgs e)
        {
            if (!Utils.AllowOnlyInRange(0, 1000000, BookCodeTxt))
                return;
            var BoocCopyID = Convert.ToInt32(BookCodeTxt.Text);
            bool IsReturned = DataManager.returnBookToShelf(BoocCopyID, out string bookName);
            if (IsReturned)
            {

                Member member = DataManager.getLastUserUseTheBook(BoocCopyID);
                MessageBox.Show($"הספר {bookName} הוחזר למדף");
                Utils.SwitchBetweenWindows(this, new MemberForm(member));
            }
            else
            {
                MessageBox.Show("שגיאה בהחזרת הספר");
                BookCodeTxt.Text = "";

            }
                            

        }


    }
}

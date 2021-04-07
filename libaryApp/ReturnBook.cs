using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());
        }

        /// <summary>
        /// check if the book is on the shelf, if not return it and switch to member loan of the one who loaned it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitReturn_Click(object sender, EventArgs e)
        {
            var BoocCopyID = Convert.ToInt32(BookCodeTxt.Text);
            bool IsReturned = DataManager.returnBookToShelf(BoocCopyID, out string bookName);
            if (IsReturned)
            {

                Member member = DataManager.getLastUserUseTheBook(BoocCopyID);
                MessageBox.Show($"הספר {bookName} הוחזר למדף");
                Utils.SwitchBetweenWindows(this, new LoanForm(member));
            }
            else
            {
                MessageBox.Show("שגיאה בהחזרת הספר");
                BookCodeTxt.Text = "";

            }
                            

        }


    }
}

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

        private static ReturnBook instance = null;
        //implenting singelton pattern to this class
        public static ReturnBook Instance()
        {

            if (instance == null)
            {
                instance = new ReturnBook();
            }
            instance.SetAsNewWindow();
            return instance;

        }

        private void SetAsNewWindow()
        {
            BookCodeTxt.Text = "";
        }

        private ReturnBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  MainWindow.Instance());
        }

        /// <summary>
        /// check if the book is on the shelf, if not return it and switch to member loan of the one who loaned it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Utils.SwitchBetweenWindows(this, MemberForm.Instance(member));
            }
            else
            {
                MessageBox.Show("שגיאה בהחזרת הספר");
                BookCodeTxt.Text = "";

            }
                            

        }


    }
}

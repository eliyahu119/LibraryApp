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

        private void SubmitReturn_Click(object sender, EventArgs e)
        {
            var BoocCopyID = Convert.ToInt32(BookCodeTxt.Text);
             bool IsReturned = DataManager.returnBookToShelf(BoocCopyID);
            if (IsReturned)
            {
                Member member = DataManager.getLastUserUseTheBook(BoocCopyID);
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

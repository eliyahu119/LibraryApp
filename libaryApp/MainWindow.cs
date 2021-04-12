using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class MainWindow : Form
    {
        private MainWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
        }
        private static MainWindow instance = null;
        //implenting singelton pattern to this class
        public static MainWindow Instance()
        {

            if (instance == null)
            {
                instance = new MainWindow();
            }
            return instance;

        }

   

        private void Books_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, BookForm.Instance());
        }

        private void Members_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  MembersForm.Instance());
        }

        private void LoanBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  CreateLoan.Instance());
        }

        private void ReturnBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new ReturnBook());
        }
    }
}

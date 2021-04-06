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
        public MainWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            
        }



        private void Books_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new BookForm());
        }

        private void Members_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MembersForm());
        }

        private void LoanBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new CreateLoan());
        }

        private void ReturnBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new ReturnBook());
        }
    }
}

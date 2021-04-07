using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class LoanForm : Form
    {
        Member member;
        public LoanForm(int memberID)
        {
            this.member = DataManager.GetMember(memberID);
            InitializeComponent();
            setTextOfLabels();
        }

        private void setTextOfLabels()
        {
            MemberNameLabel.Text = $"שם מלא {member.memberName}";
            Memberlabel.Text = $"קוד מנוי: {member.MemberID}";
        }

        public LoanForm(Member member)
        {
            this.member = member;
            InitializeComponent();
            setTextOfLabels();
        }

        private void loanBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new CreateLoan(member));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());
        }

        private void LoanForm_Load(object sender, EventArgs e)
        {
            List<Loan> li = DataManager.GetActiveLoans(member.MemberID);
            ActiveLoanGrid.DataSource = li;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MemberNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

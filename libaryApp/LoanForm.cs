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
            MemberNameLabel.Text = member.memberName;
        }
        public LoanForm(Member member)
        {
            this.member = member;
            InitializeComponent();
            MemberNameLabel.Text = member.memberName;
        }

        private void MemberNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void loanBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new CreateLoan(member));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class AllLoansForm : Form
    {
        Member member;
        public AllLoansForm(Member member)
        {
            this.member = member;
            InitializeComponent();
            allLoanLabel.Text = string.Format(allLoanLabel.Text, member.memberName);
            AllLoanGrid.DataSource = DataManager.getAllLoans(member.MemberID);
            Utils.ChangeColumnsNameOfGrid(AllLoanGrid,
               new Tuple<string, string>[] {
                new Tuple<string, string>("LoanID", "מספר השאלה"),
                new Tuple<string, string>("CopyID","מספר עותק"),
                new Tuple<string, string>("BookName","שם הספר"),
                new Tuple<string, string>("dateOfLoan","תאריך השאלה")
               });

        }
       
           

            private void allLoanLabel_Click(object sender, EventArgs e)
        {

        }

        private void AllLoanGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MemberForm(member));
        }
    }
}

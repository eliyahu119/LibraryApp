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


        private static AllLoansForm instance = null;
        //implenting singelton pattern to this class
        public static AllLoansForm Instance(Member member)
        {

            if (instance == null)
            {
                instance = new AllLoansForm();
            }
            instance.SetAsNewWindow(member);
            return instance;

        }

        private void SetAsNewWindow(Member member)
        {
            this.member = member;
            allLoanLabel.Text = string.Format(allLoanLabel.Text, member.memberName);
            AllLoanGrid.DataSource = DataManager.getAllLoans(member.MemberID);
        }

        private AllLoansForm()
        {
         
            InitializeComponent();
           
        
        }
       
           


        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, MemberForm.Instance(member));
        }

        private void AllLoansForm_Load(object sender, EventArgs e)
        {
            Utils.ChangeColumnsNameOfGrid(AllLoanGrid,
               new Tuple<string, string>[] {
                new Tuple<string, string>("LoanID", "מספר השאלה"),
                new Tuple<string, string>("CopyID","מספר עותק"),
                new Tuple<string, string>("BookName","שם הספר"),
                new Tuple<string, string>("dateOfLoan","תאריך השאלה")
               });
        }

    }
}

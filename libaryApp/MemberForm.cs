using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class MemberForm : Form
    {

        private static MemberForm instance = null;
        //implenting singelton pattern to this class
        public static MemberForm Instance(int memberID)
        {

            if (instance == null)
            {
                instance = new MemberForm();
            }
            instance.member = DataManager.GetMemberByMemberID(memberID);
            instance.SetAsNewWindow();
            return instance;
        }
        public static MemberForm Instance(Member member)
        {

            if (instance == null)
            {
                instance = new MemberForm();
            }
            instance.member = member;
            instance.SetAsNewWindow();
            return instance;
        }

        private void SetAsNewWindow()
        {
           
            setTextOfLabels();
        }



        private List<Loan> loanList;
        Member member;

        private MemberForm()
        {
            InitializeComponent();
           
        }

        private void setTextOfLabels()
        {
            MemberNameLabel.Text = $"שם מלא: {member.memberName}";
            Memberlabel.Text = $"קוד מנוי: {member.MemberID}";
        }

    

        private void loanBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  CreateLoan.Instance(member));
        }

    

        private void LoanForm_Load(object sender, EventArgs e)
        {
            UpdateLoanGrid();
            Utils.ChangeColumnsNameOfGrid(ActiveLoanGrid,
                new Tuple<string, string>[] {
                new Tuple<string, string>("LoanID", "מספר השאלה"),
                new Tuple<string, string>("CopyID","מספר עותק"),
                new Tuple<string, string>("BookName","שם הספר"),
                new Tuple<string, string>("dateOfLoan","תאריך השאלה")
                });

        }

        private void UpdateLoanGrid()
        {
            loanList = DataManager.GetActiveLoans(member.MemberID);
            ActiveLoanGrid.DataSource = loanList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  AllLoansForm.Instance(member));
        }


        /// <summary>
        /// on double click in cell will show a dialog if return book and if yes the book will be reutrned.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDoubleClickReturnBook(object sender, DataGridViewCellEventArgs e)
        {
            Loan loan = (Loan)this.ActiveLoanGrid.CurrentRow.DataBoundItem;
            DialogResult dialogResult = MessageBox.Show($"האם להחזיר ספר זה?", "החזרת ספר", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (DataManager.returnCopyToShelf(loan.CopyID))
                    MessageBox.Show($"הספר {loan.BookName} הוחזר למדף");
                else
                {
                    MessageBox.Show("שגיאה בהחזרת הספר");

                }
                UpdateLoanGrid();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  MainWindow.Instance());

        }

        private void editMember_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  AddMember.Instance(member));

        }


    }
}

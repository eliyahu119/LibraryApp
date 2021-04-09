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
        private List<Loan> loanList;
        Member member;
        public MemberForm(int memberID)
        {
            this.member = DataManager.GetMemberByID(memberID);
            InitializeComponent();
            setTextOfLabels();
        }

        private void setTextOfLabels()
        {
            MemberNameLabel.Text = $"שם מלא: {member.memberName}";
            Memberlabel.Text = $"קוד מנוי: {member.MemberID}";
        }

        public MemberForm(Member member)
        {
            this.member = member;
            InitializeComponent();
            setTextOfLabels();
        }

        private void loanBook_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new CreateLoan(member));
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
            Utils.SwitchBetweenWindows(this, new AllLoansForm(member));
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
                if (DataManager.returnBookToShelf(loan.CopyID))
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
            Utils.SwitchBetweenWindows(this, new MainWindow());

        }

        private void editMember_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new AddMember(member));

        }


    }
}

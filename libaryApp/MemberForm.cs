using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    /// <summary>
    /// This form displays the details of a specific member.
    /// </summary>
    public partial class MemberForm : Form
    {
        private List<Loan> loanList;
        Member member;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberForm"/> class.
        /// </summary>
        /// <param name="memberID">The ID of the member to display.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberForm"/> class.
        /// </summary>
        /// <param name="member">The member to display.</param>
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
        /// On a double-click in a cell, a dialog will be shown to confirm returning the book. If "yes" is clicked, the book will be returned.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
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

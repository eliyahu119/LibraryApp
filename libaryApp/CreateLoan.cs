using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class CreateLoan : Form
    {

        Member member;
        public CreateLoan(Member member = null)
        {
            this.member = member;
            InitializeComponent();
            if (member != null)
            {
                CodeMemberTxt.Text = member.MemberID.ToString();
                CodeMemberTxt.ReadOnly = true;
            }
        }



        /// <summary>
        /// submit the loan to the db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitLoan_Click(object sender, EventArgs e)
        {
            if ((!Utils.AllowOnlyInRange(0, 1000000, CodeMemberTxt)) || (!Utils.AllowOnlyInRange(0, 1000000, CodeMemberTxt)))
                return;

            int MemberID = Convert.ToInt32(CodeMemberTxt.Text);
            int CopyID = Convert.ToInt32(BookCodeTxt.Text);
            if (DataManager.IfItemExist(CopyID, "BooksCopies", "BooksCopyID") && DataManager.IsBookAvailable(CopyID))
            {
                if(DataManager.ifHadBeenLoanBefore(CopyID,MemberID))
                {
                    DialogResult dialogResult = MessageBox.Show("ספר זה הושאל בעבר, האם תרצה להשאיל אותו שוב?", "השאלת ספר", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;

                    }
                }

                if (DataManager.IfItemExist(MemberID, "Members", "MemberID"))
                {
                    DataManager.CreateLoan(MemberID, CopyID);
                    MessageBox.Show("השאלה בוצעה בהצלחה");

                    Utils.SwitchBetweenWindows(this, new MemberForm(MemberID));

                }
                else
                {
                    MessageBox.Show(" מספר מנוי זה אינו תקין ");
                }
            }
            else
            {
                MessageBox.Show("עותק זה אינו זמין להשאלה או שאינו קיים במערכת");
            }


        }



        private void backButton_Click(object sender, EventArgs e)

        {
            if (member == null)
                Utils.SwitchBetweenWindows(this, new MainWindow());
            else
            {
                Utils.SwitchBetweenWindows(this, new MemberForm(member));

            }
        }


    }
}

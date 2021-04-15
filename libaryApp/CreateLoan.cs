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
        private static CreateLoan instance = null;
        //implenting singelton pattern to this class
        public static CreateLoan Instance(Member member = null)
        {

            if (instance == null)
            {
                instance = new CreateLoan();
            }
            instance.SetAsNewWindow(member);
            return instance;

        }

        private void SetAsNewWindow(Member member)
        {
            this.member = member;
            if (member != null)
            {
                CodeMemberTxt.Text = member.MemberID.ToString();
                CodeMemberTxt.ReadOnly = true;
            }
        }

        Member member;
        private CreateLoan()
        {
            InitializeComponent();
       
        }



        /// <summary>
        /// submit the loan to the db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitLoan_Click(object sender, EventArgs e)
        {
            const int max = 1000000;
            if ((!Utils.AllowOnlyInRange(0, 1000000, CodeMemberTxt,$"נא הכנס מספר עד {max}")) || (!Utils.AllowOnlyInRange(0, 1000000, CodeMemberTxt, $"נא הכנס מספר עד {max}")))
                return;

            int MemberID = Convert.ToInt32(CodeMemberTxt.Text);
            int CopyID = Convert.ToInt32(BookCodeTxt.Text);
            if (DataManager.IfItemExist(CopyID, "BooksCopies", "BooksCopyID") && DataManager.IsCopyAvailable(CopyID))
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

                    Utils.SwitchBetweenWindows(this, MemberForm.Instance(MemberID));

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
                Utils.SwitchBetweenWindows(this,MainWindow.Instance());
            else
            {
                Utils.SwitchBetweenWindows(this, MemberForm.Instance(member));

            }
        }


    }
}

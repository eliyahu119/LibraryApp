using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            else
            {
                CodeMemberTxt.Text = "";
                CodeMemberTxt.ReadOnly = false;

            }
            BookCodeTxt.Text = "";

        }

        Member member;
        private CreateLoan()
        {
            InitializeComponent();
            this.CodeMemberTxt.KeyPress += new KeyPressEventHandler(Utils.AllowOnlyNumeric);
            this.BookCodeTxt.KeyPress += new KeyPressEventHandler(Utils.AllowOnlyNumeric);

        }



        /// <summary>
        /// submit the loan to the db
        /// </summary>
        /// <param name="sender"></param>           
        /// <param name="e"></param>
        private void SubmitLoan_Click(object sender, EventArgs e)
        {
            const int max = 1000000;
            if (!(Utils.AllowOnlyInRange(0, 1000000, CodeMemberTxt, $"נא הכנס מספר עד {max}")) || !(Utils.AllowOnlyInRange(0, 1000000, BookCodeTxt, $"נא הכנס מספר עד {max}")))
                return;
        
            int MemberID = Convert.ToInt32(CodeMemberTxt.Text);
            int CopyID = Convert.ToInt32(BookCodeTxt.Text);
            //if (DataManager.IfItemExist(CopyID, "BooksCopies", "BooksCopyID")) 

            if (DataManager.ifHadBeenLoanBefore(CopyID, MemberID))
            {
                DialogResult dialogResult = MessageBox.Show("ספר זה הושאל בעבר, האם תרצה להשאיל אותו שוב?", "השאלת ספר", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;

                }
            }
            string err = DataManager.CreateLoan(MemberID, CopyID);
            //because its a try the message will not show if there were an error on CreateLoan
            if (err == "")
            {
                MessageBox.Show("השאלה בוצעה בהצלחה");
                Utils.SwitchBetweenWindows(this, MemberForm.Instance(MemberID));
            }
            else
            {
                MessageBox.Show(err);
            }

        }
    
          
        

        private void backButton_Click(object sender, EventArgs e)

        {
            if (member == null)
                Utils.SwitchBetweenWindows(this, MainWindow.Instance());
            else
            {
                Utils.SwitchBetweenWindows(this, MemberForm.Instance(member));

            }
        }

        private void CreateLoan_Load(object sender, EventArgs e)
        {

        }

    }
}

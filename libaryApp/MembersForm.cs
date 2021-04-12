using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class MembersForm : Form
    {

        private static MembersForm instance = null;
        //implenting singelton pattern to this class
        public static MembersForm Instance()
        {

            if (instance == null)
            {
                instance = new MembersForm();
            }
            instance.SetAsNewWindow();
            return instance;

        }

        private void SetAsNewWindow()
        {

            MemberGrid.DataSource = new List<Member>();
            searchTextBox.Text = "שורת חיפוש";

        }

        private MembersForm()
        {

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //set the search button to react enter preses
            searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            //add place holder
            searchTextBox.GotFocus += new System.EventHandler(Utils.RemoveText);
            searchTextBox.LostFocus += new System.EventHandler(Utils.AddText);
            MemberGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Utils.Grid_RowPostPaint);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this,  MainWindow.Instance());
        }


        private void Members_Load(object sender, EventArgs e)
        {
           
            MemberGrid.DataSource = new List<Member>();
            Utils.ChangeColumnsNameOfGrid(MemberGrid,
                new Tuple<string, string>[] {
                new Tuple<string, string>("memberName", "שם המנוי"),
                new Tuple<string, string>("Phone"," טלפון"),
                new Tuple<string, string>("Adress","כתובת"),
                new Tuple<string, string>("MemberID","מספר מנוי"),
                new Tuple<string, string>("PersonID","תעודת זהות"),
                });

        }



        private void MemberGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Member member = (Member)this.MemberGrid.CurrentRow.DataBoundItem;
            DialogResult dialogResult = MessageBox.Show($"מעבר ל: {member.memberName} ?", "מעבר לפרטי מנוי", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Utils.SwitchBetweenWindows(this, MemberForm.Instance(member));

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchAndDisplayMember();
            }
        }

        /// <summary>
        /// search and display Members on member form, if user given PersonID or memberID loan window will auto open
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchAndDisplayMember(object sender = null, EventArgs e = null)
        {
            if (searchTextBox.Text != "")
            {
                List<Member> Li = null;
                bool isNumeric = long.TryParse(searchTextBox.Text, out long n);
                if (isNumeric)
                {
                    Li = DataManager.GetMembersByID(n);
                }
                else
                {
                    Li = DataManager.GetMembersFromDb(searchTextBox.Text);
                }

                if (Li.Count == 1)
                {
                    Utils.SwitchBetweenWindows(this, MemberForm.Instance(Li[0]));
                }
                else
                {
                    MemberGrid.DataSource = Li;
                }


            }

        }

        private void AddMember_Click(object sender, EventArgs e)
        {

            Utils.SwitchBetweenWindows(this,AddMember.Instance());
        }

        private void MemberGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

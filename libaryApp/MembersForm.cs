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
        public MembersForm()
        {

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //set the search button to react enter preses
            searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            //add place holder
            searchTextBox.GotFocus += new System.EventHandler(Utils.RemoveText);
            searchTextBox.LostFocus += new System.EventHandler(Utils.AddText);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());   
        }


        private void Members_Load(object sender, EventArgs e)
        {
            MemberGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Utils.Grid_RowPostPaint);
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
                Utils.SwitchBetweenWindows(this, new MemberForm(member));

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
        private void SearchAndDisplayMember(object sender=null, EventArgs e=null)
        {
            if (searchTextBox.Text != "")
            {
                bool isNumeric = int.TryParse(searchTextBox.Text, out int n);
                if (isNumeric)
                {
                    Member member = DataManager.GetMember(n);
                    if (member != null)
                    {
                        Utils.SwitchBetweenWindows(this, new MemberForm(member));
                    }
                }
                else
                {
                    MemberGrid.DataSource = DataManager.GetMembersFromDb(searchTextBox.Text);
                }

            }

        }

        private void AddMember_Click(object sender, EventArgs e)
        {
            
            Utils.SwitchBetweenWindows(this, new AddMember());
        }

        
    }
}

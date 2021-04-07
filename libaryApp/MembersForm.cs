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
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MainWindow());   
        }

        private void Members_Load(object sender, EventArgs e)
        {
            MemberGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Utils.Grid_RowPostPaint);
            MemberGrid.DataSource = new List<Member>();
            ChangeColumnsHeaders();

        }


        /// <summary>
        /// translate the header of the Columns to hebrew 
        /// </summary>
        private void ChangeColumnsHeaders()
        {
            MemberGrid.Columns["memberName"].HeaderText = "שם המנוי";
            MemberGrid.Columns["Phone"].HeaderText = "טלפון";
            MemberGrid.Columns["Adress"].HeaderText = "כתובת";
            MemberGrid.Columns["MemberID"].HeaderText = "מספר מנוי";
            MemberGrid.Columns["PersonID"].HeaderText = "תעודת זהות";
        }
        private void MemberGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SearchAndDisplayMember();
            }
        }

        private void SearchAndDisplayMember(object sender=null, EventArgs e=null)
        {
            if (searchTextBox.Text != "")
            {
                bool isNumeric = int.TryParse(searchTextBox.Text, out int n);
                if (isNumeric)
                {

                }
                else
                {
                    MemberGrid.DataSource = DataManager.GetMemberFromDb(searchTextBox.Text);
                }

            }

        }

        private void AddBook_Click(object sender, EventArgs e)
        {
            
            Utils.SwitchBetweenWindows(this, new AddMember());
        }
    }
}

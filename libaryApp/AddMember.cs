using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class AddMember : Form
    {

        public AddMember()
        {
            InitializeComponent();
        }


        
        /// <summary>
        /// submit the form and opens the Member window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if ((fullNameTextBox.Text != "") &&
                (PersonIDTextBox.Text != "") &&
                (phoneNumberTextBox.Text != "") &&
                (AdressTextBox.Text != ""))
            {
                Member member = DataManager.AddMember
                 (
                        fullNameTextBox.Text,
                        PersonIDTextBox.Text,
                        phoneNumberTextBox.Text,
                        AdressTextBox.Text,
                        out bool isAdded
                );
                if (isAdded)
                {
                    MessageBox.Show("המנוי נוסף בהצלחה");
                    Utils.SwitchBetweenWindows(this, new LoanForm(member));
                }
                else
                {
                    MessageBox.Show("מנוי זה כבר קיים");
                    AdressTextBox.Text = "";
                    PersonIDTextBox.Text = "";
                    phoneNumberTextBox.Text = "";
                    fullNameTextBox.Text = "";

                }
            }
            else
            {
                MessageBox.Show("נא למלא את כל הפרטים");
            }




        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(this, new MembersForm());
        }
    }


}
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
    /// A form for adding a new member or editing an existing one.
    /// </summary>
    public partial class AddMember : Form
    {
        private Member member;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddMember"/> class.
        /// </summary>
        /// <param name="member">The member to edit. If null, a new member will be created.</param>
        public AddMember(Member member = null)
        {
            this.member = member;
            InitializeComponent();
            phoneNumberTextBox.KeyPress += new KeyPressEventHandler(Utils.AllowOnlyNumeric);
            PersonIDTextBox.KeyPress += new KeyPressEventHandler(Utils.AllowOnlyNumeric);
            if (member != null)
            {
                fullNameTextBox.Text = member.memberName;
                PersonIDTextBox.Text = member.PersonID.ToString();
                phoneNumberTextBox.Text = member.Phone;
                AdressTextBox.Text = member.Adress;
                EmailtextBox.Text = member.Email;
                SubmitButton.Text = "ערוך מנוי";
            }
        }

        /// <summary>
        /// Handles the Click event of the SubmitButton control.
        /// Submits the form and opens the Member window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (
                (fullNameTextBox.Text != "") &&
                (PersonIDTextBox.Text != "") &&
                (phoneNumberTextBox.Text != "") &&
                (AdressTextBox.Text != "")
               )
            {
                if (member == null)
                {

                    Member NewMember = DataManager.AddMember
                     (
                            fullNameTextBox.Text,
                            PersonIDTextBox.Text,
                            phoneNumberTextBox.Text,
                            AdressTextBox.Text,
                            out bool isAdded,
                            EmailtextBox.Text
                          
                    );
                    if (isAdded)
                    {
                        MessageBox.Show("המנוי נוסף בהצלחה");
                        Utils.SwitchBetweenWindows(this, new MemberForm(NewMember));
                    }
                    else
                    {
                        MessageBox.Show("מנוי זה כבר קיים");
                        AdressTextBox.Text = "";
                        PersonIDTextBox.Text = "";
                        phoneNumberTextBox.Text = "";
                        fullNameTextBox.Text = "";
                        EmailtextBox.Text = "";

                    }
                }
                else
                {
                    Member UpdatedMember = null;
                    UpdatedMember = DataManager.EditMember(member, fullNameTextBox.Text,
                               Convert.ToInt64(PersonIDTextBox.Text),
                                phoneNumberTextBox.Text,
                                AdressTextBox.Text, EmailtextBox.Text, out bool isUpdate);
                    if (isUpdate)
                    {
                        MessageBox.Show("פרטי המנוי נערכו בהצלחה");
                        Utils.SwitchBetweenWindows(this, new MemberForm(UpdatedMember));
                    }
                    else
                    {
                        MessageBox.Show("שגיאה בעדכון פרטי המנוי");
                        Utils.SwitchBetweenWindows(this, new MemberForm(member));
                    }

                }
            }
            else
            {
                MessageBox.Show("נא למלא את כל הפרטים");
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (member == null)
                Utils.SwitchBetweenWindows(this, new MembersForm());
            else
                Utils.SwitchBetweenWindows(this, new MemberForm(member));
        }

        private void AddMember_Load(object sender, EventArgs e)
        {

        }
    }
}
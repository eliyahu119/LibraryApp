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
    /// This form is used to add book attributes like author, publisher, or genre.
    /// </summary>
    public partial class AddBookAttirbutes: Form 
    {
        
        private readonly Type T;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddBookAttirbutes"/> class.
        /// It displays the window correspondingly with the type of bookAttirbute.
        /// </summary>
        /// <param name="t">The type of the book attribute to add.</param>
        public AddBookAttirbutes(Type t) 
        {
            InitializeComponent();
            T = t;
            if (T.Equals(typeof(Generes)))
            {
                bookAttirbuteLabel.Text=string.Format(bookAttirbuteLabel.Text, "זאנר");
            }
            else if (T.Equals(typeof(Authors)))
            {
                bookAttirbuteLabel.Text=string.Format(bookAttirbuteLabel.Text, " מחבר");
            }
            else if (T.Equals(typeof(Publishers)))
            {
                bookAttirbuteLabel.Text= string.Format(bookAttirbuteLabel.Text, " מוציא לאור");
            }
          
        }

        /// <summary>
        /// Handles the Click event of the submitButton control.
        /// Sends the book attribute data to the data manager.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            string value = bookAttirbuteTextBox.Text;
            if (value!="")
            {
                DataManager.AddBookAttributesToDB(value,T);
            }
            MessageBox.Show("אלמנט נוסף בהצלחה");
            this.Close();
            

        }

     
    }
}

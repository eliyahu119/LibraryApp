using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class AddBookAttirbutes: Form 
    {
        
        private readonly Type T;

        /// <summary>
        /// display the window  correspondingly with the type of bookAttirbute
        /// </summary>
        /// <param name="t"></param>
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
        /// //send the book aattirbute data to the data manager.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

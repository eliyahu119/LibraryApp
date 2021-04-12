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

        private Type T;
        private static AddBookAttirbutes instance = null;
        //implenting singelton pattern to this class
        public static AddBookAttirbutes Instance(Type t)
        {

            if (instance == null)
            {
                instance = new AddBookAttirbutes(t);
            }
            instance.SetAsNewWindow(t);
            return instance;

        }

  

        private void SetAsNewWindow(Type t)
        {
            T = t;
            if (T.Equals(typeof(Generes)))
            {
                bookAttirbuteLabel.Text = string.Format(bookAttirbuteLabel.Text, "זאנר");
            }
            else if (T.Equals(typeof(Authors)))
            {
                bookAttirbuteLabel.Text = string.Format(bookAttirbuteLabel.Text, " מחבר");
            }
            else if (T.Equals(typeof(Publishers)))
            {
                bookAttirbuteLabel.Text = string.Format(bookAttirbuteLabel.Text, " מוציא לאור");
            }
        }

        

        /// <summary>
        /// display the window  correspondingly with the type of bookAttirbute
        /// </summary>
        /// <param name="t"></param>
        private AddBookAttirbutes(Type t) 
        {
            InitializeComponent();
           
          
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

        private void AddBookAttirbutes_Load(object sender, EventArgs e)
        {

        }
    }
}

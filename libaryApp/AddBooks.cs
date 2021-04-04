using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class AddBooks : Form
    {
        private static AddBooks instance = null;

        private AddBooks()
        {
            InitializeComponent();
        }
        //implenting singelton pattern to this class
        public static AddBooks Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddBooks();
                }
                return instance;
            }
        }
     

    
       /// <summary>
       /// allow numeric charchters in the copy and publication year textboxes
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void AllowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    

 

        private void AddBooks_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            setComboBoxes();

        }

        /// <summary>
        /// set the comboBoxes and their attributes.
        /// </summary>
        private void setComboBoxes()
        {
            var GenereList = DataManager.GetGeneresFromDB();
            var AuthorsList = DataManager.GetAuthorsFromDB();
            var PublisherList = DataManager.GetPublishersFromDB();
            this.GenereComboBox.DisplayMember = "Genere";
            this.GenereComboBox.DataSource = GenereList;
            this.GenereComboBox.ValueMember = null;
            this.authorComboBox.DisplayMember = "Author";
            this.authorComboBox.DataSource = AuthorsList;
            this.authorComboBox.ValueMember = null;
            this.publicationComboBox.DisplayMember = "Publisher";
            this.publicationComboBox.DataSource = PublisherList;
            this.publicationComboBox.ValueMember = null;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Generes Genere= (Generes)GenereComboBox.SelectedValue;
            Authors author = (Authors)authorComboBox.SelectedValue;
            Publishers Publisher = (Publishers)publicationComboBox.SelectedValue;
            string BookName = this.AddBookTxt.Text;
            Int16 publicationYear = Convert.ToInt16(publicationYearTxt.Text);
            int NumberOfCopies = Convert.ToInt32(NumberOfCopiesTxt.Text);
            DataManager.AddBookToDB(BookName, Genere, author, Publisher, publicationYear, NumberOfCopies);

        }
    }
}

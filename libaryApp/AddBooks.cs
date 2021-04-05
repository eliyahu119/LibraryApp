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
            BindingList<BookAttributes> GenereList = DataManager.GetAttributesFromDB<Generes>();
            setBookAttirbuteComboBox<Generes>(GenereComboBox, GenereList);
            BindingList<BookAttributes> AuthorsList = DataManager.GetAttributesFromDB<Authors>();
            setBookAttirbuteComboBox<Authors>(authorComboBox, AuthorsList);
            BindingList<BookAttributes> PublisherList = DataManager.GetAttributesFromDB<Publishers>();
            setBookAttirbuteComboBox<Publishers>(publicationComboBox, PublisherList);
        }

        private void setBookAttirbuteComboBox<T>(ComboBox comboBox, BindingList<BookAttributes> list) where T : BookAttributes
        {
            list.Add((T)Activator.CreateInstance(typeof(T), new object[] { -1, "הוסף..."}));
            comboBox.DisplayMember = "value";
            comboBox.DataSource = list;
            comboBox.ValueMember = null;
        }
        /// <summary>
        /// when the submit button is click the new book is added to the db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_Click(object sender, EventArgs e)
        {
            if ((AddBookTxt.Text != "") && (publicationYearTxt.Text != "") && (NumberOfCopiesTxt.Text != ""))
            {
                Generes Genere = (Generes)GenereComboBox.SelectedValue;
                Authors author = (Authors)authorComboBox.SelectedValue;
                Publishers Publisher = (Publishers)publicationComboBox.SelectedValue;
                string BookName = this.AddBookTxt.Text;
                Int16 publicationYear = Convert.ToInt16(publicationYearTxt.Text);
                int NumberOfCopies = Convert.ToInt32(NumberOfCopiesTxt.Text);
                DataManager.AddBookToDB(BookName, Genere, author, Publisher, publicationYear, NumberOfCopies);
                MessageBox.Show("הספר נוסף בהצלחה");
                this.Close();
            }
            else
            {
                MessageBox.Show("נא למלא את כל השדות");
            }

        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            BookAttributes elem = (BookAttributes)comboBox.SelectedValue;
            Type t = elem.GetType();
         
            if (elem.ID == -1)
            {
                Form form = new AddBookAttirbutes(t);
                form.ShowDialog();
                setComboBoxes();
            }
        }


    }
}

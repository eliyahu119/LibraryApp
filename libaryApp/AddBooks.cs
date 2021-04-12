using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;



namespace libaryApp
{
    public partial class AddBooks : Form
    {

        private Book book = null;
        public AddBooks(Book book = null)
        {
            this.book = book;
            InitializeComponent();
            //allow only numeric
            publicationYearTxt.KeyPress += new KeyPressEventHandler(Utils.AllowOnlyNumeric);
            NumberOfCopiesTxt.KeyPress += new KeyPressEventHandler(Utils.AllowOnlyNumeric);
        }










        private void AddBooks_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            setComboBoxes();
            if (book != null)
            {
                GenereComboBox.SelectedIndex = GenereComboBox.Items.IndexOf(book.Genre);
                authorComboBox.SelectedIndex = authorComboBox.Items.IndexOf(book.Author);
                publicationComboBox.SelectedIndex = publicationComboBox.Items.IndexOf(book.Publisher);
                publicationYearTxt.Text = book.PublicationYear.ToString();
                AddBookTxt.Text = book.BookName;
                NumberOfCopiesTxt.Hide();
                copiesLabel.Hide();
                submit.Text = "ערוך פרטי ספר";

            }
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
            list.Add((T)Activator.CreateInstance(typeof(T), new object[] { -1, "הוסף..." }));
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
            if (((AddBookTxt.Text != "") && (publicationYearTxt.Text != "")) && ((book != null) || (NumberOfCopiesTxt.Text != "")))
            {
                Generes Genere = (Generes)GenereComboBox.SelectedValue;
                Authors author = (Authors)authorComboBox.SelectedValue;
                Publishers Publisher = (Publishers)publicationComboBox.SelectedValue;
                string BookName = this.AddBookTxt.Text;
                short publicationYear = short.TryParse(publicationYearTxt.Text, out publicationYear) ? publicationYear : (short)0;
                if (Utils.AllowOnlyInRange(0, DateTime.Now.Year, publicationYearTxt))
                {
                    MessageBox.Show("השנה שציינת עדיין לא הגיעה.");
                    return;
                }
                int NumberOfCopies = int.TryParse(NumberOfCopiesTxt.Text, out NumberOfCopies) ? NumberOfCopies : 1;



                if (null == book)
                {
                    DataManager.AddBookToDB(BookName, Genere, author, Publisher, publicationYear, NumberOfCopies);
                    MessageBox.Show("הספר נוסף בהצלחה");
                    BackButton_Click();
                }
                else
                {
                    DataManager.EditBookInDB(book.getBookID(), BookName, Genere, author, Publisher, publicationYear);
                    MessageBox.Show("הספר נערך  בהצלחה");
                    BackButton_Click();

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("נא למלא את כל השדות");
            }

        }

        /// <summary>
        /// when the selected item in combox have id of -1 (the Agreed sign for this Action) the add new book attirbute window is open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void BackButton_Click(object sender=null, EventArgs e=null)
        {
            if (book==null)
            {
                Utils.SwitchBetweenWindows(this, new BookForm());
            }
            else
            {
                Utils.SwitchBetweenWindows(this, new BookDetails(book));
            }
           
        }
    }
}

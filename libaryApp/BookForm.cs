using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{
    public partial class BookForm : Form
    {
       // public List<Book>
        public BookForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = DataManager.getAllBooks();
            ChangeHeaders();

        }

        //translate the header of the Columns to hebrew 
        private void ChangeHeaders()
        {
            dataGridView1.Columns["BookName"].HeaderText = "שם הספר";
            dataGridView1.Columns["Genre"].HeaderText = "ז'אנר";
            dataGridView1.Columns["Author"].HeaderText = "סופר";
            dataGridView1.Columns["Publisher"].HeaderText = "הוצאה לאור";
            dataGridView1.Columns["PublicationYear"].HeaderText = "שנת יציאה";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Utils.SwitchBetweenWindows(  this, new MainWindow());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
        private static AddMember instance = null;

        private AddMember()
        {
            InitializeComponent();
        }

        public static AddMember Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AddMember();
                }
                return instance;
            }
        }
        private void AddMember_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

        }

  
    }
}

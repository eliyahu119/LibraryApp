using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{

    ////////////////////////////////////////////////
    ///this class give utils functions for the entire project 
    ////////////////////////////////////////////////


    static class Utils
    {
        static public Form f;
        /// <summary>
        /// switch between the 2 windows
        /// </summary>
        /// <param name="current"> the current window</param>
        /// <param name="otherWindow">the next form</param>
      
        static public void SwitchBetweenWindows(Form current, Form otherWindow)
        {

            otherWindow.Location = f.Location; //change the location as the last window.
            otherWindow.StartPosition = FormStartPosition.Manual;
            otherWindow.Show();
            current.Hide();
            otherWindow.Closed += (s, args) => current.Close();
        }


    


        /// <summary>
        ///updates rowNumbers of the line the lines
        /// </summary>
        public static void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// allow numeric charchters  only in the Text object. and limits it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void AllowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        public static bool AllowOnlyInRange(int min, int max, TextBox textbox)
        {
            int val = 0;
            bool res = Int32.TryParse(textbox.Text, out val);
            if (res == true && val >= min && val <= max)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Please input {min} to {max} only.");
                return false;
            }
        }
        public static void ChangeColumnsNameOfGrid(DataGridView grid, Tuple<string, string>[] pairs)
        {
            foreach (var pair in pairs)
            {
                grid.Columns[pair.Item1].HeaderText = pair.Item2;
            }
        }

        ///////////
        //creating a place holder events
        public static void RemoveText(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "שורת חיפוש")
            {
                ((TextBox)sender).Text = "";
            }
        }

        public static void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = "שורת חיפוש";
        }
        /////////////
    }
}

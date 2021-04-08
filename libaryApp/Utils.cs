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

        /// <summary>
        /// switch between the 2 windows
        /// </summary>
        /// <param name="current"> the current window</param>
        /// <param name="otherWindow">the next form</param>
        static public void SwitchBetweenWindows(Form current, Form otherWindow)
        {

             otherWindow.Location = current.Location; //change the location as the last window.
             otherWindow.StartPosition = FormStartPosition.Manual;
             otherWindow.Show();
             current.Hide ();
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
        /// allow numeric charchters  only in the Text object.
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

        public static void ChangeColumnsNameOfGrid(DataGridView grid,Tuple<string,string>[] pairs)
        {
            foreach (var pair in pairs)
            {
                grid.Columns[pair.Item1].HeaderText = pair.Item2;
            }
        }
    }
}

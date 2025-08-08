using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace libaryApp
{

    /// <summary>
    /// This class provides utility functions for the entire project.
    /// </summary>
    static class Utils
    {

        /// <summary>
        /// Switches between two windows.
        /// </summary>
        /// <param name="current">The current window.</param>
        /// <param name="otherWindow">The next form.</param>
        static public void SwitchBetweenWindows(Form current, Form otherWindow)
        {

            otherWindow.Location = current.Location; //change the location as the last window.
            otherWindow.StartPosition = FormStartPosition.Manual;
            otherWindow.Show();
            current.Hide();
        }

        /// <summary>
        /// Updates the row numbers of the lines.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPostPaintEventArgs"/> instance containing the event data.</param>
        public static void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Allows only numeric characters in the TextBox and limits it.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        public static void AllowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// Allows only numbers in a given range.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="textbox">The TextBox to validate.</param>
        /// <returns>True if the value is in the range, false otherwise.</returns>
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

        /// <summary>
        /// Changes the column names of a DataGridView.
        /// </summary>
        /// <param name="grid">The DataGridView.</param>
        /// <param name="pairs">An array of tuples containing the old and new column names.</param>
        public static void ChangeColumnsNameOfGrid(DataGridView grid, Tuple<string, string>[] pairs)
        {
            foreach (var pair in pairs)
            {
                grid.Columns[pair.Item1].HeaderText = pair.Item2;
            }
        }

        /// <summary>
        /// Removes the placeholder text from a TextBox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public static void RemoveText(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "שורת חיפוש")
            {
                ((TextBox)sender).Text = "";
            }
        }

        /// <summary>
        /// Adds placeholder text to a TextBox if it is empty.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public static void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
                ((TextBox)sender).Text = "שורת חיפוש";
        }
    }
}

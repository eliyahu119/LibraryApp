using System;
using System.Collections.Generic;
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
      }
}

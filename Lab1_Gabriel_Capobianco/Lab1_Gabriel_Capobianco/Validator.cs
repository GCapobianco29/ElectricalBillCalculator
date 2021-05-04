using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Gabriel_Capobianco
{
    /// <summary>
    /// Repository of static Validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Check if the input box is empty
        /// </summary>
        /// <param name="textBox">Usage</param>
        /// <param name="name">Type of user</param>
        /// <returns>Entry is empty</returns>
        public static bool IsPresent(TextBox textBox, string name)
        {
            bool isValid = true;
            if(textBox.Text == "")
            {
                isValid = false;
                MessageBox.Show(name + " must not be empty", "Entry Error");
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// Check if the number entered is positive
        /// </summary>
        /// <param name="textBox">Usage</param>
        /// <param name="name">Type of user</param>
        /// <returns>Entry is not positive</returns>
        public static bool IsPositive(string textBox, string name)
        {
            double input = Convert.ToDouble(textBox);
            if (input >= 0)
                return true;
            else
            {
                MessageBox.Show(name + " must be a positive number.", "Entry Error");
                return false;
            }
        }
    }
}

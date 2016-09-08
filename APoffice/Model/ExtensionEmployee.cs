using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APoffice.Model
{
    /// <summary>
    /// Class for Extensions Method for Employee
    /// </summary>
    public static class ExtensionEmployee
    {
        /// <summary>
        /// Show information about Employee
        /// </summary>
        /// <param name="employee"></param>
        public static void ShowInfo(this Employee employee)
        {
            MessageBox.Show($"{employee.Name} {employee.Surname}");// MessageBox.Show(string.Format("{0} {1}", employee.Name, employee.Surname));
        }
    }
}

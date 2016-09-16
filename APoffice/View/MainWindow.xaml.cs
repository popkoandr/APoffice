using System.Collections.Generic;
using System.Windows;
using APoffice.Model;
using APoffice.ViewModel;
using System.Data.Entity;

namespace APoffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //public IEnumerable<Employee> Employeeses { get; set; } 
             
        //private void button_Copy_Click(object sender, RoutedEventArgs e)
        //{
        //    using (EmployeeContext db = new EmployeeContext())
        //    {
                 
        //        db.Employees.Load();/*Include(x => x.Branch)*/;
        //        Employeeses = db.Employees.Local;
        //        foreach (var employee in Employeeses)
        //        {
        //            MessageBox.Show(employee.Name);
        //        }
        //    }
        //}
    }
}

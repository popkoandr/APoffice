using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using APoffice.Model;
using APoffice.ViewModel;

namespace APoffice.ViewModel
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branch> Branchs { get; set; }

        public EmployeeContext() : base("EmloyeeModel")
        {}
        static EmployeeContext()// for not empty initialize of DB
        {
            Database.SetInitializer(new MyEmployeeContextInitializer());
        }
    }
}

class MyEmployeeContextInitializer:DropCreateDatabaseAlways<EmployeeContext>
{
    protected override void Seed(EmployeeContext context)
    {
        Branch b1 = new Branch() {Adress = "borispilska str.", CityName = "Kiev"};
        Branch b2 = new Branch() { Adress = "algazin str.", CityName = "Priluki" };
        Branch b3 = new Branch() { Adress = "lepse str.", CityName = "Chernihiv" };
        Branch b4 = new Branch() { Adress = "noname str.", CityName = "Kiev" };

        context.Branchs.AddRange(new List<Branch>() { b1, b2, b3, b4});
        context.SaveChanges();

        Employee e1 = new Employee("Taras", "Plavin") { Branch = b1};
        Employee e2 = new Employee("Andrew", "Popko") { Branch = b1 };
        Employee e3 = new Employee("Sasha", "Dashko") { Branch = b1 };
        Employee e4 = new Employee("Maria", "Korotko") { Branch = b2 };
        Employee e5 = new Employee("Andrew", "Antosev") { Branch = b3 };
        Employee e6 = new Employee("Andrew", "Boiko") { Branch = b4 };
        Employee e7 = new Employee("Valentyn", "Popko") { Branch = b4 };

        context.Employees.AddRange(new List<Employee>() {e1, e2, e3, e4, e5, e6, e7});
        context.SaveChanges();
        MessageBox.Show($"Users add to db with COUNT = {context.Employees.Count()}");
    }
}
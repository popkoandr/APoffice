using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using APoffice.Model;
using APoffice.RepositoryFolder;


namespace APoffice.RepositoryFolder
{
    public class EmployeeContext : DbContext
    {
        #region Fields
        //collection of Employees
        public DbSet<Employee> Employees { get; set; }
        //collection of Branches
        public DbSet<Branch> Branches { get; set; }
        #endregion

        #region Constructors
        //default constructor which calls base constr. with string-type parameter named as << Connection String>> from app.config
        public EmployeeContext() : base("EmloyeeModel")
        { }

        // create static constructor call initializing for Db with some value 
        static EmployeeContext()
        {
            Database.SetInitializer(new MyEmployeeContextInitializer());
        }
        #endregion
    }
}

/// <summary>
/// Class for initializing Context with some value
/// </summary>
class MyEmployeeContextInitializer : DropCreateDatabaseAlways<EmployeeContext>
{
    //oveeride method from base class
    protected override void Seed(EmployeeContext context)
    {
        Branch b1 = new Branch() { Adress = "borispilska str.", CityName = "Kiev" };
        Branch b2 = new Branch() { Adress = "algazin str.", CityName = "Priluki" };
        Branch b3 = new Branch() { Adress = "lepse str.", CityName = "Chernihiv" };
        Branch b4 = new Branch() { Adress = "noname str.", CityName = "Kiev" };

        //add to Branches and Save (write to db)
        context.Branches.AddRange(new List<Branch>() { b1, b2, b3, b4 });
        context.SaveChanges();

        Employee e1 = new Employee("Taras", "Plavin") { Branch = b1 };
        Employee e2 = new Employee("Andrew", "Popko") { Branch = b1 };
        Employee e3 = new Employee("Sasha", "Dashko") { Branch = b1 };
        Employee e4 = new Employee("Maria", "Korotko") { Branch = b2 };
        Employee e5 = new Employee("Andrew", "Antosev") { Branch = b3 };
        Employee e6 = new Employee("Andrew", "Boiko") { Branch = b4 };
        Employee e7 = new Employee("Valentyn", "Popko") { Branch = b4 };

        //add to Employees and Save (write to db)
        context.Employees.AddRange(new List<Employee>() { e1, e2, e3, e4, e5, e6, e7 });
        context.SaveChanges();

        //show added count if success
        MessageBox.Show($"Users add to db with COUNT = {context.Employees.Count()}");
    }
}
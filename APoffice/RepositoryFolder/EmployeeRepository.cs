using System.Collections.Generic;
using APoffice.Model;
using System.Linq;
using System.Windows;

namespace APoffice.RepositoryFolder
{
    //4th - concrete final repository for Employee
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        //inject dependency in constructor
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        //get-only property for getting instance of EmployeeContext (DbContext)
        public EmployeeContext EmployeeContext//
        {
            get
            {
                return Context as EmployeeContext;
            }
        }

        public IEnumerable<Employee> GetTopCountEmployees(int count)
        {
            return EmployeeContext.Employees.Take(count).ToList();
        }
       
        public IEnumerable<Employee> GetBySurnameEmployees(string surname)
        {
            return EmployeeContext.Employees.Where(e=>e.Surname==surname);
        }
      
        //public void SGetBranches()
        //{
        //    IEnumerable<Branch> x = from emp in EmployeeContext.Employees
        //                            where emp.Name == "Andrew"
        //        join branche in EmployeeContext.Branches on emp.BranchId equals branche.Id
        //        where branche.CityName =="Kiev"
        //        orderby emp.Name descending
        //        select branche;
        //    MessageBox.Show(x.Count().ToString());

        //}

    }
}
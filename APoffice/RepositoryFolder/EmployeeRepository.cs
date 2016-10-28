using System.Collections.Generic;
using APoffice.Model;
using APoffice.ViewModel;
using System.Linq;
using System.Windows;

namespace APoffice.RepositoryFolder
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

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
        /// <summary>
        /// test query
        /// </summary>
        public void SGetBranches()
        {
            IEnumerable<Branch> x = from emp in EmployeeContext.Employees
                                    where emp.Name == "Andrew"
                join branche in EmployeeContext.Branchs on emp.BranchId equals branche.Id
                where branche.CityName =="Kiev"
                orderby emp.Name descending
                select branche;
            MessageBox.Show(x.Count().ToString());

        }

    }
}
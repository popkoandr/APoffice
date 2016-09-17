using System.Collections.Generic;
using APoffice.Model;
using APoffice.ViewModel;
using System.Linq;

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
    }
}
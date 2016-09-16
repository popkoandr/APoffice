using System.Collections.Generic;
using System.Data.Entity;
using APoffice.Model;
using APoffice.ViewModel;
using System.Data.Entity;
using System.Linq;

namespace APoffice.RepositoryFolder
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
        }

        public EmployeeContext EmployeeContext//syntax sugar
        {
            get
            {
                return Context as EmployeeContext;
            }
        }

        public IEnumerable<Employee> GetTopEmployee(int count)
        {
            
            return EmployeeContext.Employees.Take(count).ToList();
        }

        public IEnumerable<Employee> GetEmployeesWithBranch()
        {
            return EmployeeContext.Employees.Include(x => x.Branch).ToList();
        }
        
    }
}
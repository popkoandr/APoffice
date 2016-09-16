using System.Collections.Generic;
using System.Threading;
using APoffice.Model;

namespace APoffice.RepositoryFolder
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<Employee> GetTopEmployee(int count);
        IEnumerable<Employee> GetEmployeesWithBranch();

    }
}
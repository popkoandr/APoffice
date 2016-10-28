using System.Collections.Generic;
using System.Linq;
using System.Threading;
using APoffice.Model;

namespace APoffice.RepositoryFolder
{
    // 3rd - interface for defining methods of concrete employee repository 
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<Employee> GetTopCountEmployees(int count);
        IEnumerable<Employee> GetBySurnameEmployees(string surname);
        
    }
}
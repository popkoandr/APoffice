using System.Collections.Generic;
using System.Linq;
using System.Threading;
using APoffice.Model;

namespace APoffice.RepositoryFolder
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        IEnumerable<Employee> GetTopCountEmployees(int count);
        IEnumerable<Employee> GetBySurnameEmployees(string surname);
        
       // IQueryable<Branch> GetBranches
        void SGetBranches();

    }
}
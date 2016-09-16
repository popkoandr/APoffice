using System;

namespace APoffice.RepositoryFolder
{
    public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository Employees { get; }
        int Complete();

    }
}
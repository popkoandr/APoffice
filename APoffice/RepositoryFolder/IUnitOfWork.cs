using System;

namespace APoffice.RepositoryFolder
{
    //5th 
    public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository Employees { get; }
        int Complete();

    }
}
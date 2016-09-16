using APoffice.ViewModel;

namespace APoffice.RepositoryFolder
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly EmployeeContext _context;
        public IEmployeeRepository Employees { get; }

        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
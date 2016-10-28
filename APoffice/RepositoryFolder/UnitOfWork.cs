using APoffice.ViewModel;

namespace APoffice.RepositoryFolder
{
    //6th
    public class UnitOfWork:IUnitOfWork
    {
        //dependency field
        private readonly EmployeeContext _context;
        //get-only property for geting employee repository instance
        public IEmployeeRepository Employees { get; }

        //inject dependency via constructor and create instance of EmployeeRepository
        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
        }
        //save to db
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
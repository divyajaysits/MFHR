

using MF.HR.Entity;
using MF.HR.Repositories.Interfaces;
using MF.HR.Repositories;


namespace MF.HR.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        IEmployeeRepository _employeeRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_context);
                return _employeeRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

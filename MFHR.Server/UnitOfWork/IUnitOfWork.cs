using MF.HR.Entity;
using MF.HR.Repositories.Interfaces;

namespace MF.HR.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IEmployeeRepository Employees { get; }
    }
}

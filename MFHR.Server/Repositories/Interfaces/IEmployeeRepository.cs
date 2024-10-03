using MF.HR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MF.HR.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> AddEmployeeAsync(Employee entity);
        Task<int> UpdateEmployeeAsync(Employee entity);
        Task<Employee?> GetByEmployeeIdAsync(int id);
        Task<List<Employee>> GetAllActiveEmployeesAsync();
    }
}

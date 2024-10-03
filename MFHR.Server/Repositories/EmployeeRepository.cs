
using MF.HR.Entity;
using MF.HR.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace MF.HR.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly DbContext _context;
        protected readonly DbSet<Employee> _entities;

        public EmployeeRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<Employee>();
        }


        public async Task<int> AddEmployeeAsync(Employee employee)
        {
            employee.IsActive = true;
            await _entities.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.ID;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            employee.IsActive = true;
            _entities.Update(employee);
            await _context.SaveChangesAsync();
            return employee.ID;
        }

        public async Task<Employee?> GetByEmployeeIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(e => e.ID == id && e.IsActive);
        }

        public async Task<List<Employee>> GetAllActiveEmployeesAsync()
        {
            return await _entities.ToListAsync();
        }

    }
}

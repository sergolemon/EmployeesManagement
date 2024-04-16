using Core.Data;
using Core.Data.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public EmployeeRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddAsync(params Employee[] employees)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            dbContext.Employees.AddRange(employees);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAsync(Expression<Func<Employee, bool>>? filters = null)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            IQueryable<Employee> query = dbContext.Employees;

            if (filters is not null)
            {
                query = query.Where(filters);
            }

            return await query.ToListAsync();
        }

        public async Task<int> GetCountByWorkEmployeesAsync()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Employees.Where(empl => empl.Status == EmployeeStatus.Work).CountAsync();
        }

        public async Task<decimal> GetAverageSalaryByWorkEmployeesAsync()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return (decimal)await dbContext.Employees.Where(empl => empl.Status == EmployeeStatus.Work).AverageAsync(empl => (double)empl.Salary);
        }

        public async Task RemoveAsync(params Employee[] employees)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            dbContext.Employees.RemoveRange(employees);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Employee?> GetByIdOrNullAsync(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Employees.FirstOrDefaultAsync(empl => empl.Id == id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }
    }
}

using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAsync(Expression<Func<Employee, bool>>? filters = null);
        Task RemoveAsync(params Employee[] employees);
        Task AddAsync(params Employee[] employees);
        Task<int> GetCountByWorkEmployeesAsync();
        Task<Employee?> GetByIdOrNullAsync(Guid id);
        Task<decimal> GetAverageSalaryByWorkEmployeesAsync();
        Task UpdateAsync(Employee employee);
    }
}

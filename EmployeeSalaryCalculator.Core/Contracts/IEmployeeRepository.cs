using EmployeeSalaryCalculator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSalaryCalculator.Core.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}

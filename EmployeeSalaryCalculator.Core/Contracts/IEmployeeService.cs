using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSalaryCalculator.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<IEmployee>> GetEmployees();
        Task<IEmployee> GetEmployeeById(int id);
    }
}

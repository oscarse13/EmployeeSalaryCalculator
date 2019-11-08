using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSalaryCalculator.Data
{
    public class EmployeeDBRepository : IEmployeeRepository
    {
        /// <summary>
        /// The Database Context.
        /// </summary>
        private readonly EmployeeContext context;

        public EmployeeDBRepository(EmployeeContext contextObj)
        {
            context = contextObj;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employee.ToListAsync();
        }
    }
}

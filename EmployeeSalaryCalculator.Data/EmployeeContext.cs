using EmployeeSalaryCalculator.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSalaryCalculator.Data
{

    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        { }

        public DbSet<Employee> Employee { get; set; }

    }
}

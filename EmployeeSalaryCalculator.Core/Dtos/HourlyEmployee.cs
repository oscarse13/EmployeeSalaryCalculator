using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Dtos
{
    public class HourlyEmployee : IEmployee
    {
        public HourlyEmployee()
        {
            ContractTypeName = EmployeeContractType.HourlySalaryEmployee;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractType ContractTypeName { get; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary => 120 * HourlySalary * 12;
    }
}

using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Dtos
{
    public class MonthlyEmployee : IEmployee
    {
        public MonthlyEmployee()
        {
            ContractTypeName = EmployeeContractType.MonthlySalaryEmployee;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractType ContractTypeName { get; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary => MonthlySalary * 12;
    }
}

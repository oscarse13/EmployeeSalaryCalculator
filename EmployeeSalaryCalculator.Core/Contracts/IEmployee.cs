using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Contracts
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        EmployeeContractType ContractTypeName { get; }      
        decimal HourlySalary { get; set; }
        decimal MonthlySalary { get; set; }
        decimal AnnualSalary { get; }
    }
}

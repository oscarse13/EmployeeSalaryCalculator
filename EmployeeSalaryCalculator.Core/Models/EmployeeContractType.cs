using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;


namespace EmployeeSalaryCalculator.Core.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmployeeContractType
    {
        [EnumMember(Value = "Hourly Salary Employee")]
        HourlySalaryEmployee,
        [EnumMember(Value = "Monthly Salary Employee")]
        MonthlySalaryEmployee
    }
}

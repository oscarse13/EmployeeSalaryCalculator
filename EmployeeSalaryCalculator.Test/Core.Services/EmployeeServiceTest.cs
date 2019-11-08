using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Dtos;
using EmployeeSalaryCalculator.Core.Models;
using EmployeeSalaryCalculator.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryCalculator.Test.Core.Services
{
    public class EmployeeServiceTest
    {
        [Test]
        public void AnnualSalaryCalculated_WhenTheEmployeeHasMonthlyContract()
        {
            //formula to calculate annual salary to MonthlyEmployee MonthlySalary * 12
            //Arrange
            const decimal annualSalaryExpected = 960000;
            var monthlyEmployee = new MonthlyEmployee
            {
                Id = 1,
                Name = "Oscar",
                MonthlySalary = 80000
            };
            //Assert
            Assert.AreEqual(monthlyEmployee.AnnualSalary, annualSalaryExpected);
        }

        [Test]
        public void AnnualSalaryCalculated_WhenTheEmployeeHasHourlyContract()
        {
            //formula to calculate annual salary to HourlyEmployee 120 * HourlySalary * 12
            //Arrange
            const decimal annualSalaryExpected = 72000;
            var hourlyEmployee = new HourlyEmployee
            {
                Id = 1,
                Name = "Oscar",
                HourlySalary = 50
            };
            //Assert
            Assert.AreEqual(hourlyEmployee.AnnualSalary, annualSalaryExpected);
        }

        [Test]
        public async Task SuccessGettingEmployees()
        {
            //Arrange
            var employees = GetFakeDataEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var expectedListResponse = new List<IEmployee>
            {
                new HourlyEmployee() {Id = 1, HourlySalary = 50, MonthlySalary = 6000, Name = "Oscar"},
                new MonthlyEmployee() {Id = 2, HourlySalary = 50, MonthlySalary = 6000, Name = "Celeste"}
            };

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseListOfEmployees = await employeeService.GetEmployees();

            //Assert

            Assert.AreEqual(responseListOfEmployees.Count(), expectedListResponse.Count);
            Assert.AreEqual(responseListOfEmployees.FirstOrDefault().Id, expectedListResponse.FirstOrDefault().Id);
            Assert.AreEqual(responseListOfEmployees.FirstOrDefault().Name, expectedListResponse.FirstOrDefault().Name);
            Assert.AreEqual(responseListOfEmployees.LastOrDefault().Id, expectedListResponse.LastOrDefault().Id);
            Assert.AreEqual(responseListOfEmployees.LastOrDefault().Name, expectedListResponse.LastOrDefault().Name);
        }


        [Test]
        public async Task SuccessGettingEmployeeById()
        {
            //Arrange
            var employees = GetFakeDataEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var expectedResponse = new HourlyEmployee()
            {
                Id = 1,
                HourlySalary = 50,
                MonthlySalary = 6000,
                Name = "Oscar"
            };

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseEmployee = await employeeService.GetEmployeeById(1);

            //Assert
            Assert.AreEqual(responseEmployee.Id, expectedResponse.Id);
            Assert.AreEqual(responseEmployee.Name, expectedResponse.Name);
        }

        [Test]
        public async Task GettingEmployeeById_WhenTheEmployeeDoesNotExist_ReturnNull()
        {
            //Arrange
            var employees = GetFakeDataEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseEmployee = await employeeService.GetEmployeeById(3);

            //Assert
            Assert.IsNull(responseEmployee);
        }

        private static List<Employee> GetFakeDataEmployees()
        {
            return new List<Employee>
            {
                new Employee {ContractTypeName = EmployeeContractType.HourlySalaryEmployee, Id = 1, HourlySalary = 50, MonthlySalary = 6000, Name = "Oscar"},
                new Employee {ContractTypeName = EmployeeContractType.MonthlySalaryEmployee, Id = 2, HourlySalary = 50, MonthlySalary = 6000, Name = "Celeste"}
            };
        }
    }
}

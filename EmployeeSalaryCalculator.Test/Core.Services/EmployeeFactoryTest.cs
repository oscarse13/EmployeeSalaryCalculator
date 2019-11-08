using EmployeeSalaryCalculator.Core.Dtos;
using EmployeeSalaryCalculator.Core.Models;
using EmployeeSalaryCalculator.Core.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSalaryCalculator.Test.Core.Services
{
    public class EmployeeFactoryTest
    {
        [Test]
        public void CanCreateMonthlyEmployeeObject()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var monthlyEmployee = employeeFactory.CreateEmployee(EmployeeContractType.MonthlySalaryEmployee);

            //Assert
            Assert.IsInstanceOf<MonthlyEmployee>(monthlyEmployee);
        }

        [Test]
        public void CanCreateHourlyEmployeeObject()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var hourlyEmployee = employeeFactory.CreateEmployee(EmployeeContractType.HourlySalaryEmployee);

            //Assert
            Assert.IsInstanceOf<HourlyEmployee>(hourlyEmployee);
        }
    }
}

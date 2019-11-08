using EmployeeSalaryCalculator.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSalaryCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                if (!employees.Any()) return NotFound();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EmployeeController::GetEmployees");
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }           
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                if (employee == null) return NotFound();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EmployeeController::GetEmployee id:{0}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
          
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEmployeeApplication.IService;
using MyEmployeeApplication.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyEmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
               return Ok(await _employeeService.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{empId:int}")]
        public async Task<ActionResult> GetEmployeesById(int empId)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(empId);
                if(employee != null)
                {
                    return Ok(employee);
                }                
                return NotFound($"No records Found for the employee id:{empId}");
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Enter valid details for employee");
                }
                var result = await _employeeService.AddEmployee(employee);
               
                return CreatedAtAction(nameof(GetEmployeesById), new { empId = employee.EmployeeId }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{empId:int}")]
        public async Task<ActionResult> UpdateEmployee(Employee employee, int empId)
        {
            try
            {
                if (empId != employee.EmployeeId)
                {
                    return BadRequest($"Please enter valid Id");
                }
                var empl = await _employeeService.GetEmployeeById(empId);
                if (empl == null)
                {
                    return NotFound($"No record found in the system for employee Id {empId}");
                }
                var result = await _employeeService.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{empId:int}")]
        public async Task<ActionResult> RemoveEmployee(int empId)
        {
            try
            {
                var emp = await _employeeService.GetEmployeeById(empId);
                if (emp == null)
                {
                    return NotFound($"No record found in the system for employee Id {empId}");
                }
                await _employeeService.RemoveEmployee(empId);
                return Ok($"Employee Record with id {empId} has been removed");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchEmployee(string name, Gender? gender)
        {
            try
            {
                var result = await _employeeService.SearchEmployee(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }
                else
                    return NotFound($"No Records Found in the system");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}


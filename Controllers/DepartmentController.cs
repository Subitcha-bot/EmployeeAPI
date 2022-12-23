using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEmployeeApplication.IService;
using MyEmployeeApplication.Model;
using System;
using System.Threading.Tasks;

namespace MyEmployeeApplication.Controllers  
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<Department>> GetDepartments()
        {
            try
            {
                var departments = await _departmentService.GetDepartments();

                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{departmentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Department>> GetDepartmentById(int departmentId)
        {
            try
            {
                var department = await _departmentService.GetDepartmentById(departmentId);

                    if (department != null && department.DepartmentId != 0)
                    {
                        return Ok(department);
                    }
                
                else

                    return NotFound($"No Record found for the DepartmentID:{departmentId}");
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department department)
        {
            try
            {
                var _department = await _departmentService.CreateDepartment(department);

                if (_department != null)
                {
                    return CreatedAtAction(nameof(GetDepartmentById), new { departmentId = department.DepartmentId }, department);
                }
                else
                    return BadRequest(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{departmentId:int}")]

        public async Task<ActionResult<Department>> UpdateDepartment([FromBody] Department depart, int departmentId)
        {
            try
            {
                if (departmentId != depart.DepartmentId)
                {
                    return BadRequest(StatusCodes.Status400BadRequest);
                }
                var dept = await GetDepartmentById(departmentId);
                //var dept = await GetDepartmentById(depart.DepartmentId);
                var getDepart = dept.Result as ObjectResult;

                if (getDepart.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }
               return Ok(await _departmentService.UpdateDepartment(depart));
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        [HttpDelete("{departmentId:int}")]

        public async Task<ActionResult> DeleteDepartment(int departmentId)
        {
            try
            {
                var dept = await _departmentService.GetDepartmentById(departmentId);
                if (dept == null)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }
                await _departmentService.DeleteDepartment(departmentId);

                return Ok(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

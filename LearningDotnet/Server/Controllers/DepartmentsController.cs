using LearningDotnet.Server.Models;
using LearningDotnet.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDotnet.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        public readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            try
            {
                if (department == null) return BadRequest();
                var newDepartmentId = await departmentRepository.GetDepartmentById(department.DepartmentId);

                var addDepartment = await departmentRepository.AddDepartment(department);
                if (newDepartmentId != null)
                {
                    ModelState.AddModelError("Department", "Department already exists");
                    return BadRequest(ModelState);
                }
                return CreatedAtAction(nameof(GetDepartmentById),
                        new { id = addDepartment.DepartmentId }, addDepartment
                    );
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error creating new department data system error={ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            try
            {

                var departmentToDelete = await departmentRepository.GetDepartmentById(id);

                if (departmentToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                await departmentRepository.DeleteDepartment(id);

                return Ok($"Employee with Id = {id} deleted");

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting the employee record");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            try
            {
                var result = await departmentRepository.GetDepartmentById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        


    }
}

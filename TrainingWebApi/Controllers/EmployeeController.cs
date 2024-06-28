using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeRepoAsync EmpRepo;
        public EmployeeController(IEmployeeRepoAsync empRepoAsync)
        {
            EmpRepo = empRepoAsync;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployee()
        {
            List<Employee> employees = await EmpRepo.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{eid}")]
        public async Task<ActionResult> GetOne(int eid)
        {
            try
            {
                Employee employee = await EmpRepo.GetEmployeeAsync(eid);
                return Ok(employee);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(Employee employee)
        {
            try
            {
                await EmpRepo.InsertEmployeeAsync(employee);
                return Created($"api/Employee/{employee.EmpId}", employee);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{eid}")]
        public async Task<ActionResult> Update(int eid, Employee employee)
        {
            try
            {
                await EmpRepo.UpdateEmployeeAsync(eid, employee);
                return Ok(employee);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{eid}")]
        public async Task<ActionResult> Delete(int eid)
        {
            try
            {
                await EmpRepo.DeleteEmployeeAsync(eid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
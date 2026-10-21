using ISC_CleanWebApp.DTO;
using ISC_CleanWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISC_CleanWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> Get()
        {
            var employees = await _employeeService.GetAllAsync();
            return employees;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return employee;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO employeeDTO)
        {
            await _employeeService.AddAsync(employeeDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeDTO employeeDTO)
        {
            await _employeeService.UpdateAsync(employeeDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return Ok();
        }
    }
}

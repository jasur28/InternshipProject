using InternshipProject.BLL.DTOs.CompanyDTO;
using InternshipProject.BLL.DTOs.EmployeeDTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateEmployeeDTO>> Create(CreateEmployeeDTO item)
        {
            if (item.Name is null)
                return BadRequest();

            var employee = await _employeeService.Create(item);

            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var item = await _employeeService.Get(id);
            if (item == null)
                return NotFound();
            else
                return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var item = await _employeeService.Get(id);
            if (item != null)
            {
                await _employeeService.Delete(item);
                return true;
            }

            return false;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Update(int id, EmployeeDTO item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }


            var employee = await _employeeService.Update(item);
            return Ok(employee);
        }
    }
}

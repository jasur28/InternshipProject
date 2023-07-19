using InternshipProject.BLL.DTOs.CompanyDTO;
using InternshipProject.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> GetAll()
        {
                return Ok(await _companyService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetById(int id)
        {
            var item = await _companyService.Get(id);
            if (item == null)
                return NotFound();
            else
                return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var item = await _companyService.Get(id);
            if (item != null)
            {
                await _companyService.Delete(item);
                return true;
            }

            return false;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDTO>> Update(int id, CompanyDTO item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }


            var farmer = await _companyService.Update(item);
            return Ok(farmer);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCompanyDTO>> Create(CreateCompanyDTO companyDTO)
        {
            if (companyDTO.Name is null)
                return BadRequest();

            var company = await _companyService.Create(companyDTO);

            return Ok(company);
        }
    }
}

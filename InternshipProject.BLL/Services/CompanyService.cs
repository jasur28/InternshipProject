using InternshipProject.BLL.DTOs.CompanyDTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;

namespace InternshipProject.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CreateCompanyDTO> Create(CreateCompanyDTO companyDTO)
        {
            var company = new Company()
            {
                Name = companyDTO.Name

            };
            await _companyRepository.Create(company);
            return companyDTO;

        }

        public async Task<bool> Delete(CompanyDTO companyDTO)
        {
            var item = await _companyRepository.GetById(companyDTO.Id);
            return await _companyRepository.Delete(item);

        }

        public async Task<CompanyDTO> Get(int id)
        {
            var company = await _companyRepository.GetById(id);

            if (company.Id != null)
            {
                CompanyDTO companyDTO = new()
                {
                    Id = company.Id,
                    Name = company.Name
                };
                return companyDTO;
            }

            return null;
        }

        public async Task<List<CompanyDTO>> GetAll()
        {
            var list = await _companyRepository.GetAll();

            var companyList = list.Select(c => new CompanyDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return companyList;
        }

        public async Task<CompanyDTO> Update(CompanyDTO companyDTO)
        {
            var company = await _companyRepository.GetById(companyDTO.Id);
            company.Name = companyDTO.Name;
            

            await _companyRepository.Update(company);

            return companyDTO;

        }

    }
}

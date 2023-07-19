using InternshipProject.BLL.DTOs.CompanyDTO;

namespace InternshipProject.BLL.Interfaces
{
    public interface ICompanyService
    {
        Task<CreateCompanyDTO> Create(CreateCompanyDTO item);
        Task<CompanyDTO> Get(int id);
        Task<CompanyDTO> Update(CompanyDTO item);
        Task<bool> Delete(CompanyDTO item);
        Task<List<CompanyDTO>> GetAll();


    }
}

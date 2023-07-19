using InternshipProject.BLL.DTOs.CompanyDTO;
using InternshipProject.BLL.DTOs.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<CreateEmployeeDTO> Create(CreateEmployeeDTO item);
        Task<EmployeeDTO> Get(int id);
        Task<EmployeeDTO> Update(EmployeeDTO item);
        Task<bool> Delete(EmployeeDTO item);
        Task<List<EmployeeDTO>> GetAll();
    }
}

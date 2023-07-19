using InternshipProject.BLL.DTOs.CompanyDTO;
using InternshipProject.BLL.DTOs.EmployeeDTO;
using InternshipProject.BLL.Interfaces;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using InternshipProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<CreateEmployeeDTO> Create(CreateEmployeeDTO item)
        {
            var employee = new Employee()
            {
                Name = item.Name,
                CompanyId = item.CompanyId

            };
            await _employeeRepository.Create(employee);
            return item;
        }

        public async Task<bool> Delete(EmployeeDTO item)
        {
            var delete = await _employeeRepository.GetById(item.Id);
            return await _employeeRepository.Delete(delete);
        }

        public async Task<EmployeeDTO> Get(int id)
        {
            var item = await _employeeRepository.GetById(id);

            if (item.Id != null)
            {
                EmployeeDTO employeeDTO = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CompanyId = item.CompanyId
                };
                return employeeDTO;
            }

            return null;
        }

        public async Task<List<EmployeeDTO>> GetAll()
        {
            var list = await _employeeRepository.GetAll();

            var employeeList = list.Select(c => new EmployeeDTO
            {
                Id = c.Id,
                Name = c.Name,
                CompanyId = c.CompanyId
            }).ToList();

            return employeeList;
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO item)
        {
            var employee = await _employeeRepository.GetById(item.Id);
            employee.Name = item.Name;
            employee.CompanyId = item.CompanyId;

            await _employeeRepository.Update(employee);

            return item;
        }
    }
}

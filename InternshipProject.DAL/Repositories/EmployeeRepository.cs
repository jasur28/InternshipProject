using InternshipProject.DAL.Data;
using InternshipProject.DAL.Entities;
using InternshipProject.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipProject.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository//Repository<Employee>, 
    {
        private readonly InternshipDbContext _internshipDbContext;
        public EmployeeRepository(InternshipDbContext internshipDbContext)
        {
            _internshipDbContext = internshipDbContext;
        }

        public async Task<Employee> Create(Employee item)
        {
            await _internshipDbContext.Employees.AddAsync(item);
            await _internshipDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(Employee item)
        {
            _internshipDbContext.Employees.Remove(item);
            try
            {
                _internshipDbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _internshipDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _internshipDbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> Update(Employee item)
        {
            _internshipDbContext.Employees.Update(item);
            await _internshipDbContext.SaveChangesAsync();
            return item;
        }
    }
}

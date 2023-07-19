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
    public class CompanyRepository : ICompanyRepository// : Repository<Company>, 
    {
        private readonly InternshipDbContext _internshipDbContext;
        public CompanyRepository(InternshipDbContext internshipDbContext) 
        {
            _internshipDbContext = internshipDbContext;
        }

        public async Task<Company> Create(Company item)
        {
            await _internshipDbContext.Companies.AddAsync(item);
            await _internshipDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(Company item)
        {
            _internshipDbContext.Companies.Remove(item);
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

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _internshipDbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _internshipDbContext.Companies.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company> Update(Company item)
        {
            _internshipDbContext.Companies.Update(item);
            await _internshipDbContext.SaveChangesAsync();
            return item;
        }
    }
}

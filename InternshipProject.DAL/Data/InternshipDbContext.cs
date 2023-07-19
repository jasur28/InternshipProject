using InternshipProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipProject.DAL.Data
{
    public class InternshipDbContext : DbContext
    {
        
        public InternshipDbContext(DbContextOptions<InternshipDbContext> options) : base(options)
        {

        }

        public DbSet<Company>  Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

     
    }
}

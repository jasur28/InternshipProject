using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Interfaces
{
    public interface ICompanyRepository //: IRepository<Company>{}
    {
        public Task<Company> Create(Company item);
        public Task<bool> Delete(Company item);
        public Task<Company> Update(Company item);
        public Task<IEnumerable<Company>> GetAll();
        public Task<Company> GetById(int id);

    }
}

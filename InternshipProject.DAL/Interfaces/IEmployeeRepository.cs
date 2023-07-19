using InternshipProject.DAL.Entities;

namespace InternshipProject.DAL.Interfaces
{
    public interface IEmployeeRepository //: IRepository<Employee>{}
    {
        public Task<Employee> Create(Employee item);
        public Task<bool> Delete(Employee item);
        public Task<Employee> Update(Employee item);
        public Task<IEnumerable<Employee>> GetAll();
        public Task<Employee> GetById(int id);
    }
}

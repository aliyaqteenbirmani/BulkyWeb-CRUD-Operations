using BulkyWeb.Models;

namespace BulkyWeb.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task Add(Employee entity);
        Task Update(Employee entity);
        Task Delete(Employee entity);
        Task Delete(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);

    }
}

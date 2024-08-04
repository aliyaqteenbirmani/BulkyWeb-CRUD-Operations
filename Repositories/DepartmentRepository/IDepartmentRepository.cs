using BulkyWeb.Models;

namespace BulkyWeb.Repositories.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        Task Add(Departments dpt);
        Task Update(int id,Departments dpt);
        Task Delete(Departments dpt);
        Task Delete(int id);
        Task<IEnumerable<Departments>> GetAll();
        Task<Departments> GetById(int id);
    }
}

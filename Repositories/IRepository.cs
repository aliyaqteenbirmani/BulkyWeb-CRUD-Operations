using BulkyWeb.Models;

namespace BulkyWeb.Repositories
{
    public interface IRepository<TEntity>
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(int id);
        Task <IEnumerable<TEntity>> GetAll();
        Task <TEntity> GetById(int id);
    }
}

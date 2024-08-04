using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _dbContext;
        public EmployeeRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task Add(Employee entity)
        {
            await _dbContext.Employees.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Employee entity)
        {

            _dbContext.Entry<Employee>(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Entry<Employee>(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task Update(Employee entity)
        {
            _dbContext.Employees.Update(entity);

            await _dbContext.SaveChangesAsync();
        }

    }
}

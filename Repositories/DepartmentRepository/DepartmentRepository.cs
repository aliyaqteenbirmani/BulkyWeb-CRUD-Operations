using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Repositories.DepartmentRepository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext _dbContext;

        public DepartmentRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task Add(Departments dpt)
        {
            await _dbContext.Departments.AddAsync(dpt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Departments dpt)
        {
             _dbContext.Entry<Departments>(dpt).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var department = await GetById(id);
            _dbContext.Entry<Departments>(department).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Departments>> GetAll()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<Departments> GetById(int id)
        {
            return  _dbContext.Departments.Find(id);
            
        }

        public async Task Update(int id, Departments dpt)
        {

            var department = await GetById(dpt.Id);
         
            department.Name = dpt.Name;
            department.Location = dpt.Location;
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}

using BulkyWeb.Models;
using BulkyWeb.Repositories.DepartmentRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpPost]
        [Route("add",Name ="add department")]
        public async Task AddDepartment(Departments departments)
        {
            await _departmentRepository.Add(departments);
        }

        [HttpGet]
        [Route("all",Name ="GetallDepartments")]
        public async Task<IEnumerable<Departments>> GetAll()
        {
            var departments = await _departmentRepository.GetAll();
            return departments;
        }

        [HttpGet]
        [Route("{id}", Name = "getdepartmentbyid")]
        public async Task<Departments> GetById(int id)
        {
            var department = await _departmentRepository.GetById(id);
            return department;
        }

        [HttpDelete]
        [Route("{id}/del",Name="deletebyid")]
        public async Task DeleteById(int id)
        {
            await _departmentRepository.Delete(id);
        }

        [HttpPatch]
        [Route("{id}/update",Name = "UpateRecord")]
        public async Task Update(int id,Departments department)
        {
            await _departmentRepository.Update(id, department);
        }
    }
}

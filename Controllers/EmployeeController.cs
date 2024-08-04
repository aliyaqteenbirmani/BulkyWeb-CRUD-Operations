using BulkyWeb.Models;
using BulkyWeb.Repositories;
using BulkyWeb.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IRepository<Employee> repository, IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("all", Name = "GetAllEmployee")]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            return employees;
        }

        [HttpGet]
        [Route("{id}",Name ="GetSpecificEmployee")]
        public async Task<Employee> GetById(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            return employee;
        }

        [HttpPost]
        [Route("add",Name ="AddEmployee")]
        public async Task Add(Employee emp)
        {
            await _employeeRepository.Add(emp);
            
        }

        [HttpDelete]
        [Route("{id}/delete", Name = "DeleteEmployee")]
        public async Task Delete(int id)
        {
            await _employeeRepository.Delete(id);

        }
    }
}

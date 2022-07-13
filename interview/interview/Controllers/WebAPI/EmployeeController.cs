using interview.Data;
using interview.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace interview.Controllers.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeesRepository _employeeRepository;

        public EmployeeController(IEmployeesRepository employeesRepository)
        {
            this._employeeRepository = employeesRepository;
        }

        // GET api/Employee/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var employee = this._employeeRepository.getById(id);
            return JsonConvert.SerializeObject(employee);
        }

        // POST api/Employee
        [HttpPost]
        public bool Post(Employee employee)
        {
            return this._employeeRepository.create(employee);
        }

        // PUT api/Employee/{id}
        [HttpPut("{id}")]
        public bool Put(int id,Employee employee)
        {
            return this._employeeRepository.update(id,employee);
        }

        // DELETE api/Employee/{id}
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this._employeeRepository.deleteById(id);
        }
    }
}

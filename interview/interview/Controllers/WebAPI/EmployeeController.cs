using interview.Data;
using interview.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace interview.Controllers.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeesRepository _employeeRepository;

        public EmployeeController(IEmployeesRepository employeesRepository, IConfiguration configuration)
        {
            this._employeeRepository = employeesRepository;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        // GET api/Employee/Get/{id}
        [HttpGet("Get/{id}")]
        public string Get(int id)
        {
            var employee = this._employeeRepository.getById(id);
            return JsonConvert.SerializeObject(employee);
        }

        [HttpGet("GetList")]
        public List<Employee> getList()
        {
            return this._employeeRepository.get();
        }

        // POST api/Employee
        [HttpPost]
        public bool CreateEmployee(Employee employee)
        {
            return this._employeeRepository.create(employee);
        }

        // PUT api/Employee/{id}
        [HttpPut("{id}")]
        public bool UpdateEmployee(int id,Employee employee)
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

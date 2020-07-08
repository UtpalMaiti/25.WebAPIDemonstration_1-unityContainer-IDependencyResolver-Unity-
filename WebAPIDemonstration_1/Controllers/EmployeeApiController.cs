using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemonstration_1.Contracts;
using WebAPIDemonstration_1.Models;

namespace WebAPIDemonstration_1.Controllers
{
    public class EmployeeApiController : ApiController
    {
        readonly IEmployeeRepository repo;

        public EmployeeApiController(IEmployeeRepository r)
        {
            repo = r;
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return repo.GetAllEmployees();
        }

        [HttpGet]
        public Employee GetById(int id)
        {

            return repo.GetEmployeeById(id);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return repo.DeleteEmployee(id);
        }

        [HttpPost]
        public bool Post(Employee emp)
        {
            return repo.CreateEmployee(emp);
        }

        [HttpPut]
        public bool Put(Employee emp)
        {
            return repo.UpdateEmployee(emp);
        }
    }
}

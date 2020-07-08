using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemonstration_1.Models;

namespace WebAPIDemonstration_1.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployeeById(int Id);

        bool DeleteEmployee(int Id);

        bool CreateEmployee(Employee emp);

        bool UpdateEmployee(Employee emp);
    }
}

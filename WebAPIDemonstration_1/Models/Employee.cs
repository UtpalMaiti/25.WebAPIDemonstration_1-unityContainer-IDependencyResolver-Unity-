using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemonstration_1.Models
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public long Salary { get; set; }

        public long DeptId { get; set; }
    }
}
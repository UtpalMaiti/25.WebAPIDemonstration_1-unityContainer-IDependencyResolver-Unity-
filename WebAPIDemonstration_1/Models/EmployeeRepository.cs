using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebAPIDemonstration_1.Contracts;

namespace WebAPIDemonstration_1.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "select * from EmpInfo";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<Employee> empList = new List<Employee>();
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Employee emp = new Employee
                {
                    Id= Convert.ToInt64(dr[0]),
                    Name=dr[1].ToString(),
                    Location=dr[2].ToString(),
                    Salary= Convert.ToInt64(dr[3]),
                    DeptId= Convert.ToInt64(dr[4])
                };

                Debug.WriteLine(dr[0]);
                Debug.WriteLine(dr[1]);
                Debug.WriteLine(dr[2]);
                Debug.WriteLine(dr[3]);
                Debug.WriteLine(dr[4]);
                empList.Add(emp);
            }

            conn.Close();
            return empList;
        }

        public Employee GetEmployeeById(int Id)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "select * from EmpInfo where Id="+Id;
            SqlCommand cmd = new SqlCommand(query, conn);
            Employee emp=null;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                emp = new Employee
                {
                    Id =  Convert.ToInt64( dr[0]),
                    Name = dr[1].ToString(),
                    Location = dr[2].ToString(),
                    Salary = Convert.ToInt64(dr[3]),
                    DeptId = Convert.ToInt64(dr[4])
                };
                
            }

            conn.Close();
            return emp;
        }

        public bool DeleteEmployee(int Id)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "delete from EmpInfo where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected>0?true:false;
        }

        public bool CreateEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "insert into EmpInfo values(@Id,@Name,@Loc,@Sal,@deptId)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@Loc", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@Sal", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@deptId", emp.DeptId));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;
        }

        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection(@"server=.\SQLEXPRESS;database=EmployeeDB;integrated security=true");
            string query = "update EmpInfo set Name=@Name,Location=@Loc,Salary=@Sal,DeptId=@deptId where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@Loc", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@Sal", emp.Salary));
            cmd.Parameters.Add(new SqlParameter("@deptId", emp.DeptId));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;
        }
    }
}
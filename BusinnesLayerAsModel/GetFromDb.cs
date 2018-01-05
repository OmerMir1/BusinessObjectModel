using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayerAsModel
{
    public class GetFromDb
    {
        public IEnumerable<Employee> employees
        {
            get
            {
                string CS = ConfigurationManager.ConnectionStrings["BusinessObjectModel"].ConnectionString;

                List<Employee> employee = new List<Employee>();


                SqlConnection con = new SqlConnection(CS);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from EmployeeDetails", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeID = (int)rdr["EmployeeID"];
                    emp.EmployeeName = rdr["EmployeeName"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.City = rdr["City"].ToString();


                    employee.Add(emp);
                }
                return employee;
            }

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                    emp.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    emp.EmployeeName = rdr["EmployeeName"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.City = rdr["City"].ToString();


                    employee.Add(emp);
                }
                return employee;
            }

            
        }



        public void RecieveDataAndAddToDB(Employee emp)
        {
            string CS = ConfigurationManager.ConnectionStrings["BusinessObjectModel"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@EmployeeName";
                paramName.Value = emp.EmployeeName;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = emp.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = emp.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = emp.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

      public static void RecvAndUpdateToDB(Employee emp)
        {
            string CS = ConfigurationManager.ConnectionStrings["BusinessObjectModel"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@EmployeeID";
                paramID.Value = emp.EmployeeID;
                cmd.Parameters.Add(paramID);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@EmployeeName";
                paramName.Value = emp.EmployeeName;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = emp.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = emp.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = emp.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using CrudAdoExample.Models;
using System.Data;
using System.Data.SqlClient;

namespace CrudAdoExample.DAL
{
    public class EmployeeDAL
    {
        string cs=ConnectionString.dbcs;
        public  List<Employees> getAllEmployees()
        {
            List<Employees> emp=new List<Employees>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee",conn);
                cmd.CommandType=CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                { 
                    Employees employee = new Employees();
                    employee.Id = Convert.ToInt32(sqlDataReader["ID"]);
                    employee.Name = sqlDataReader["Name"].ToString() ?? "";
                    employee.Gender = sqlDataReader["Gender"].ToString() ?? "";
                    employee.Designation = sqlDataReader["Designation"].ToString() ?? "";
                    employee.Age = Convert.ToInt32(sqlDataReader["Age"]);
                    employee.Is_Active = Convert.ToBoolean( sqlDataReader["Is_Active"]);
                    emp.Add(employee);
                }
            }

            return emp;
        }

        public void AddEmployee(Employees employee)
        {
            using(SqlConnection conn = new SqlConnection(cs)) 
            {
                SqlCommand cmd = new SqlCommand("spCreateEmployee",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name",employee.Name);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@designation", employee.Designation);
                cmd.Parameters.AddWithValue("@is_active", employee.Is_Active);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public Employees GetEmployeeById(int id)
        {
            Employees employee = new Employees();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from employees where id=@id",conn);
                cmd.CommandType= CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open ();

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while(sqlDataReader.Read())
                {
                    employee.Id = Convert.ToInt32(sqlDataReader["ID"]);
                    employee.Name = sqlDataReader["Name"].ToString() ?? "";
                    employee.Gender = sqlDataReader["Gender"].ToString() ?? "";
                    employee.Designation = sqlDataReader["Designation"].ToString() ?? "";
                    employee.Age = Convert.ToInt32(sqlDataReader["Age"]);
                    employee.Is_Active = Convert.ToBoolean(sqlDataReader["Is_Active"]);
                }
            }

            return employee;
        }

        public void UpdateEmployee(Employees employee)
        {
            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",employee.Id);
                cmd.Parameters.AddWithValue("@name", employee.Name);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.Parameters.AddWithValue("@gender", employee.Gender);
                cmd.Parameters.AddWithValue("@designation", employee.Designation);
                cmd.Parameters.AddWithValue("@is_active", employee.Is_Active);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            

            using(SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee",connection);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", employeeId);
                connection.Open();
                cmd.ExecuteNonQuery();
                 
            }
        }
    }
}

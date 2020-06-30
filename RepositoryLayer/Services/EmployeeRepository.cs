using CommanLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;


namespace RepositoryLayer
{
    public class EmployeeRepository : IEmployeeRL
    {

        SqlConnection connection;

        public EmployeeRepository()
        {
            var configuration = GetConfiguration();
            connection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }


        /// <summary>
        ///  database connection for get all employee details
        /// </summary>
        public IEnumerable<Employees> GetAllemployee()
        {
            try
            {
                List<Employees> employeeList = new List<Employees>();
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("sp_AllEmployees", connection);
                connection.Open();
                //Read data from database
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                {
                    Employees employee = new Employees();
                    employee.Id = Convert.ToInt32(Response["Id"]);
                    employee.FirstName = Response["FirstName"].ToString();
                    employee.LastName = Response["LastName"].ToString();
                    employee.Email = Response["Email"].ToString();
                    employee.ContactNumber = Response["ContactNumber"].ToString();
                    employee.City = Response["City"].ToString();
                    employee.Salary = Response["Salary"].ToString();
                    employeeList.Add(employee);
                }
                connection.Close();
                return employeeList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employees GetSpecificEmployeeDetails(int Id)
        {
            try
            {
                Employees employee = new Employees();
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("sp_FindSpecificEmployeeDetails", connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                connection.Open();
                //Read data from database
                SqlDataReader Response = command.ExecuteReader();
                while (Response.Read())
                {
                    employee.Id = Convert.ToInt32(Response["ID"]);
                    employee.FirstName = Response["FirstName"].ToString();
                    employee.LastName = Response["LastName"].ToString();
                    employee.Email = Response["Email"].ToString();
                    employee.ContactNumber = Response["ContactNumber"].ToString();
                    employee.City = Response["City"].ToString();
                    employee.Salary = Response["Salary"].ToString();                }
                connection.Close();
                return employee;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AddEmployeeDetails(Employees info)
        {
            try
            {            
                //for store procedure and connection to database
                SqlCommand command = StoreProcedureConnection("sp_AddNewEmployee", connection);
                command.Parameters.AddWithValue("@FirstName", info.FirstName);
                command.Parameters.AddWithValue("@LastName", info.LastName);
                command.Parameters.AddWithValue("@Email", info.Email);
                command.Parameters.AddWithValue("@ContactNumber", info.ContactNumber);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Salary", info.Salary);
                command.Parameters.AddWithValue("@JoiningDate", DateTime.Now);
                connection.Open();
                int Response = await command.ExecuteNonQueryAsync();
                connection.Close();
                if (Response != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int UpdateEmployeeDetails(int Id, Employees info)
        {
            try
            {
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("sp_UpdateEmployeeDetails", connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                command.Parameters.AddWithValue("@FirstName", info.FirstName);
                command.Parameters.AddWithValue("@LastName", info.LastName);
                command.Parameters.AddWithValue("@Email", info.Email);
                command.Parameters.AddWithValue("@ContactNumber", info.ContactNumber);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Salary", info.Salary);
                command.Parameters.AddWithValue("@JoiningDate", DateTime.Now);
                connection.Open();
                int Response = command.ExecuteNonQuery();
                connection.Close();
                if (Response == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteEmployeeDetails(int Id)
        {
            try
            {
                //for store procedure and connection to database 
                SqlCommand command = StoreProcedureConnection("sp_DeleteSpecificEmployeeDetails", connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;               
                connection.Open();
                int Response = command.ExecuteNonQuery();
                connection.Close();
                if (Response == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);
            return builder.Build();
        }         
     
        public SqlCommand StoreProcedureConnection(string Procedurename, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Procedurename, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
        }
       
    }
}

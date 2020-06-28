using CommanLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class EmployeeRepository : IEmployeeRL
    {
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configure)
        {
            configuration = configure;
        }
       
        public async Task<bool> EmployeeRegister(Employees info)
        {
            try
            {
                SqlConnection connection = DatabaseConnection();

                //for store procedure and connection to database
                SqlCommand command = StoreProcedureConnection("sp_EmployeeRegister", connection);
                command.Parameters.AddWithValue("@FirstName", info.FirstName);
                command.Parameters.AddWithValue("@LastName", info.LastName);
                command.Parameters.AddWithValue("@ContactNumber", info.ContactNumber);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Salary", info.Salary);
                command.Parameters.AddWithValue("@JoiningDate", info.JoiningDate);
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

        /// <summary>
        ///  database connection for get all employee details
        /// </summary>
        public IEnumerable<Employees> GetAllemployee()
        {
            try
            {
                List<Employees> employeeList = new List<Employees>();
                SqlConnection connection = DatabaseConnection();
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
                    employee.ContactNumber = Response["ContactNumber"].ToString();
                    employee.City = Response["City"].ToString();
                    employee.Salary = Response["Salary"].ToString();
                    employee.JoiningDate = Response["JoiningDate"].ToString();
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

        private SqlConnection DatabaseConnection()
        {
            string connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeData").Value;
            return new SqlConnection(connectionString);
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

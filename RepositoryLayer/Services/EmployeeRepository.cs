using CommanLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class EmployeeRepository : IEmployeeRL
    {
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configur)
        {
            configuration = configur;
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

using CommanLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class UserRepository : IUserRL
    {
        SqlConnection connection;

        public UserRepository()
        {
            var configuration = GetConfiguration();
            connection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        public async Task<bool> UserRegister(UserDetails info)
        {
            try
            {
                //for store procedure and connection to database
                SqlCommand command = StoreProcedureConnection("sp_UserRegistration", connection);
                command.Parameters.AddWithValue("@EmployeeName", info.EmployeeName);
                command.Parameters.AddWithValue("@UserName", info.Username);
                command.Parameters.AddWithValue("@Password", info.Password);
                command.Parameters.AddWithValue("@Gender", info.Gender);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Email", info.Email);
                command.Parameters.AddWithValue("@Designation", info.Designation);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
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

        public async Task<bool> UserLogin(UserDetails info)
        {
            try
            {
                //for store procedure and connection to database
                SqlCommand command = StoreProcedureConnection("sp_UserRegistration", connection);
                command.Parameters.AddWithValue("@UserName", info.Username);
                command.Parameters.AddWithValue("@Password", info.Password);
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

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
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

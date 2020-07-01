//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace RepositoryLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Threading.Tasks;
    using CommanLayer;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Interface;
    
    /// <summary>
    /// class for User Repository
    /// </summary>
    public class UserRepository : IUserRL
    {
        /// <summary>
        /// declaration for database connection
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        public UserRepository()
        {
            var configuration = this.GetConfiguration();
            this.connection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        /// <summary>
        /// Method for registering new Users
        /// </summary>
        /// <param name="info">new data form user</param>
        /// <returns>added record to the database</returns>
        public async Task<bool> UserRegister(UserDetails info)
        {
            try
            {
                // for store procedure and connection to database
                SqlCommand command = this.StoreProcedureConnection("sp_UserRegistration", this.connection);
                command.Parameters.AddWithValue("@EmployeeName", info.EmployeeName);
                command.Parameters.AddWithValue("@UserName", info.Username);
                command.Parameters.AddWithValue("@Password", info.Password);
                command.Parameters.AddWithValue("@Gender", info.Gender);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Email", info.Email);
                command.Parameters.AddWithValue("@Designation", info.Designation);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                this.connection.Open();
                int response = await command.ExecuteNonQueryAsync();
                this.connection.Close();
                if (response != 0)
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
        /// Method for Login User
        /// </summary>
        /// <param name="info">username and password from user</param>
        /// <returns>check if User is Present return result</returns>
        public async Task<int> UserLogin(Login info)
        {
            try
            {
                SqlCommand command = this.StoreProcedureConnection("sp_CheckUsernameAndPassword", this.connection);

                // for store procedure and connection to databat               
                command.Parameters.AddWithValue("@Username", info.Username);
                command.Parameters.AddWithValue("@Password", info.Password);
                string returnedQueryValue = null;
                this.connection.Open();
                using (SqlDataReader sqlReturnData = command.ExecuteReader())
                {
                    while (sqlReturnData.Read())
                    {
                        returnedQueryValue = sqlReturnData[0].ToString();
                    }
                }

                this.connection.Close();
                if (returnedQueryValue == "1")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// configuration with database
        /// </summary>
        /// <returns>return builder</returns>
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        /// <summary>
        /// Method for store procedure and connection
        /// </summary>
        /// <param name="procedurename">for store procedure</param>
        /// <param name="connection">for connection</param>
        /// <returns>returns store procedure result</returns>
        public SqlCommand StoreProcedureConnection(string procedurename, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(procedurename, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
        }
    }
}

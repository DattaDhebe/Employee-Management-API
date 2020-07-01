//-----------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace RepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Threading.Tasks;
    using CommanLayer;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Interface;
   
    /// <summary>
    /// class for Employee Repository
    /// </summary>
    public class EmployeeRepository : IEmployeeRL
    {
        /// <summary>
        /// declaration for database connection
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository" /> class.
        /// </summary>
        public EmployeeRepository()
        {
            var configuration = this.GetConfiguration();
            this.connection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        /// <summary>
        /// Method for returning All Employee Details
        /// </summary>
        /// <returns>return all employee details</returns>
        public IEnumerable<Employees> GetAllemployee()
        {
            try
            {
                List<Employees> employeeList = new List<Employees>();

                // for store procedure and connection to database 
                SqlCommand command = this.StoreProcedureConnection("sp_AllEmployees", this.connection);
                this.connection.Open();

                // Read data from database
                SqlDataReader response = command.ExecuteReader();
                while (response.Read())
                {
                    Employees employee = new Employees();
                    employee.id = Convert.ToInt32(response["Id"]);
                    employee.FirstName = response["FirstName"].ToString();
                    employee.LastName = response["LastName"].ToString();
                    employee.Email = response["Email"].ToString();
                    employee.ContactNumber = response["ContactNumber"].ToString();
                    employee.City = response["City"].ToString();
                    employee.Salary = response["Salary"].ToString();
                    employeeList.Add(employee);
                }

                this.connection.Close();
                return employeeList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for returning specific Employee Details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return specific employee details</returns>
        public Employees GetSpecificEmployeeDetails(int id)
        {
            try
            {
                Employees employee = new Employees();

                // for store procedure and connection to database 
                SqlCommand command = this.StoreProcedureConnection("sp_FindSpecificEmployeeDetails", this.connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                this.connection.Open();

                // Read data from database
                SqlDataReader response = command.ExecuteReader();
                while (response.Read())
                {
                    employee.id = Convert.ToInt32(response["ID"]);
                    employee.FirstName = response["FirstName"].ToString();
                    employee.LastName = response["LastName"].ToString();
                    employee.Email = response["Email"].ToString();
                    employee.ContactNumber = response["ContactNumber"].ToString();
                    employee.City = response["City"].ToString();
                    employee.Salary = response["Salary"].ToString();
                }

                this.connection.Close();
                return employee;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  Method for adding new Employee
        /// </summary>
        /// <param name="info"> stores the Complete Employee information</param>
        /// <returns>return extra employee details</returns>   
        public async Task<bool> AddEmployeeDetails(Employees info)
        {
            try
            {            
                // for store procedure and connection to database
                SqlCommand command = this.StoreProcedureConnection("sp_AddNewEmployee", this.connection);
                command.Parameters.AddWithValue("@FirstName", info.FirstName);
                command.Parameters.AddWithValue("@LastName", info.LastName);
                command.Parameters.AddWithValue("@Email", info.Email);
                command.Parameters.AddWithValue("@ContactNumber", info.ContactNumber);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Salary", info.Salary);
                command.Parameters.AddWithValue("@JoiningDate", DateTime.Now);
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
        /// Method for updating previous employee details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <param name="info">for getting updatable details</param>
        /// <returns>returns updated details</returns>
        public int UpdateEmployeeDetails(int id, Employees info)
        {
            try
            {
                // for store procedure and connection to database 
                SqlCommand command = this.StoreProcedureConnection("sp_UpdateEmployeeDetails", this.connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.Parameters.AddWithValue("@FirstName", info.FirstName);
                command.Parameters.AddWithValue("@LastName", info.LastName);
                command.Parameters.AddWithValue("@Email", info.Email);
                command.Parameters.AddWithValue("@ContactNumber", info.ContactNumber);
                command.Parameters.AddWithValue("@City", info.City);
                command.Parameters.AddWithValue("@Salary", info.Salary);
                command.Parameters.AddWithValue("@JoiningDate", DateTime.Now);
                this.connection.Open();
                int response = command.ExecuteNonQuery();
                this.connection.Close();
                if (response == 0)
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

        /// <summary>
        /// Method for Deleting specific Employee Details 
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return deleted record</returns>
        public int DeleteEmployeeDetails(int id)
        {
            try
            {
                // for store procedure and connection to database 
                SqlCommand command = this.StoreProcedureConnection("sp_DeleteSpecificEmployeeDetails", this.connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;               
                this.connection.Open();
                int response = command.ExecuteNonQuery();
                this.connection.Close();
                if (response == 0)
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

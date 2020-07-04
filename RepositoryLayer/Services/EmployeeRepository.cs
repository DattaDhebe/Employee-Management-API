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
        public IEnumerable<Employees> GetAllEmployees()
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
                    employee.Id = Convert.ToInt32(response["Id"]);
                    employee.FirstName = response["FirstName"].ToString();
                    employee.LastName = response["LastName"].ToString();
                    employee.Email = response["Email"].ToString();
                    employee.ContactNumber = response["ContactNumber"].ToString();
                    employee.City = response["City"].ToString();
                    employee.Salary = response["Salary"].ToString();
                    employee.CreatedDate = response["CreatedDate"].ToString();
                    employee.ModifiedDate = response["ModifiedDate"].ToString();
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
        public Employees GetEmployeeById(int id)
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
                    employee.Id = Convert.ToInt32(response["Id"]);
                    employee.FirstName = response["FirstName"].ToString();
                    employee.LastName = response["LastName"].ToString();
                    employee.Email = response["Email"].ToString();
                    employee.ContactNumber = response["ContactNumber"].ToString();
                    employee.City = response["City"].ToString();
                    employee.Salary = response["Salary"].ToString();
                    employee.CreatedDate = response["CreatedDate"].ToString();
                    employee.ModifiedDate = response["ModifiedDate"].ToString();
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
        public Employees AddEmployeeDetails(Employees info)
        {
            try
            {
                Employees employee = new Employees();

                // for store procedure and connection to database
                SqlCommand command = this.StoreProcedureConnection("sp_AddNewEmployee", this.connection);
                return this.LoadDataToStoreProcedure(info, command);
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
        public Employees UpdateEmployeeDetails(int id, Employees info)
        {
            try
            {
                Employees employee = new Employees();

                // for store procedure and connection to database 
                SqlCommand command = this.StoreProcedureConnection("sp_UpdateEmployeeDetails", this.connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                return this.LoadDataToStoreProcedure(info, command);
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
        public int DeleteEmployeeById(int id)
        {
            try
            {
                // for store procedure and connection to database 
                SqlCommand command = this.StoreProcedureConnection("sp_DeleteSpecificEmployeeDetails", this.connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;               
                this.connection.Open();
                int response = command.ExecuteNonQuery();
                this.connection.Close();
                if (response != 0)
                {
                    return 1;
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to load data to store procedure
        /// </summary>
        /// <param name="info">object of Employee class</param>
        /// <param name="command">connection with database to add and perform</param>
        /// <returns>returns loaded data in response</returns>
        private Employees LoadDataToStoreProcedure(Employees info, SqlCommand command)
        {
            command.Parameters.AddWithValue("@FirstName", info.FirstName);
            command.Parameters.AddWithValue("@LastName", info.LastName);
            command.Parameters.AddWithValue("@Email", info.Email);
            command.Parameters.AddWithValue("@ContactNumber", info.ContactNumber);
            command.Parameters.AddWithValue("@City", info.City);
            command.Parameters.AddWithValue("@Salary", info.Salary);
            command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            this.connection.Open();
            SqlDataReader response = command.ExecuteReader();
            return this.ResponseEmployeeData(info, response);
        }

        /// <summary>
        /// Method to provide response with Employee Details
        /// </summary>
        /// <param name="employee">employee object</param>
        /// <param name="response">contains data from store procedure</param>
        /// <returns>return object with data</returns>
        private Employees ResponseEmployeeData(Employees employee, SqlDataReader response)
        {
            if (response.HasRows)
            {
                while (response.Read())
                {
                    employee.Id = Convert.ToInt32(response["Id"]);
                    employee.FirstName = response["FirstName"].ToString();
                    employee.LastName = response["LastName"].ToString();
                    employee.Email = response["Email"].ToString();
                    employee.ContactNumber = response["ContactNumber"].ToString();
                    employee.City = response["City"].ToString();
                    employee.Salary = response["Salary"].ToString();
                    employee.CreatedDate = response["CreatedDate"].ToString();
                    employee.ModifiedDate = response["ModifiedDate"].ToString();
                }

                this.connection.Close();
                return employee;
            }

            return null;
        }

        /// <summary>
        /// configuration with database
        /// </summary>
        /// <returns>return builder</returns>
        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }         
     
        /// <summary>
        /// Method for store procedure and connection
        /// </summary>
        /// <param name="procedureName">for store procedure</param>
        /// <param name="connection">for connection</param>
        /// <returns>returns store procedure result</returns>
        private SqlCommand StoreProcedureConnection(string procedureName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
        }     
    }
}

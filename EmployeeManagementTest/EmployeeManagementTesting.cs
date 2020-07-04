//-----------------------------------------------------------------------
// <copyright file="EmployeeManagementTesting.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace EmployeeManagementTest
{
    using System;
    using BusinessLayer;
    using BusinessLayer.Interface;
    using CommanLayer;
    using EmployeeRegistration.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using RepositoryLayer;
    using RepositoryLayer.Interface;
    using Xunit;

    /// <summary>
    /// Test class for Employee management 
    /// </summary>
    public class EmployeeManagementTesting
    {
        /// <summary>
        /// object of EmployeeController to access method
        /// </summary>
        private EmployeeController employeeController;

        /// <summary>
        /// interface if EmployeeBusiness layer
        /// </summary>
        private IEmployeeBL employeeBL;

        /// <summary>
        /// interface if EmployeeRepository layer
        /// </summary>
        private IEmployeeRL employeeRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManagementTesting" /> class.
        /// </summary>
        public EmployeeManagementTesting()
        {
            this.employeeRL = new EmployeeRepository();
            this.employeeBL = new EmployeeBusiness(this.employeeRL);
            this.employeeController = new EmployeeController(this.employeeBL);
        }

        /// <summary>
        /// Method for retrieving all employee details when get method used should return ok result 
        /// </summary>
        [Fact]
        public void GetMethod__WhenCalledGetAllEMployees_ShouldReturnOkResult()
        {
            try
            {
                // Act
                var data = this.employeeController.GetAllEmployees();

                // Assert
                Assert.IsType<OkObjectResult>(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for retrieving specific employee details when check by id should return ok result 
        /// </summary>
        [Fact]
        public void GetMethod_WhenCalledEmployeeById_ShouldReturnOkResult()
        {
            try
            {
                var id = 1009;

                // Act
                var data = this.employeeController.GetEmployeeById(id);

                // Assert
                Assert.IsType<OkObjectResult>(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for deletion of employee by id when deleted should return ok result  
        /// </summary>
        [Fact]
        public void Task_deletedataById_Return_OkResult()
        { 
            var id = 1008;

            // Act  
            var data = this.employeeController.DeleteEmployeeById(id);

            // Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// Method for insertion of record when added should return ok result 
        /// </summary>
        [Fact]
        public void Task_WhenAddEmployeeMethodCalledAndAddedDetails_ShouldReturnOkResult()
        {
            // Arrange  
            var testdata = new Employees
                                        {
                                            FirstName = "Lalit",
                                            LastName = "Talole",
                                            Email = "lalittalole@gmail.com",
                                            ContactNumber = "8149277030",
                                            City = "Nagpur",
                                            Salary = "23000"
                                        };

            // Act  
            var data = this.employeeController.AddEmployeeDetails(testdata);

            // Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// Method for insertion of record when added should return bad request
        /// </summary>
        [Fact]
        public void Task_IfInsertedDataIsPresent_ReturnOkResult()
        {
            // Arrange  
            var testdata = new Employees
                                        { 
                                            FirstName = "Lalit", 
                                            LastName = "Talole", 
                                            Email = "lalittalole@gmail.com",
                                            ContactNumber = "8149277030",
                                            City = "Nagpur",
                                            Salary = "23000" 
                                        };

            // Act  
            var data = this.employeeController.AddEmployeeDetails(testdata);

            // Assert  
            Assert.IsType<BadRequestObjectResult>(data);
        }
    }
}

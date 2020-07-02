using BusinessLayer;
using BusinessLayer.Interface;
using CommanLayer;
using EmployeeRegistration.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using Xunit;

namespace EmployeeManagementTest
{
    public class EmployeeManagementTesting
    {
        /*readonly EmployeeController employeeController;
        IEmployeeBL employeeBL;
        IEmployeeRL employeeRL;
        IConfiguration configuration;

        public static string sqlconnectionstring = "Data Source=DATTA;Initial Catalog=EmployeeData;Integrated Security=True";

        public EmployeeManagementTesting(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.employeeBL = new EmployeeBusiness(employeeRL);
            this.employeeRL = new EmployeeRepository();
            this.employeeController = new EmployeeController(employeeBL, configuration);
        }

        [Fact]
        public void GetMethod_When_WhenCalledShouldReturnOkResult()
        {
            try
            {
                // arrange
                var okResult = employeeController.GetAllemployee();

                // Assert
                Assert.IsType<OkObjectResult>(okResult.Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/
    }
}

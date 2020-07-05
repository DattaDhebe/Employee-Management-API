//-----------------------------------------------------------------------
// <copyright file="UserManagementTesting.cs" company="BridgeLabz Solution">
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
    public class UserManagementTesting
    {
        /// <summary>
        /// object of EmployeeController to access method
        /// </summary>
        private UserController userController;

        /// <summary>
        /// interface if EmployeeBusiness layer
        /// </summary>
        private IUserBL userBL;

        /// <summary>
        /// interface if EmployeeRepository layer
        /// </summary>
        private IUserRL userRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="userManagementTesting" /> class.
        /// </summary>
        public UserManagementTesting()
        {
            this.userRL = new UserRepository();
            this.userBL = new UserBusiness(this.userRL);
            this.userController = new UserController(this.userBL);
        }

        /// <summary>
        /// Method for Register new User when added userDetails should return ok result 
        /// </summary>
        [Fact]
        public void Task_WhenAddNewUserMethodCalledAndAddedDetails_ShouldReturnOkResult()
        {
            // Arrange  
            var userData = new UserDetails
                                        {
                                            FirstName = "Lalit",
                                            LastName = "Talole",
                                            Email = "laxmi@gmail.com",
                                            Username = "laxmi",
                                            Password = "12345678",
                                            City = "Nagpur",
                                            Gender = "Male"
                                        };

            // Act  
            var data = this.userController.UserRegister(userData);

            // Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// Method for Register new User when added userDetails should return ok result 
        /// </summary>
        [Fact]
        public void Task_WhenGivenRightUsernameAndPassword_ShouldReturnOkResult()
        {
            // Arrange  
            var userData = new Login
                                    {
                                        Username = "Asam",
                                        Password = "1234567812"
            };

            // Act  
            var data = this.userController.UserLogin(userData);

            // Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        /// <summary>
        /// Method for Register new User when added userDetails should return ok result 
        /// </summary>
        [Fact]
        public void Task_WhenGivenWrongUsernameAndPassword_ShouldReturnBadRequestObjectResult()
        {
            // Arrange  
            var userData = new Login
                                    {
                                        Username = "wrong",
                                        Password = "wrongPassword"
                                    };

            // Act  
            var data = this.userController.UserLogin(userData);

            // Assert  
            Assert.IsType<BadRequestObjectResult>(data);
        }
    }
}

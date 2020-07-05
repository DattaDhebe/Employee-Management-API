//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace EmployeeRegistration.Controllers
{
    using System;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommanLayer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Controller Class for Employee
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// instance of user interface
        /// </summary>
        private IUserBL businessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="businessDependencyInjection">dependency injection</param>
        public UserController(IUserBL businessDependencyInjection)
        {
            this.businessLayer = businessDependencyInjection;
        }

        /// <summary>
        /// Method for registering new Users
        /// </summary>
        /// <param name="info">new data form user</param>
        /// <returns>added record to the database</returns>
        [HttpPost]
        [Route("register")]
        public IActionResult UserRegister([FromBody] UserDetails info)
        {
            try
            {
                var response = this.businessLayer.UserRegister(info);

                // if data is not equal to null then Registration sucessful
                if (!response.Equals(null))
                {
                    bool success = true;
                    var message = "You have Successfuly Registered";
                    return this.Ok(new { success, message, data = response });
                }
                else
                {
                    bool success = false;
                    var message = "You failed to Register";
                    return this.BadRequest(new { success, message, data = response });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        /// <summary>
        /// Method for Login User
        /// </summary>
        /// <param name="info">username and password from user</param>
        /// <returns>check if User is Present return result</returns>
        [HttpPost]
        [Route("login")]
        public ActionResult UserLogin([FromBody] Login info)
        {
            try
            {
                var response = this.businessLayer.UserLogin(info);

                // if data is not equal to null then Registration sucessful
                if (response != null)
                {
                    bool success = true;
                    var message = "You have Successfuly Logged In";
                    return this.Ok(new { success, message, data = response });
                }
                else
                {
                    bool success = false;
                    var message = "UserName Or Password is Wrong";
                    return this.BadRequest(new { success, message });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }
    }
}

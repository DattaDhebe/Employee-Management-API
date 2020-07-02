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
        /// for configuration
        /// </summary>
        private IConfiguration config;

        /// <summary>
        /// instance of user interface
        /// </summary>
        private IUserBL businessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="businessDependencyInjection">dependency injection</param>
        /// <param name="config">for configuration</param>
        public UserController(IUserBL businessDependencyInjection, IConfiguration config)
        {
            this.businessLayer = businessDependencyInjection;
            this.config = config;
        }

        /// <summary>
        /// Method for registering new Users
        /// </summary>
        /// <param name="info">new data form user</param>
        /// <returns>added record to the database</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserDetails info)
        {
            try
            {
                var response = await this.businessLayer.UserRegister(info);

                // if data is not equal to null then Registration sucessful
                if (!response.Equals(null))
                {
                    var status = true;
                    var message = "You have Successfuly Registered";
                    return this.Ok(new { status, message, data = info });
                }
                else
                {
                    var status = false;
                    var message = "You failed to Register";
                    return this.BadRequest(new { status, message, data = info });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { error = e.Message });
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
                if (!response.Equals(null))
                {
                    var status = true;
                    var message = "You have Successfuly Logged In";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    var status = false;
                    var message = "UserName Or Password is Wrong";
                    return this.BadRequest(new { status, message, data = response });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { error = e.Message });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmployeeRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        IUserBL BusinessLayer;

        public UserController(IUserBL BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
            _config = config;
        }

        /// <summary>
        ///  API for Adding new records
        /// </summary>
        /// <param name="Info"> stores the Complete Employee information</param>
        /// <returns></returns> 
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserDetails info)
        {
            try
            {
                bool data = await BusinessLayer.UserRegister(info);
                //if data is not equal to null then Registration sucessful
                if (!data.Equals(null))
                {
                    var status = "Success";
                    var Message = "Added Successfuly";
                    return this.Ok(new { status, Message, info });
                }
                else
                {
                    var status = "UnSuccess";
                    var Message = "Adding is Failed";
                    return this.BadRequest(new { status, Message, data = info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> UserLogin([FromBody] Login info)
        {
            try
            {
                int data = await BusinessLayer.UserLogin(info);
                //if data is not equal to null then Registration sucessful
                if (data != 0)
                {
                    var status = "Success";
                    var Message = "You have Successfuly Logged In";
                    return this.Ok(new { status, Message, info });
                }
                else
                {
                    var status = "Failed";
                    var Message = "UserName Or Password is Wrong";
                    return this.BadRequest(new { status, Message, data = info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}

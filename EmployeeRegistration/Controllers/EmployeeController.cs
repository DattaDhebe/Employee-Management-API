using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmployeeRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IConfiguration _config;
        IEmployeeBL BusinessLayer;

        public EmployeeController(IEmployeeBL BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
            _config = config;
        }

        /// <summary>
        ///  API for Registrion
        /// </summary>
        /// <param name="Info"> store the Complete Employee information</param>
        /// <returns></returns>       
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> EmployeeRegister([FromBody] Employees Info)
        {
            try
            {
                bool data = await BusinessLayer.EmployeeRegister(Info);
                //if data is not equal to null then Registration sucessful
                if (!data.Equals(null))
                {
                    var status = "Success";
                    var Message = "Registration is Successfull";
                    return this.Ok(new { status, Message, Info });
                }
                else                                
                {
                    var status = "UnSuccess";
                    var Message = "Registration is Failed";
                    return this.BadRequest(new { status, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        /// <summary>
        ///  API for get all emplyee details
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Employees>> GetAllemployee()
        {
            try
            {
                var result = BusinessLayer.GetAllemployee();
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Status = "Success";
                    var Message = "Employee Data found ";
                    return this.Ok(new { Status, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Status = "Unsuccess";
                    var Message = "Employee Data is not found";
                    return this.BadRequest(new { Status, Message, Data = result });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmpployeeManagement.Controllers
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
        [Route("register")]
        [HttpPost]
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
    }
}
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
                else                                         
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

        [HttpGet("{Id}")]
        public ActionResult GetSpecificEmployeeDetails([FromRoute] int Id)
        {
            try
            {
                var result = BusinessLayer.GetSpecificEmployeeDetails(Id);
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Status = "Success";
                    var Message = "Employee Data found ";
                    return this.Ok(new { Status, Message, Data = result });
                }
                else
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

        /// <summary>
        ///  API for Adding new records
        /// </summary>
        /// <param name="Info"> stores the Complete Employee information</param>
        /// <returns></returns>       
        [HttpPost]
        public async Task<IActionResult> EmployeeRegister([FromBody] Employees Info)
        {
            try
            {
                bool data = await BusinessLayer.AddEmployeeDetails(Info);
                //if data is not equal to null then Registration sucessful
                if (!data.Equals(null))
                {
                    var status = "Success";
                    var Message = "Added Successfuly";
                    return this.Ok(new { status, Message, Info });
                }
                else
                {
                    var status = "UnSuccess";
                    var Message = "Adding is Failed";
                    return this.BadRequest(new { status, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateEmployeeDetails([FromRoute] int Id, [FromBody] Employees Info)
        {
            try
            {
                var response = BusinessLayer.UpdateEmployeeDetails(Id, Info);
                if (!response.Equals(null))
                {
                    var Status = "Success";
                    var Message = "Employee Data Updated Sucessfully";
                    return this.Ok(new { Status, Message, data = Info });
                }
                else
                {
                    var status = "Unsuccess";
                    var Message = "Employee Data not Updated";
                    return this.BadRequest(new { status, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteEmployeeDetails([FromRoute] int Id)
        {
            try
            {
                var response = BusinessLayer.DeleteEmployeeDetails(Id);
                if (!response.Equals(null))
                {
                    var Status = "Success";
                    var Message = "Employee Data Sucessfully Deleted";
                    return this.Ok(new { Status, Message });
                }
                else
                {
                    var status = "Unsuccess";
                    var Message = "Employee Data Not Deleted";
                    return this.BadRequest(new { status, Message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
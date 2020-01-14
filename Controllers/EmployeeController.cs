using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeBL EmployeeBusinessLayer;
        public EmployeeController(IEmployeeBL EmployeeBusinessLayerInject)
        {
            try
            {
                EmployeeBusinessLayer = EmployeeBusinessLayerInject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

      //  EmployeeBL EmployeeBusinessLayer = new EmployeeBL();
       /// <summary>
       ///  Retrive the the Total Information of the User from the database
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            if (EmployeeBusinessLayer.Get().Count == 0)
            {
                return NotFound(new { Message = "No data Found" });
            }
            return Ok(EmployeeBusinessLayer.Get());
        }
        /// <summary>
        ///  Send The Id of Employee to The Business Layer And Return the data form the Busineess Layer
        /// </summary>
        /// <param name="id">get The User Information of Id Will be </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            EmployeeDetails employee = EmployeeBusinessLayer.Get(id);
            if (employee == null)
            {
                return NotFound(new { Message="No data Fount at the Id " +id});
            }
            return Ok(employee);
        }
        /// <summary>
        /// It Take the User Id form the User and Delete the Record of the User
        /// </summary>
        /// <param name="id">Id is the unique key of the User</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (EmployeeBusinessLayer.Delete(id) == 0)
            {
                return NotFound(new { Massage = "No Data Found in the Database of Id "+ id});
            }
            return Ok();
        }
        /// <summary>
        ///     Take the Id And Data form the User And Update the information in the database at the given id of the User
        /// </summary>
        /// <param name="id">Id is a unique Key of A particular user</param>
        /// <param name="employee">Store all the Informartion in the of given user in the employee and send it to the Busness Layer</param>
        /// <returns></returns>
         [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] EmployeeDetails employee)
         {
            if(EmployeeBusinessLayer.Put(id,employee)==0)
            {
                return NotFound(new { Massage = "No Record Found At The "+id });
            }
            return Ok();
         }
        /// <summary>
        ///     Take The Information From the User and Send it to The Busineess layer
        /// </summary>
        /// <param name="employee">Store All the information in the Employee</param>
        [HttpPost]
        public void Post(EmployeeDetails employee)
        {
            EmployeeBusinessLayer.Post(employee);
        }
    }
}
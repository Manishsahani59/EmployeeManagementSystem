using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        EmployeeBL EmployeeBusinessLayer = new EmployeeBL();
        [HttpGet]
        public List<EmployeeDetails> Get()
        {
           return EmployeeBusinessLayer.Get();
        }
        [HttpGet("{id}")]
        public EmployeeDetails Get(int id)
        {
            return EmployeeBusinessLayer.Get(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeBusinessLayer.Delete(id);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDetails employee)
        {
            EmployeeBusinessLayer.Put(id,employee);
        }
        [HttpPost]
        public void Post(EmployeeDetails employee)
        {
            EmployeeBusinessLayer.Post(employee);
        }
    }
}
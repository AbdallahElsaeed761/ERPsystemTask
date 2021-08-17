using ERPsystem.BL.AppServices;
using ERPsystem.BL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPsystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeAppService _employeeAppService;

        public EmployeeController(EmployeeAppService employeeAppService)
        {
            this._employeeAppService = employeeAppService;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeAppService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(_employeeAppService.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
               var emp= _employeeAppService.SaveNewEmployee(employeeDto);

               
                return Created("CreateEmployee",emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, EmployeeDto employeeDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _employeeAppService.UpdateEmployee(employeeDto);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeAppService.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        
    }
}

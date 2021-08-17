using ERPsystem.BL.AppServices;
using ERPsystem.BL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPsystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentAppService _departmentAppService;

        public DepartmentController(DepartmentAppService departmentAppService)
        {
            this._departmentAppService = departmentAppService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_departmentAppService.GetAllDepartments());
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            return Ok(_departmentAppService.GetDepartment(id));
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _departmentAppService.SaveNewDepartment(departmentDto);


                return Created("CreateDepartment", departmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, DepartmentDto departmentDto)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _departmentAppService.UpdateDepartment(departmentDto);
                return Ok(departmentDto);
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
                _departmentAppService.DeleteDepartment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Placidusax.Data.DBModels;
using Placidusax.Interfaces;
using Placidusax.Models.RequestModels;

namespace Placidusax.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(DepartmentRequestModel model)
    {
        var newDepartment = await _departmentService.CreateDepartment(model);

        return Ok(newDepartment);
    }

    [HttpGet("me")]
    public async Task<IActionResult> Get(string id)
    {
        var department = await _departmentService.GetDepartment(id);

        return Ok(department);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var departments = await _departmentService.GetAllDepartments();

        return Ok(departments);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Department department)
    {
        var updatedDepartment = await _departmentService.UpdateDepartment(department);

        return Ok(updatedDepartment);
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(string id)
    {
        await _departmentService.DeleteDepartment(id);

        return Ok("Department was deleted");
    }
}


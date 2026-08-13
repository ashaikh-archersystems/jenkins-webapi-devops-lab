using JenkinsWebApi.DTOs;
using JenkinsWebApi.Models;
using JenkinsWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JenkinsWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(
        IEmployeeService employeeService,
        ILogger<EmployeesController> logger)
    {
        _employeeService = employeeService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all employees");

        return Ok(_employeeService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _employeeService.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Department = dto.Department,
            Salary = dto.Salary
        };

        var created = _employeeService.Create(employee);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }
}
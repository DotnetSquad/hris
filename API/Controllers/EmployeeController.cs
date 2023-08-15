using API.DataTransferObjects.Employees;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeService.Get();

        if (!employees.Any())
        {
            return NotFound(new ResponseHandler<EmployeeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Employees Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<IEnumerable<EmployeeDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Employees Found",
            Data = employees
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var employee = _employeeService.Get(guid);

        if (employee is null)
        {
            return NotFound(new ResponseHandler<EmployeeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Employee Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<EmployeeDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Employee Found",
            Data = employee
        });
    }

    [HttpPost]
    public IActionResult Create(EmployeeDtoCreate employeeDtoCreate)
    {
        var employee = _employeeService.Create(employeeDtoCreate);

        if (employee is null)
        {
            return BadRequest(new ResponseHandler<EmployeeDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Employee Not Created",
                Data = null
            });
        }

        return Ok(new ResponseHandler<EmployeeDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Employee Created",
            Data = employee
        });
    }

    [HttpPut]
    public IActionResult Update(EmployeeDtoUpdate employeeDtoUpdate)
    {
        var employee = _employeeService.Update(employeeDtoUpdate);

        if (employee == -1)
        {
            return NotFound(new ResponseHandler<EmployeeDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Employee Not Found",
                Data = null
            });
        }

        if (employee == 0)
        {
            return BadRequest(new ResponseHandler<EmployeeDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Employee Not Updated",
                Data = null
            });
        }

        return Ok(new ResponseHandler<EmployeeDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Employee Updated",
            Data = employeeDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var employee = _employeeService.Delete(guid);

        if (employee == -1)
        {
            return NotFound(new ResponseHandler<EmployeeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Employee Not Found",
                Data = null
            });
        }

        if (employee == 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<EmployeeDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Employee Not Deleted",
                Data = null
            });
        }

        return Ok(new ResponseHandler<EmployeeDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Employee Deleted",
            Data = null
        });
    }
}

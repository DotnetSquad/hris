using API.DataTransferObjects.Departments;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var departments = _departmentService.Get();

        if (!departments.Any())
        {
            return NotFound(new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Departments Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<IEnumerable<DepartmentDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Departments Found",
            Data = departments
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var department = _departmentService.Get(guid);

        if (department == null)
        {
            return NotFound(new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Department Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<DepartmentDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department Found",
            Data = department
        });
    }

    [HttpPost]
    public IActionResult Create(DepartmentDtoCreate departmentDtoCreate)
    {
        var department = _departmentService.Create(departmentDtoCreate);

        if (department == null)
        {
            return BadRequest(new ResponseHandler<DepartmentDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Department Not Created",
                Data = null
            });
        }
        return Ok(new ResponseHandler<DepartmentDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Department Created",
            Data = department
        });
    }

    [HttpPut]
    public IActionResult Update(DepartmentDtoUpdate departmentDtoUpdate)
    {
        var account = _departmentService.Update(departmentDtoUpdate);

        if (account == 0)
        {
            return BadRequest(new ResponseHandler<DepartmentDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Department Not Updated",
                Data = null
            });
        }
        if (account == -1)
        {
            return NotFound(new ResponseHandler<DepartmentDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Department Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<DepartmentDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department Updated",
            Data = departmentDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var department = _departmentService.Delete(guid);

        if (department == 0)
        {
            return BadRequest(new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Department Not Deleted",
                Data = null
            });
        }
        if (department == -1)
        {
            return NotFound(new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Department Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<DepartmentDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department Deleted",
            Data = null
        });
    }
}
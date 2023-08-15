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
    public IActionResult GetAll()
    {
        var departments = _departmentService.Get();

        if (!departments.Any())
            return NotFound(new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Department Not Found",
            });

        return Ok(new ResponseHandler<IEnumerable<DepartmentDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department Found",
            Data = departments
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var departement = _departmentService.Get(guid);

        if (departement is null)
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
            Data = departement
        });
    }

    [HttpPost]
    public IActionResult Create(DepartmentDtoCreate departmentDtoCreate)
    {
        var departmentCreated = _departmentService.Create(departmentDtoCreate);
        if (departmentCreated == null)
            return BadRequest(new ResponseHandler<DepartmentDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Department not created"
            });

        return Ok(new ResponseHandler<DepartmentDtoCreate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department created",
            Data = departmentCreated
        });
    }

    [HttpPut]
    public IActionResult Update(DepartmentDtoUpdate departmentDtoUpdate)
    {
        var departmentUpdated = _departmentService.Update(departmentDtoUpdate);
        if (departmentUpdated == -1)
            return NotFound(new ResponseHandler<DepartmentDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found",
                Data = null
            });

        if (departmentUpdated == 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<DepartmentDtoUpdate>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database",
                Data = null
            });

        return Ok(new ResponseHandler<DepartmentDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department updated",
            Data = departmentDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var departmentDeleted = _departmentService.Delete(guid);

        if (departmentDeleted == -1)
            return NotFound(new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });

        if (departmentDeleted == 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<DepartmentDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });

        return Ok(new ResponseHandler<DepartmentDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Department deleted"
        });
    }
}
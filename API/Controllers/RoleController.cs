using API.DataTransferObjects.Roles;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var roles = _roleService.Get();

        if (!roles.Any())
        {
            return NotFound(new ResponseHandler<RoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Roles Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<IEnumerable<RoleDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Roles Found",
            Data = roles
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var role = _roleService.Get(guid);
        if (role is null)
        {
            return NotFound(new ResponseHandler<RoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Role Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role Found",
            Data = role
        });
    }

    [HttpPost]
    public IActionResult Create(RoleDtoCreate roleDtoCreate)
    {
        var role = _roleService.Create(roleDtoCreate);
        if (role is null)
        {
            return NotFound(new ResponseHandler<RoleDtoCreate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Role Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoCreate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role Found",
            Data = role
        });
    }

    [HttpPut]
    public IActionResult Update(RoleDtoUpdate roleDtoUpdate)
    {
        var role = _roleService.Update(roleDtoUpdate);
        if (role == -1)
        {
            return NotFound(new ResponseHandler<RoleDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Role Not Found",
                Data = null
            });
        }

        if (role == 0)
        {
            return BadRequest(new ResponseHandler<RoleDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Role Not Updated",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role Updated",
            Data = roleDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var role = _roleService.Delete(guid);

        if (role == -1)
        {
            return NotFound(new ResponseHandler<RoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Role Not Found",
                Data = null
            });
        }

        if (role == 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<RoleDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Role Not Deleted",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role Deleted",
            Data = null
        });
    }
}

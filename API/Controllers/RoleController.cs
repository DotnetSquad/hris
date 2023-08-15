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
                Message = "No roles found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<IEnumerable<RoleDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role found",
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
                Message = "No roles found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role found",
            Data = role
        });
    }

    [HttpPost]
    public IActionResult Create(RoleDtoCreate roleDtoCreate)
    {
        var roleCreated = _roleService.Create(roleDtoCreate);
        if (roleCreated is null)
        {
            return NotFound(new ResponseHandler<RoleDtoCreate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "No role found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoCreate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role found",
            Data = roleCreated
        });
    }

    [HttpPut]
    public IActionResult Update(RoleDtoUpdate roleDtoUpdate)
    {
        var roleUpdated = _roleService.Update(roleDtoUpdate);
        if (roleUpdated == -1)
        {
            return NotFound(new ResponseHandler<RoleDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "No role found",
                Data = null
            });
        }

        if (roleUpdated == 0)
        {
            return BadRequest(new ResponseHandler<RoleDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Role not updated",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role updated",
            Data = roleDtoUpdate
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var roleDeleted = _roleService.Delete(guid);

        if (roleDeleted == -1)
        {
            return NotFound(new ResponseHandler<RoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Role not found",
                Data = null
            });
        }

        if (roleDeleted == 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<RoleDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Role not deleted",
                Data = null
            });
        }

        return Ok(new ResponseHandler<RoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Role deleted",
            Data = null
        });
    }
}

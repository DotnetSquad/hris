using API.DataTransferObjects.AccountRoles;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountRoleController : ControllerBase
{
    private readonly AccountRoleService _accountRoleService;
    public AccountRoleController(AccountRoleService accountRoleService)
    {
        _accountRoleService = accountRoleService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _accountRoleService.GetAccountRole();

        if (!entities.Any())
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Role Not Found",
            });

        return Ok(new ResponseHandler<IEnumerable<AccountRoleDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Role Found",
            Data = entities
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetbyGuid(Guid guid)
    {
        var accountrole = _accountRoleService.Get(guid);

        if (accountrole is null)
        {
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Role Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<AccountRoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Role Found",
            Data = accountrole
        });
    }

    [HttpPost]
    public IActionResult Create(AccountRoleDtoCreate accountRoleDtoCreate)
    {
        var accountRoleCreated = _accountRoleService.Create(accountRoleDtoCreate);
        if (accountRoleCreated == null)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Role not created"
            });
        }
        return Ok(new ResponseHandler<AccountRoleDtoCreate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Role created",
            Data = accountRoleCreated
        });
    }

    [HttpPut]
    public IActionResult Update(AccountRoleDtoUpdate accountRoleDtoUpdate)
    {
        var accountRoleUpdated = _accountRoleService.Update(accountRoleDtoUpdate);
        if (accountRoleUpdated == -1)
            return NotFound(new ResponseHandler<AccountRoleDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found",
                Data = null
            });

        if (accountRoleUpdated == 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountRoleDtoUpdate>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database",
                Data = null
            });

        return Ok(new ResponseHandler<AccountRoleDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Role updated",
            Data = accountRoleDtoUpdate
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var accountRoleDeleted = _accountRoleService.Delete(guid);

        if (accountRoleDeleted == -1)
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });

        if (accountRoleDeleted == 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });

        return Ok(new ResponseHandler<AccountRoleDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Role deleted"
        });
    }

}

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
    public IActionResult Get()
    {
        var accountRoles = _accountRoleService.Get();

        if (!accountRoles.Any())
        {
            return NotFound(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Roles Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<IEnumerable<AccountRoleDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Roles Found",
            Data = accountRoles
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var accountRole = _accountRoleService.Get(guid);

        if (accountRole == null)
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
            Data = accountRole
        });
    }

    [HttpPost]
    public IActionResult Create(AccountRoleDtoCreate accountRoleDtoCreate)
    {
        var accountRole = _accountRoleService.Create(accountRoleDtoCreate);

        if (accountRole == null)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Role Not Created",
                Data = null
            });
        }
        return Ok(new ResponseHandler<AccountRoleDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Account Role Created",
            Data = accountRole
        });
    }

    [HttpPut]
    public IActionResult Update(AccountRoleDtoUpdate accountRoleDtoUpdate)
    {
        var account = _accountRoleService.Update(accountRoleDtoUpdate);

        if (account == 0)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Role Not Updated",
                Data = null
            });
        }
        if (account == -1)
        {
            return NotFound(new ResponseHandler<AccountRoleDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Role Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<AccountRoleDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Role Updated",
            Data = accountRoleDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var accountRole = _accountRoleService.Delete(guid);

        if (accountRole == 0)
        {
            return BadRequest(new ResponseHandler<AccountRoleDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Role Not Deleted",
                Data = null
            });
        }
        if (accountRole == -1)
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
            Message = "Account Role Deleted",
            Data = null
        });
    }
}

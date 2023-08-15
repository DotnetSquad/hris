using System.Net;
using API.DataTransferObjects.Accounts;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var accounts = _accountService.Get();

        if (!accounts.Any())
        {
            return NotFound(new ResponseHandler<AccountDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Accounts Not Found",
                Data = null
            });
        }  
        return Ok(new ResponseHandler<IEnumerable<AccountDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Accounts Found",
            Data = accounts
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var account = _accountService.Get(guid);

        if (account == null)
        {
            return NotFound(new ResponseHandler<AccountDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<AccountDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Found",
            Data = account
        });
    }

    [HttpPost]
    public IActionResult Create(AccountDtoCreate accountDtoCreate)
    {
        var account = _accountService.Create(accountDtoCreate);

        if (account == null)
        {
            return BadRequest(new ResponseHandler<AccountDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Not Created",
                Data = null
            });
        }
        return Ok(new ResponseHandler<AccountDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.Created.ToString(),
            Message = "Account Created",
            Data = account
        });
    }

    [HttpPut]
    public IActionResult Update(AccountDtoUpdate accountDtoUpdate)
    {
        var account = _accountService.Update(accountDtoUpdate);

        if (account == 0)
        {
            return BadRequest(new ResponseHandler<AccountDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Not Updated",
                Data = null
            });
        }
        if (account == -1)
        {
            return NotFound(new ResponseHandler<AccountDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<AccountDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Updated",
            Data = accountDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var account = _accountService.Delete(guid);

        if (account == 0)
        {
            return BadRequest(new ResponseHandler<AccountDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Account Not Deleted",
                Data = null
            });
        }
        if (account == -1)
        {
            return NotFound(new ResponseHandler<AccountDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Account Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<AccountDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Account Deleted",
            Data = null
        });
    }
}
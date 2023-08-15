using System.Net;
using API.DataTransferObjects.Overtimes;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OvertimeController : ControllerBase
{
    private readonly OvertimeService _overtimeService;

    public OvertimeController(OvertimeService overtimeService)
    {
        _overtimeService = overtimeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var overtimes = _overtimeService.Get();

        if (!overtimes.Any())
        {
            return NotFound(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Overtimes Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<IEnumerable<OvertimeDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtimes Found",
            Data = overtimes
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var overtime = _overtimeService.Get(guid);

        if (overtime is null)
        {
            return NotFound(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Overtime Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<OvertimeDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtime Found",
            Data = overtime
        });
    }

    [HttpPost]
    public IActionResult Create(OvertimeDtoCreate overtimeDtoCreate)
    {
        var overtime = _overtimeService.Create(overtimeDtoCreate);

        if (overtime is null)
        {
            return BadRequest(new ResponseHandler<OvertimeDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Overtime Not Created",
                Data = null
            });
        }

        return Ok(new ResponseHandler<OvertimeDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtime Created",
            Data = overtime
        });
    }

    [HttpPut]
    public IActionResult Update(OvertimeDtoUpdate overtimeDtoUpdate)
    {
        var overtime = _overtimeService.Update(overtimeDtoUpdate);

        if (overtime == -1)
        {
            return NotFound(new ResponseHandler<OvertimeDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Overtime Not Found",
                Data = null
            });
        }

        if (overtime == 0)
        {
            return BadRequest(new ResponseHandler<OvertimeDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Overtime Not Updated",
                Data = null
            });
        }

        return Ok(new ResponseHandler<OvertimeDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtime Updated",
            Data = overtimeDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var overtime = _overtimeService.Delete(guid);

        if (overtime == -1)
        {
            return NotFound(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Overtime Not Found",
                Data = null
            });
        }

        if (overtime == 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Overtime Not Deleted",
                Data = null
            });
        }

        return Ok(new ResponseHandler<OvertimeDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtime Deleted",
            Data = null
        });
    }
}

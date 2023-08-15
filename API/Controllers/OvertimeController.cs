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
    public IActionResult GetAll()
    {
        var entities = _overtimeService.Get();

        if (!entities.Any())
            return NotFound(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Overtime Not Found",
            });

        return Ok(new ResponseHandler<IEnumerable<OvertimeDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtime Found",
            Data = entities
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var overtime = _overtimeService.Get(guid);

        if (overtime is null)
        {
            return NotFound(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Profile Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<OvertimeDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile Found",
            Data = overtime
        });
    }

    [HttpPost]
    public IActionResult Create(OvertimeDtoCreate overtimeDtoCreate)
    {
        var overtimeCreated = _overtimeService.Create(overtimeDtoCreate);
        if (overtimeCreated == null)
            return BadRequest(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Profile not created"
            });

        return Ok(new ResponseHandler<OvertimeDtoCreate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile created",
            Data = overtimeCreated
        });
    }

    [HttpPut]
    public IActionResult Update(OvertimeDtoUpdate overtimeDtoUpdate)
    {
        var overtimeUpdated = _overtimeService.Update(overtimeDtoUpdate);
        if (overtimeUpdated == -1)
            return NotFound(new ResponseHandler<OvertimeDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found",
                Data = null
            });

        if (overtimeUpdated == 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database",
                Data = null
            });

        return Ok(new ResponseHandler<OvertimeDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Overtime updated",
            Data = overtimeDtoUpdate
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var overtimeDeleted = _overtimeService.Delete(guid);

        if (overtimeDeleted == -1)
            return NotFound(new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });

        if (overtimeDeleted == 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<OvertimeDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });

        return Ok(new ResponseHandler<OvertimeDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile deleted"
        });
    }

}

using API.DataTransferObjects.Profiles;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ProfileService _profileService;
    public ProfileController (ProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var profiles = _profileService.Get();

        if (!profiles.Any())
        {
            return NotFound(new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Profiles Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<IEnumerable<ProfileDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profiles Found",
            Data = profiles
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var profile = _profileService.Get(guid);

        if (profile is null)
        {
            return NotFound(new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Profile Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<ProfileDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile Found",
            Data = profile
        });
    }

    [HttpPost]
    public IActionResult Create(ProfileDtoCreate profileDtoCreate)
    {
        var profile = _profileService.Create(profileDtoCreate);

        if (profile is null)
        {
            return BadRequest(new ResponseHandler<ProfileDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Profile Not Created",
                Data = null
            });
        }

        return Ok(new ResponseHandler<ProfileDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile Created",
            Data = profile
        });
    }

    [HttpPut]
    public IActionResult Update(ProfileDtoUpdate profileDtoUpdate)
    {
        var profile = _profileService.Update(profileDtoUpdate);

        if (profile == -1)
        {
            return NotFound(new ResponseHandler<ProfileDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Profile Not Found",
                Data = null
            });
        }

        if (profile == 0)
        {
            return BadRequest(new ResponseHandler<ProfileDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Profile Not Updated",
                Data = null
            });
        }

        return Ok(new ResponseHandler<ProfileDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile Updated",
            Data = profileDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var profile = _profileService.Delete(guid);

        if (profile == -1)
        {
            return NotFound(new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Profile Not Found",
                Data = null
            });
        }

        if (profile == 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Profile Not Deleted",
                Data = null
            });
        }

        return Ok(new ResponseHandler<ProfileDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Profile Deleted",
            Data = null
        });
    }
}
    
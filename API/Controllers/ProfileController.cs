using API.DataTransferObjects.Profiles;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/profiles")]
public class ProfileController : ControllerBase
{
    private readonly ProfileService _profileService;
    public ProfileController (ProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = _profileService.Get();

        if (!entities.Any())
            return NotFound(new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found",
            });

        return Ok(new ResponseHandler<IEnumerable<ProfileDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data Found",
            Data = entities
        });
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid (Guid guid)
    {
        var profile = _profileService.Get(guid);
        
        if(profile is null)
        {
            return NotFound(new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Data Not Found",
            });
        }

        return Ok(new ResponseHandler<ProfileDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Data Found",
            Data = profile
        });
    }

    [HttpPost]
    public IActionResult Create(ProfileDtoCreate profileDtoCreate)
    {
        var createdProfile = _profileService.Create(profileDtoCreate);
        if (createdProfile is null)
            return BadRequest(new ResponseHandler<ProfileDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Data not created"
            });

        return Ok(new ResponseHandler<ProfileDtoCreate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully created",
            Data = createdProfile
        });
    }

    [HttpPut]
    public IActionResult Update(ProfileDtoUpdate profileDtoUpdate)
    {
        var update = _profileService.Update(profileDtoUpdate);
        if (update is -1)
            return NotFound(new ResponseHandler<ProfileDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });

        if (update is 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<ProfileDtoUpdate>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });

        return Ok(new ResponseHandler<ProfileDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully updated"
        });
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var delete = _profileService.Delete(guid);

        if (delete is -1)
            return NotFound(new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Id not found"
            });

        if (delete is 0)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<ProfileDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });

        return Ok(new ResponseHandler<ProfileDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Successfully deleted"
        });
    }
}

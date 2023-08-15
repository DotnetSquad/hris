using API.DataTransferObjects.Jobs;
using API.Services;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class JobController : ControllerBase
{
    private readonly JobService _JobService;

    public JobController(JobService JobService)
    {
        _JobService = JobService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var jobs = _JobService.Get();

        if (!jobs.Any())
        {
            return NotFound(new ResponseHandler<JobDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Jobs Not Found",
                Data = null
            });
        }
        return Ok(new ResponseHandler<IEnumerable<JobDtoGet>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Jobs Found",
            Data = jobs
        });
    }

    [HttpGet("{guid}")]
    public IActionResult Get(Guid guid)
    {
        var job = _JobService.Get(guid);

        if (job is null)
        {
            return NotFound(new ResponseHandler<JobDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Job Not Found",
                Data = null
            });
        }

        return Ok(new ResponseHandler<JobDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Job Found",
            Data = job
        });
    }

    [HttpPost]
    public IActionResult Create(JobDtoCreate jobDtoCreate)
    {
        var job = _JobService.Create(jobDtoCreate);

        if (job is null)
        {
            return BadRequest(new ResponseHandler<JobDtoCreate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Job Not Created",
                Data = null
            });
        }

        return Ok(new ResponseHandler<JobDtoCreate>
        {
            Code = StatusCodes.Status201Created,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Job Created",
            Data = job
        });
    }

    [HttpPut]
    public IActionResult Update(JobDtoUpdate jobDtoUpdate)
    {
        var job = _JobService.Update(jobDtoUpdate);

        if (job == -1)
        {
            return NotFound(new ResponseHandler<JobDtoUpdate>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Job Not Found",
                Data = null
            });
        }

        if (job == 0)
        {
            return BadRequest(new ResponseHandler<JobDtoUpdate>
            {
                Code = StatusCodes.Status400BadRequest,
                Status = HttpStatusCode.BadRequest.ToString(),
                Message = "Job Not Updated",
                Data = null
            });
        }

        return Ok(new ResponseHandler<JobDtoUpdate>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Job Updated",
            Data = jobDtoUpdate
        });
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(Guid guid)
    {
        var job = _JobService.Delete(guid);

        if (job == -1)
        {
            return NotFound(new ResponseHandler<JobDtoGet>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Job Not Found",
                Data = null
            });
        }

        if (job == 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHandler<JobDtoGet>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Job Not Deleted",
                Data = null
            });
        }

        return Ok(new ResponseHandler<JobDtoGet>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Job Deleted",
            Data = null
        });
    }
}

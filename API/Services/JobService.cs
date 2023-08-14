using API.Contracts;
using API.DataTransferObjects.Jobs;

namespace API.Services;

public class JobService
{
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public IEnumerable<JobDtoGet> Get()
    {
        var jobs = _jobRepository.GetAll();
        if (!jobs.Any()) return Enumerable.Empty<JobDtoGet>();
        List<JobDtoGet> jobDtoGets = new();

        foreach (var job in jobs)
        {
            jobDtoGets.Add((JobDtoGet)job);
        }

        return jobDtoGets;
    }

    public JobDtoGet? Get(Guid guid)
    {
        var job = _jobRepository.GetByGuid(guid);
        if (job is null) return null;

        return (JobDtoGet)job;
    }

    public JobDtoCreate? Create(JobDtoCreate jobDtoCreate)
    {
        var jobCreated = _jobRepository.Create(jobDtoCreate);
        if (jobCreated is null) return null;

        return (JobDtoCreate)jobCreated;
    }

    public int Update(JobDtoUpdate jobDtoUpdate)
    {
        var job = _jobRepository.GetByGuid(jobDtoUpdate.Guid);
        if (job is null) return -1;

        var jobUpdated = _jobRepository.Update(jobDtoUpdate);
        return jobUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var job = _jobRepository.GetByGuid(guid);
        if (job is null) return -1;

        var jobDeleted = _jobRepository.Delete(job);
        return jobDeleted ? 1 : 0;
    }
}

using API.Models;

namespace API.DataTransferObjects.Jobs;

public class JobDtoGet
{
    public Guid Guid { get; set; }

    public string Position { get; set; }

    public int Salary { get; set; }

    public Guid DepeartmentGuid { get; set; }

    //Implicit Operator
    public static implicit operator Job(JobDtoGet jobDtoGet)
    {
        return new Job
        {
            Guid = jobDtoGet.Guid,
            Position = jobDtoGet.Position,
            Salary = jobDtoGet.Salary,
            DepartmentGuid = jobDtoGet.DepeartmentGuid
        };
    }

    //Explicit Opearator
    public static explicit operator JobDtoGet(Job job)
    {
        return new JobDtoGet
        {
            Guid = job.Guid,
            Position = job.Position,
            Salary = job.Salary,
            DepeartmentGuid = job.DepartmentGuid
        };
    }
}

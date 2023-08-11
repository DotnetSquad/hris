using API.Models;

namespace API.DataTransferObjects.Jobs;

public class JobDtoUpdate
{
    public Guid Guid { get; set; }

    public string Position { get; set; }

    public int Salary { get; set; }

    public Guid DepeartmentGuid { get; set; }

    //Implicit Operator
    public static implicit operator Job(JobDtoUpdate jobDtoUpdate)
    {
        return new Job
        {
            Guid = jobDtoUpdate.Guid,
            Position = jobDtoUpdate.Position,
            Salary = jobDtoUpdate.Salary,
            DepartmentGuid = jobDtoUpdate.DepeartmentGuid
        };
    }

    //Explicit Opearator
    public static explicit operator JobDtoUpdate(Job job)
    {
        return new JobDtoUpdate
        {
            Guid = job.Guid,
            Position = job.Position,
            Salary = job.Salary,
            DepeartmentGuid = job.DepartmentGuid
        };
    }
}

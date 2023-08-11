using API.Models;

namespace API.DataTransferObjects.Jobs

public class JobDtoCreate

    public string Position { get; set; }

    public int Salary { get; set; }

    public Guid DepeartmentGuid { get; set; }

    //Implicit Operator
    public static implicit operator Job(JobDtoCreate jobDtoCreate)
    {
        return new Job
        {
            Position = jobDtoCreate.Position,
            Salary = jobDtoCreate.Salary,
            DepartmentGuid = jobDtoCreate.DepeartmentGuid
        };
    }

    //Explicit Opearator
    public static explicit operator JobDtoCreate(Job job)
    {
        return new JobDtoCreate
        {
            Position = job.Position,
            Salary = job.Salary,
            DepeartmentGuid = job.DepartmentGuid
        };
    }
}

using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.Overtimes;

public class OvertimeDtoGet
{
    public Guid Guid { get; set; }
    public int RequestNumber { get; set; }
    public DateTime SubmitedDate { get; set; }
    public string Remarks { get; set; }
    public StatusEnum Status { get; set; }
    public int Remaining { get; set; }
    public Guid EmployeeGuid { get; set; }

    // Implicit operator
    public static implicit operator Overtime(OvertimeDtoGet overtimeDtoGet)
    {
        return new Overtime
        {
            Guid = overtimeDtoGet.Guid,
            RequestNumber = overtimeDtoGet.RequestNumber,
            SubmitedDate = overtimeDtoGet.SubmitedDate,
            Remarks = overtimeDtoGet.Remarks,
            Status = overtimeDtoGet.Status,
            Remaining = overtimeDtoGet.Remaining,
            EmployeeGuid = overtimeDtoGet.EmployeeGuid
        };
    }

    // Explicit operator
    public static explicit operator OvertimeDtoGet(Overtime overtime)
    {
        return new OvertimeDtoGet
        {
            Guid = overtime.Guid,
            RequestNumber = overtime.RequestNumber,
            SubmitedDate = overtime.SubmitedDate,
            Remarks = overtime.Remarks,
            Status = overtime.Status,
            Remaining = overtime.Remaining,
            EmployeeGuid = overtime.EmployeeGuid
        };
    }
}

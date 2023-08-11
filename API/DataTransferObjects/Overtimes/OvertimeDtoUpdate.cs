using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.Overtimes;

public class OvertimeDtoUpdate
{
    public Guid Guid { get; set; }
    public int RequestNumber { get; set; }
    public DateTime SubmitedDate { get; set; }
    public string Remarks { get; set; }
    public StatusEnum Status { get; set; }
    public int Remaining { get; set; }
    public Guid EmployeeGuid { get; set; }

    // Implicit operator
    public static implicit operator Overtime(OvertimeDtoUpdate overtimeDtoUpdate)
    {
        return new Overtime
        {
            Guid = overtimeDtoUpdate.Guid,
            RequestNumber = overtimeDtoUpdate.RequestNumber,
            SubmitedDate = overtimeDtoUpdate.SubmitedDate,
            Remarks = overtimeDtoUpdate.Remarks,
            Status = overtimeDtoUpdate.Status,
            Remaining = overtimeDtoUpdate.Remaining,
            EmployeeGuid = overtimeDtoUpdate.EmployeeGuid,
            ModifiedDate = DateTime.UtcNow
        };
    }

    // Explicit operator
    public static explicit operator OvertimeDtoUpdate(Overtime overtime)
    {
        return new OvertimeDtoUpdate
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

using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.Overtimes;

public class OvertimeDtoCreate
{
    public DateTime SubmitedDate { get; set; }
    public string Remarks { get; set; }
    public StatusEnum Status { get; set; }
    public int Remaining { get; set; }
    public Guid EmployeeGuid { get; set; }

    // implicit operator
    public static implicit operator Overtime(OvertimeDtoCreate overtimeDtoCreate)
    {
        return new Overtime
        {
            SubmitedDate = overtimeDtoCreate.SubmitedDate,
            Remarks = overtimeDtoCreate.Remarks,
            Status = overtimeDtoCreate.Status,
            Remaining = overtimeDtoCreate.Remaining,
            EmployeeGuid = overtimeDtoCreate.EmployeeGuid
        };
    }

    // expilicit operator
    public static explicit operator OvertimeDtoCreate(Overtime overtime)
    {
        return new OvertimeDtoCreate
        {
            SubmitedDate = overtime.SubmitedDate,
            Remarks = overtime.Remarks,
            Status = overtime.Status,
            Remaining = overtime.Remaining,
            EmployeeGuid = overtime.EmployeeGuid
        };
    }
}

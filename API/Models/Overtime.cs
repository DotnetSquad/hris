using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_overtimes")]
public class Overtime : BaseEntity
{
    [Column("request_number")]
    public int RequestNumber { get; set; }
    [Column("submited_date")]
    public DateTime SubmitedDate { get; set; }
    [Column("remaks", TypeName = "nvarchar(255)")]
    public string Remaks { get; set; }
    [Column("status")]
    public StatusEnum Status { get; set; }
    [Column("remaining")]
    public int Remaining { get; set; }
    [Column("employee_guid")]
    public Guid EmployeeGuid { get; set; }
}

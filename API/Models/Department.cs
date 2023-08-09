using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_departments")]
public class Department : BaseEntity
{
    [Column("name", TypeName = "nvarchar(30)")]
    public string Name { get; set; }

    [Column("manager_guid")]
    public Guid ManagerGuid { get; set; }

    [Column("job_guid")]
    public Guid JobGuid { get; set; }
}

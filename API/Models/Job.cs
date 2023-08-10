using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_jobs")]
public class Job : BaseEntity
{
    [Column("department_guid")]
    public Guid DepartmentGuid { get; set; }

    [Column("position", TypeName = "nvarchar(100)")]
    public string Position { get; set; }
    
    [Column("salary")]
    public int Salary { get; set; }

    // Cardinality
    public Department Department { get; set; }
    public Employee Employee { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_jobs")]
public class Job : BaseEntity
{
    [Column("position", TypeName = "nvarchar(100)")]
    public string Position { get; set; }
    
    [Column("salary")]
    public int Salary { get; set; }
}

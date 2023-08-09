using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_profiles")]
public class Profile : BaseEntity
{
    [Column("photo", TypeName = "nvarchar(255)")] 
    public string Photo { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Profiles : BaseEntity
{
    [Column("photo")] public string Photo { get; set; }
}

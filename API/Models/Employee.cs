using System.ComponentModel.DataAnnotations.Schema;
using API.Utilities.Enums;

namespace API.Models;

[Table("tb_m_employees")]
public class Employee : BaseEntity
{
    [Column("nip", TypeName = "nvarchar(6)")]
    public string Nip { get; set; }

    [Column("nik", TypeName = "nvarchar(16)")]
    public string Nik { get; set; }

    [Column("npwp", TypeName = "nvarchar(15)")]
    public string Npwp { get; set; }

    [Column("first_name", TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [Column("last_name", TypeName = "nvarchar(100)")]
    public string? LastName { get; set; }

    [Column("birth_date")]
    public DateTime BirthDate { get; set; }

    [Column("place_of_birth", TypeName = "nvarchar(50)")]
    public string PlaceOfBirth { get; set; }

    [Column("marriage_status")]
    public MarriageStatusEnum MarriageStatus { get; set; }

    [Column("gender")]
    public GenderEnum Gender { get; set; }

    [Column("join_date")]
    public DateTime JoinDate { get; set; }

    [Column("bank_account", TypeName = "nvarchar(20)")]
    public string BankAccount { get; set; }

    [Column("email", TypeName = "nvarchar(50)")]
    public string Email { get; set; }

    [Column("phone_number", TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; }

    [Column("emergency_number", TypeName = "nvarchar(20)")]
    public string EmergencyNumber { get; set; }

    [Column("profile_guid")]
    public Guid ProfileGuid { get; set; }

    [Column("job_guid")]
    public Guid JobGuid { get; set; }

    // Cardinalitas
    public Account? Account { get; set; }
    public Department? Department { get; set; }
    public Job? Job { get; set; }
    public ICollection<Overtime>? Overtimes { get; set; }
    public Profile? Profile { get; set; }
}
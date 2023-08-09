using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class AccountRole : BaseEntity
{
    [Column("account_guid")] public Guid AccountGuid { get; set; }

    [Column("role_guid")] public Guid RoleGuid { get; set; }
}

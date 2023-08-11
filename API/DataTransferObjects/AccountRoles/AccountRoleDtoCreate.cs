using API.DataTransferObjects.Departments;
using API.Models;

namespace API.DataTransferObjects.AccountRoles;

public class AccountRoleDtoCreate
{
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    // implicit operator
    public static implicit operator AccountRole(AccountRoleDtoCreate accountRoleDtoCreate)
    {
        return new AccountRole
        {
            AccountGuid = accountRoleDtoCreate.AccountGuid,
            RoleGuid = accountRoleDtoCreate.RoleGuid,
            CreatedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator AccountRoleDtoCreate(AccountRole accountRole)
    {
        return new AccountRoleDtoCreate
        {
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };
    }

}

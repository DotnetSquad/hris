using API.Models;

namespace API.DataTransferObjects.AccountRoles;

public class AccountRoleDtoGet
{
    public Guid Guid { get; set; }
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    // implicit operator
    public static implicit operator AccountRole(AccountRoleDtoGet accountRoleDtoGet)
    {
        return new AccountRole
        {
            Guid = accountRoleDtoGet.Guid,
            AccountGuid = accountRoleDtoGet.AccountGuid,
            RoleGuid = accountRoleDtoGet.RoleGuid
        };
    }

    // explicit operator
    public static explicit operator AccountRoleDtoGet(AccountRole accountRole)
    {
        return new AccountRoleDtoGet
        {
            Guid = accountRole.Guid,
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };
    }
}

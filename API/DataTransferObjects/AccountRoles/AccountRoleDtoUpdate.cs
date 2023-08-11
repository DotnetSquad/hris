using API.Models;

namespace API.DataTransferObjects.AccountRoles;

public class AccountRoleDtoUpdate
{
    public Guid Guid { get; set; }
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    // implicit operator
    public static implicit operator AccountRole(AccountRoleDtoUpdate accountRoleDtoUpdate)
    {
        return new AccountRole
        {
            Guid = accountRoleDtoUpdate.Guid,
            AccountGuid = accountRoleDtoUpdate.AccountGuid,
            RoleGuid = accountRoleDtoUpdate.RoleGuid,
            ModifiedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator AccountRoleDtoUpdate(AccountRole accountRole)
    {
        return new AccountRoleDtoUpdate
        {
            Guid = accountRole.Guid,
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };
    }
}

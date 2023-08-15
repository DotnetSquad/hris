using API.Contracts;
using API.DataTransferObjects.AccountRoles;

namespace API.Services;

public class AccountRoleService
{
    private readonly IAccountRoleRepository _accountRoleRepository;
    public AccountRoleService(IAccountRoleRepository accountRoleRepository)
    {
        _accountRoleRepository = accountRoleRepository;
    }

    public IEnumerable<AccountRoleDtoGet> Get()
    {
        var accountRoles = _accountRoleRepository.GetAll();
        if (!accountRoles.Any()) return Enumerable.Empty<AccountRoleDtoGet>();
        List<AccountRoleDtoGet> accountRoleDtos = new();

        foreach (var accountRole in accountRoles)
        {
            accountRoleDtos.Add((AccountRoleDtoGet)accountRole);
        }

        return accountRoleDtos;
    }

    public AccountRoleDtoGet? Get(Guid guid)
    {
        var accountRole = _accountRoleRepository.GetByGuid(guid);
        if (accountRole is null) return null!;

        return (AccountRoleDtoGet)accountRole;
    }

    public AccountRoleDtoCreate? Create(AccountRoleDtoCreate accountRoleDtoCreate)
    {
        var accountRoleCreated = _accountRoleRepository.Create(accountRoleDtoCreate);
        if (accountRoleCreated is null) return null!;

        return (AccountRoleDtoCreate)accountRoleCreated;
    }

    public int Update(AccountRoleDtoUpdate accountRoleDtoUpdate)
    {
        var accountRole = _accountRoleRepository.GetByGuid(accountRoleDtoUpdate.Guid);
        if (accountRole is null) return -1;

        var accountRoleUpdated = _accountRoleRepository.Update(accountRoleDtoUpdate);
        return accountRoleUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var accountRole = _accountRoleRepository.GetByGuid(guid);
        if (accountRole is null) return -1;

        var accountRoleDeleted = _accountRoleRepository.Delete(accountRole);
        return accountRoleDeleted ? 1 : 0;
    }
}

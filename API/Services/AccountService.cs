using API.Contracts;
using API.DataTransferObjects.Accounts;

namespace API.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public IEnumerable<AccountDtoGet> Get()
    {
        var accounts = _accountRepository.GetAll();
        if (!accounts.Any()) return Enumerable.Empty<AccountDtoGet>();
        List<AccountDtoGet> accountDtoGets = new();

        foreach (var account in accounts)
        {
            accountDtoGets.Add((AccountDtoGet)account);
        }

        return accountDtoGets;
    }

    public AccountDtoGet? Get(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null) return null!;

        return (AccountDtoGet)account;
    }

    public AccountDtoCreate? Create(AccountDtoCreate accountDtoCreate)
    {
        var accountCreated = _accountRepository.Create(accountDtoCreate);
        if (accountDtoCreate is null) return null!;

        return (AccountDtoCreate)accountCreated;
    }

    public int Update(AccountDtoUpdate accountDtoUpdate)
    {
        var account = _accountRepository.GetByGuid(accountDtoUpdate.Guid);
        if (account is null) return -1;

        var accountUpdated = _accountRepository.Update(accountDtoUpdate);
        return accountUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null) return -1;

        var accountDeleted = _accountRepository.Delete(account);
        return accountDeleted ? 1 : 0;
    }
}

using API.Models;

namespace API.DataTransferObjects.Accounts;

public class AccountDtoGet
{
    public Guid Guid { get; set; }
    public string Password { get; set; }
    public bool IsDeleted { get; set; }
    public int? Otp { get; set; }
    public bool? IsUsed { get; set; }
    public DateTime? ExpiredTime { get; set; }

    // implicit operator
    public static implicit operator Account(AccountDtoGet accountDtoGet)
    {
        return new Account
        {
            Guid = accountDtoGet.Guid,
            Password = accountDtoGet.Password,
            IsDeleted = accountDtoGet.IsDeleted,
            Otp = accountDtoGet.Otp,
            IsUsed = accountDtoGet.IsUsed,
            ExpiredTime = accountDtoGet.ExpiredTime
        };
    }

    // explicit operator
    public static explicit operator AccountDtoGet(Account account)
    {
        return new AccountDtoGet
        {
            Guid = account.Guid,
            Password = account.Password,
            IsDeleted = account.IsDeleted,
            Otp = account.Otp,
            IsUsed = account.IsUsed,
            ExpiredTime = account.ExpiredTime
        };
    }
}

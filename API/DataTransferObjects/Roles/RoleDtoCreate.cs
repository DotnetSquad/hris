using API.Models;

namespace API.DataTransferObjects.Roles;

public class RoleDtoCreate
{
    public string Name { get; set; }

    // implicit operator
    public static implicit operator Role(RoleDtoCreate roleDtoCreate)
    {
        return new Role
        {
            Name = roleDtoCreate.Name,
            CreatedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator RoleDtoCreate(Role role)
    {
        return new RoleDtoCreate
        {
            Name = role.Name
        };
    }
}

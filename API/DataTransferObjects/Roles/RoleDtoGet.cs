using API.Models;

namespace API.DataTransferObjects.Roles;

public class RoleDtoGet
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    // implicit operator
    public static implicit operator Role(RoleDtoGet roleDtoGet)
    {
        return new Role
        {
            Guid = roleDtoGet.Guid,
            Name = roleDtoGet.Name
        };
    }

    // explicit operator
    public static explicit operator RoleDtoGet(Role role)
    {
        return new RoleDtoGet
        {
            Guid = role.Guid,
            Name = role.Name
        };
    }
}

using API.Models;

namespace API.DataTransferObjects.Roles;

public class RoleDtoUpdate
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    // implicit operator
    public static implicit operator Role(RoleDtoUpdate roleDtoUpdate)
    {
        return new Role
        {
            Guid = roleDtoUpdate.Guid,
            Name = roleDtoUpdate.Name,
            ModifiedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator RoleDtoUpdate(Role role)
    {
        return new RoleDtoUpdate
        {
            Guid = role.Guid,
            Name = role.Name
        };
    }
}

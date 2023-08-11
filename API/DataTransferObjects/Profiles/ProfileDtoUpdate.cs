using API.Models;

namespace API.DataTransferObjects.Profiles;

public class ProfileDtoUpdate
{
    public Guid Guid { get; set; }
    public string Photo { get; set; }

    // implicit operator
    public static implicit operator Profile(ProfileDtoUpdate profileDtoUpdate)
    {
        return new Profile
        {
            Guid = profileDtoUpdate.Guid,
            Photo = profileDtoUpdate.Photo,
            ModifiedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator ProfileDtoUpdate(Profile profile)
    {
        return new ProfileDtoUpdate
        {
            Guid = profile.Guid,
            Photo = profile.Photo
        };
    }
}

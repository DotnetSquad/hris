using API.Models;

namespace API.DataTransferObjects.Profiles;

public class ProfileDtoGet
{
    public Guid Guid { get; set; }
    public string Photo { get; set; }

    // implicit operator
    public static implicit operator Profile(ProfileDtoGet profileDtoGet)
    {
        return new Profile
        {
            Guid = profileDtoGet.Guid,
            Photo = profileDtoGet.Photo
        };
    }

    // explicit operator
    public static explicit operator ProfileDtoGet(Profile profile)
    {
        return new ProfileDtoGet
        {
            Guid = profile.Guid,
            Photo = profile.Photo
        };
    }
}

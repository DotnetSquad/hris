using API.DataTransferObjects.Roles;
using API.Models;

namespace API.DataTransferObjects.Profiles;

public class ProfileDtoCreate
{
    public string Photo { get; set; }

    // implicit operator
    public static implicit operator Profile(ProfileDtoCreate profileDtoCreate)
    {
        return new Profile
        {
            Photo = profileDtoCreate.Photo,
            CreatedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator ProfileDtoCreate(Profile profile)
    {
        return new ProfileDtoCreate
        {
            Photo = profile.Photo
        };
    }
}

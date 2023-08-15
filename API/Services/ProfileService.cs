using API.Contracts;
using API.DataTransferObjects.Profiles;

namespace API.Services;

public class ProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public IEnumerable<ProfileDtoGet> Get()
    {
        var profiles = _profileRepository.GetAll().ToList();
        if (!profiles.Any()) return Enumerable.Empty<ProfileDtoGet>();
        List<ProfileDtoGet> profileDtoGets = new();

        foreach (var profile in profiles)
        {
            profileDtoGets.Add((ProfileDtoGet)profile);
        }

        return profileDtoGets;
    }

    public ProfileDtoGet? Get(Guid guid)
    {
        var profile = _profileRepository.GetByGuid(guid);
        if (profile is null) return null;

        return (ProfileDtoGet)profile;
    }

    public ProfileDtoCreate? Create(ProfileDtoCreate profileDtoCreate)
    {
        var profileCreated = _profileRepository.Create(profileDtoCreate);
        if (profileCreated is null) return null;

        return (ProfileDtoCreate)profileCreated;
    }

    public int Update(ProfileDtoUpdate profileDtoUpdate)
    {
        var profile = _profileRepository.GetByGuid(profileDtoUpdate.Guid);
        if (profile is null) return -1;

        var profileUpdated = _profileRepository.Update(profileDtoUpdate);
        return profileUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var profile = _profileRepository.GetByGuid(guid);
        if (profile is null) return -1;

        var profileDeleted = _profileRepository.Delete(profile);
        return profileDeleted ? 1 : 0;
    }
}
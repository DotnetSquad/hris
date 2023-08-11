using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
{
    public ProfileRepository(ApplicationDbContext context) : base(context)
    {
    }
}

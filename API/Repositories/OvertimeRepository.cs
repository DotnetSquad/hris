using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class OvertimeRepository : BaseRepository<Overtime>, IOvertimeRepository
{
    public OvertimeRepository(ApplicationDbContext context) : base(context) { }
}

using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    public JobRepository(ApplicationDbContext context) : base(context) { }
}

using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context) { }
}

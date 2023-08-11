using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    protected EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}

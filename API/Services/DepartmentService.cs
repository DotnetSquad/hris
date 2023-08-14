using API.Contracts;
using API.DataTransferObjects.Departments;

namespace API.Services;

public class DepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IEnumerable<DepartmentDtoGet> Get()
    {
        var departments = _departmentRepository.GetAll();
        if (!departments.Any()) return Enumerable.Empty<DepartmentDtoGet>();
        List<DepartmentDtoGet> departmentDtoGets = new();

        foreach (var department in departments)
        {
            departmentDtoGets.Add((DepartmentDtoGet)department);
        }

        return departmentDtoGets;
    }

    public DepartmentDtoGet? Get(Guid guid)
    {
        var department = _departmentRepository.GetByGuid(guid);
        if (department is null) return null!;

        return (DepartmentDtoGet)department;
    }

    public DepartmentDtoCreate? Create(DepartmentDtoCreate departmentDtoCreate)
    {
        var departmentCreated = _departmentRepository.Create(departmentDtoCreate);
        if (departmentCreated is null) return null!;

        return (DepartmentDtoCreate)departmentCreated;
    }

    public int Update(DepartmentDtoUpdate departmentDtoUpdate)
    {
        var department = _departmentRepository.GetByGuid(departmentDtoUpdate.Guid);
        if (departmentDtoUpdate is null) return -1;

        var departmentUpdated = _departmentRepository.Update(departmentDtoUpdate);
        return departmentUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var department = _departmentRepository.GetByGuid(guid);
        if (department is null) return -1;

        var departmentDeleted = _departmentRepository.Delete(department);
        return departmentDeleted ? 1 : 0;
    }
}

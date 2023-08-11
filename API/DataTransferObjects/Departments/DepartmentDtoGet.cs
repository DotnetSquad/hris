using API.Models;

namespace API.DataTransferObjects.Departments;

public class DepartmentDtoGet
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }

    // implicit operator
    public static implicit operator Department(DepartmentDtoGet departmentDtoGet)
    {
        return new Department
        {
            Guid = departmentDtoGet.Guid,
            Name = departmentDtoGet.Name,
            ManagerGuid = departmentDtoGet.ManagerGuid
        };
    }

    // explicit operator
    public static explicit operator DepartmentDtoGet(Department department)
    {
        return new DepartmentDtoGet
        {
            Guid = department.Guid,
            Name = department.Name,
            ManagerGuid = department.ManagerGuid
        };
    }
}

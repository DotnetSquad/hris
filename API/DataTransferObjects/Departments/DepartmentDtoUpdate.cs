using API.Models;

namespace API.DataTransferObjects.Departments;

public class DepartmentDtoUpdate
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }

    // implicit operator
    public static implicit operator Department(DepartmentDtoUpdate departmentDtoUpdate)
    {
        return new Department
        {
            Guid = departmentDtoUpdate.Guid,
            Name = departmentDtoUpdate.Name,
            ManagerGuid = departmentDtoUpdate.ManagerGuid,
            ModifiedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator DepartmentDtoUpdate(Department department)
    {
        return new DepartmentDtoUpdate
        {
            Guid = department.Guid,
            Name = department.Name,
            ManagerGuid = department.ManagerGuid
        };
    }
}

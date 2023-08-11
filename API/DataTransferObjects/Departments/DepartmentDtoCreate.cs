using API.Models;

namespace API.DataTransferObjects.Departments;

public class DepartmentDtoCreate
{
    public string Name { get; set; }
    public Guid? ManagerGuid { get; set; }

    // implicit operator
    public static implicit operator Department(DepartmentDtoCreate departmentDtoCreate)
    {
        return new Department
        {
            Name = departmentDtoCreate.Name,
            ManagerGuid = departmentDtoCreate.ManagerGuid,
            CreatedDate = DateTime.UtcNow
        };
    }

    // explicit operator
    public static explicit operator DepartmentDtoCreate(Department department)
    {
        return new DepartmentDtoCreate
        {
            Name = department.Name,
            ManagerGuid = department.ManagerGuid
        };
    }
}

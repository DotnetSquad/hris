using API.Contracts;
using API.DataTransferObjects.Employees;
using API.Models;

namespace API.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<EmployeeDtoGet> Get()
    {
        var employees = _employeeRepository.GetAll();
        if (!employees.Any()) return Enumerable.Empty<EmployeeDtoGet>();
        List<EmployeeDtoGet> employeeDtoGets = new();

        foreach (var employee in employees)
        {
            employeeDtoGets.Add
            ((EmployeeDtoGet)employee);
        }

        return employeeDtoGets;
    }

    public EmployeeDtoGet? Get(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null) return null!;

        return (EmployeeDtoGet)employee;
    }

    public EmployeeDtoCreate? Create(EmployeeDtoCreate employeeDtoCreate)
    {
        Employee employee = employeeDtoCreate;
        /*employee.Nik = GenerateHandler.Nik(_employeeRepository.GetLastEmpoyeeNik());*/

        var createdEmployee = _employeeRepository.Create(employee);

        if (createdEmployee is null) return null; 

        return (EmployeeDtoCreate)createdEmployee;
    }

    public int Update(EmployeeDtoUpdate employeeDtoUpdate)
    {
        var employee = _employeeRepository.GetByGuid(employeeDtoUpdate.Guid);
        if (employee is null) return -1;

        var employeeUpdated = _employeeRepository.Update(employeeDtoUpdate);
        return employeeUpdated ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null) return -1;

        var employeeDeleted = _employeeRepository.Delete(employee);
        return employeeDeleted ? 1 : 0;
    }
}

using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.Employees;

public class EmployeeDtoCreate
{
    public string Nip { get; set; }

    public string Nik { get; set; }

    public string Npwp { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public string PlaceOfBirth { get; set; }

    public MarriageStatusEnum MarriageStatus { get; set; }

    public GenderEnum Gender { get; set; }

    public DateTime JoinDate { get; set; }

    public string BankAccount { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string EmergencyNumber { get; set; }

    public Guid ProfileGuid { get; set; }

    public Guid JobGuid { get; set; }

    // Implicit Operator
    public static implicit operator Employee(EmployeeDtoCreate employeeDtoUpdate)
    {
        return new Employee
        {
            Nip = employeeDtoUpdate.Nip,
            Nik = employeeDtoUpdate.Nik,
            Npwp = employeeDtoUpdate.Npwp,
            FirstName = employeeDtoUpdate.FirstName,
            LastName = employeeDtoUpdate.LastName,
            BirthDate = employeeDtoUpdate.BirthDate,
            PlaceOfBirth = employeeDtoUpdate.PlaceOfBirth,
            MarriageStatus = employeeDtoUpdate.MarriageStatus,
            Gender = employeeDtoUpdate.Gender,
            JoinDate = employeeDtoUpdate.JoinDate,
            BankAccount = employeeDtoUpdate.BankAccount,
            Email = employeeDtoUpdate.Email,
            PhoneNumber = employeeDtoUpdate.PhoneNumber,
            EmergencyNumber = employeeDtoUpdate.EmergencyNumber,
            ProfileGuid = employeeDtoUpdate.ProfileGuid,
            JobGuid = employeeDtoUpdate.JobGuid,
            CreatedDate = DateTime.UtcNow
        };
    }

    // Explicit Operator
    public static explicit operator EmployeeDtoCreate(Employee employee)
    {
        return new EmployeeDtoCreate
        {
            Nip = employee.Nip,
            Nik = employee.Nik,
            Npwp = employee.Npwp,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            PlaceOfBirth = employee.PlaceOfBirth,
            MarriageStatus = employee.MarriageStatus,
            Gender = employee.Gender,
            JoinDate = employee.JoinDate,
            BankAccount = employee.BankAccount,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            EmergencyNumber = employee.EmergencyNumber,
            ProfileGuid = employee.ProfileGuid,
            JobGuid = employee.JobGuid,
        };
    }
}

using API.Models;
using API.Utilities.Enums;

namespace API.DataTransferObjects.Employees;

public class EmployeeDtoGet
{
    public Guid Guid { get; set; }

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

    public Guid? ProfileGuid { get; set; }

    public Guid? JobGuid { get; set; }

    // Implicit Operator
    public static implicit operator Employee(EmployeeDtoGet employeeDtoGet)
    {
        return new Employee
        {
            Guid = employeeDtoGet.Guid,
            Nip = employeeDtoGet.Nip,
            Nik = employeeDtoGet.Nik,
            Npwp = employeeDtoGet.Npwp,
            FirstName = employeeDtoGet.FirstName,
            LastName = employeeDtoGet.LastName,
            BirthDate = employeeDtoGet.BirthDate,
            PlaceOfBirth = employeeDtoGet.PlaceOfBirth,
            MarriageStatus = employeeDtoGet.MarriageStatus,
            Gender = employeeDtoGet.Gender,
            JoinDate = employeeDtoGet.JoinDate,
            BankAccount = employeeDtoGet.BankAccount,
            Email = employeeDtoGet.Email,
            PhoneNumber = employeeDtoGet.PhoneNumber,
            EmergencyNumber = employeeDtoGet.EmergencyNumber,
            ProfileGuid = employeeDtoGet.ProfileGuid,
            JobGuid = employeeDtoGet.JobGuid,
        };
    }

    // Explicit Operator
    public static explicit operator EmployeeDtoGet(Employee employee)
    {
        return new EmployeeDtoGet
        {
            Guid = employee.Guid,
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

using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Tables
    public DbSet<Role> Roles { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Overtime> Overtimes { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Department> departments { get; set; }

    // Other Configuration or Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Constraint Unique
        modelBuilder.Entity<Employee>().HasIndex(e => new
        {
            e.Nip,
            e.Nik,
            e.Npwp,
            e.BankAccount,
            e.Email,
            e.PhoneNumber,
            e.EmergencyNumber
        }).IsUnique();

        modelBuilder.Entity<Overtime>().HasIndex(o => new
        {
            o.RequestNumber
        }).IsUnique();

        // Relationship
        // Account - AccountRole 
        modelBuilder.Entity<Account>()
            .HasMany(account => account.AccountRoles)
            .WithOne(accountRole => accountRole.Account)
            .HasForeignKey(accountRole => accountRole.AccountGuid);

        // Account - Employee
        modelBuilder.Entity<Account>()
            .HasOne(account => account.Employee)
            .WithOne(employee => employee.Account)
            .HasForeignKey<Account>(account => account.Guid);

        // Employee - Overtime 
        modelBuilder.Entity<Employee>()
            .HasMany(employee => employee.Overtimes)
            .WithOne(overtime => overtime.Employee)
            .HasForeignKey(overtime => overtime.EmployeeGuid);

        // Employee - Profile
        modelBuilder.Entity<Employee>()
            .HasOne(employee => employee.Profile)
            .WithOne(profile => profile.Employee)
            .HasForeignKey<Employee>(employee => employee.ProfileGuid);

        // Employee - Job
        modelBuilder.Entity<Employee>()
            .HasOne(employee => employee.Job)
            .WithOne(job => job.Employee)
            .HasForeignKey<Employee>(employee => employee.JobGuid);

        // Department - Job
        modelBuilder.Entity<Department>()
            .HasMany(department => department.Jobs)
            .WithOne(job => job.Department)
            .HasForeignKey(job => job.DepartmentGuid);

        // Employee - Department
        modelBuilder.Entity<Department>()
            .HasOne(department => department.Employee)
            .WithOne(employee => employee.Department)
            .HasForeignKey<Department>(employee => employee.ManagerGuid);

        // AccountRole - Role
        modelBuilder.Entity<Role>()
            .HasMany(role => role.AccountRoles)
            .WithOne(accountRole => accountRole.Role)
            .HasForeignKey(AccountRole => AccountRole.RoleGuid);
    }
}

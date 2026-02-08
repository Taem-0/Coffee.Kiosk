using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.CMS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string EmergencyFirstName { get; set; } = string.Empty;

        public string EmergencyLastName { get; set; } = string.Empty;

        public string EmergencyNumber { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public string? ProfilePicturePath { get; set; }

        public decimal Salary { get; set; } = decimal.Zero;

        public AccountRole Role { get; set; } = AccountRole.EMPLOYEE;

        public Department Department { get; set; } = Department.OPERATIONS;

        public EmploymentType EmploymentType { get; set; } = EmploymentType.FULL_TIME;


        public AccountStatus Status { get; set; } = AccountStatus.ACTIVE;

        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public bool IsFirstLogin { get; set; } = true;

        public bool PasswordResetRequested { get; set; } = false;
    }

    public enum AccountRole
    {
        EMPLOYEE,   
        MANAGER,
        OWNER
    }

    public enum Department
    {
        OPERATIONS,
        MANAGEMENT,
        ADMINISTRATION
    }

    public enum EmploymentType
    {
        FULL_TIME,
        PART_TIME,
        CONTRACT
    }


    public enum AccountStatus
    {
        ACTIVE,
        DEACTIVATED
    }
}


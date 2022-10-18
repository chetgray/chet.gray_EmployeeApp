using System;

namespace EmployeeApp.Models
{
    internal interface IEmployee
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        DateTime? EmploymentStartDate { get; set; }
        DateTime? EmploymentEndDate { get; set; }

        IAddress Address { get; set; }

        string FullName { get; }
    }
}

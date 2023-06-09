using System;

namespace EmployeeApp.Business.Models
{
    public interface IEmployeeModel
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        DateTime? EmploymentStartDate { get; set; }
        DateTime? EmploymentEndDate { get; set; }

        IAddressModel Address { get; set; }

        string FullName { get; }
    }
}

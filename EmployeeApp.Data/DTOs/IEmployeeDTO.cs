using System;

namespace EmployeeApp.Data.DTOs
{
    public interface IEmployeeDTO
    {
        int Id { get; set; }

        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        DateTime? EmploymentStartDate { get; set; }
        DateTime? EmploymentEndDate { get; set; }
        int? AddressId { get; set; }
    }
}

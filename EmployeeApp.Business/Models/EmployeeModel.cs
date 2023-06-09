using System;

namespace EmployeeApp.Business.Models
{
    public class EmployeeModel : IEmployeeModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }

        public IAddressModel Address { get; set; }

        public string FullName
        {
            get => $"{FirstName} {MiddleName} {LastName}";
        }
    }
}

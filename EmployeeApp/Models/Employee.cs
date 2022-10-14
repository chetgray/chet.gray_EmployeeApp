using System;

namespace EmployeeApp.Models
{
    internal class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get => $"{FirstName} {MiddleName} {LastName}";
        }
        public DateTime DateOfBirth { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime EmploymentEndDate { get; set; }
        public IAddress Address { get; set; }
    }
}

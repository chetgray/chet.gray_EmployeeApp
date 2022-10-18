using DataLibrary.DTOs;
using DataLibrary.Repositories;

using EmployeeApp.Models;

namespace EmployeeApp.Business
{
    internal class EmployeeBLL
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly AddressBLL _addressBLL = new AddressBLL();

        public IEmployee GetEmployeeById(int employeeId)
        {
            EmployeeDTO dto = _employeeRepository.GetEmployeeById(employeeId);
            IEmployee employee = new Employee()
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                EmploymentStartDate = dto.EmploymentStartDate,
                EmploymentEndDate = dto.EmploymentEndDate
            };
            if (dto.AddressId.HasValue)
            {
                employee.Address = _addressBLL.GetAddressById(dto.AddressId.Value);
            }
            return employee;
        }
    }
}

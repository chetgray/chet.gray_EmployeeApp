using System.Collections.Generic;

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

        public List<IEmployee> GetAllEmployees()
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetAllEmployees();
            List<IEmployee> employees = new List<IEmployee>();
            IEmployee employee;
            foreach (EmployeeDTO dto in dtos)
            {
                employee = new Employee()
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
                employees.Add(employee);
            }
            return employees;
        }
    }
}

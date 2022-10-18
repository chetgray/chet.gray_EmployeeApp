using System;
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

        public IEmployee GetById(int employeeId)
        {
            EmployeeDTO dto = _employeeRepository.GetById(employeeId);
            IEmployee employee = ConvertToModel(dto);

            return employee;
        }

        public List<IEmployee> GetAll()
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetAll();
            List<IEmployee> employees = new List<IEmployee>();

            foreach (EmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public List<IEmployee> GetByState(string state)
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetByState(state);
            List<IEmployee> employees = new List<IEmployee>();

            foreach (EmployeeDTO dto in dtos)
            {
                IEmployee employee = ConvertToModel(dto);
                employee.Address = new Address() { State = state };
                employees.Add(employee);
            }

            return employees;
        }

        internal List<IEmployee> GetByStartDateAfter(DateTime date)
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetByStartDateAfter(date);
            List<IEmployee> employees = new List<IEmployee>();

            foreach (EmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        private IEmployee ConvertToModel(EmployeeDTO dto)
        {
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
                employee.Address = _addressBLL.GetById(dto.AddressId.Value);
            }

            return employee;
        }
    }
}

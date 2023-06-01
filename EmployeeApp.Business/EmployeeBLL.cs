using System;
using System.Collections.Generic;

using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business
{
    public class EmployeeBLL
    {
        private readonly AddressBLL _addressBLL = new AddressBLL();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();

        public List<IEmployeeModel> GetAll()
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetAll();
            List<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (EmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IEmployeeModel GetById(int employeeId)
        {
            EmployeeDTO dto = _employeeRepository.GetById(employeeId);
            IEmployeeModel employee = ConvertToModel(dto);

            return employee;
        }

        public List<IEmployeeModel> GetByStartDateAfter(DateTime date)
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetByStartDateAfter(date);
            List<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (EmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public List<IEmployeeModel> GetByState(string state)
        {
            List<EmployeeDTO> dtos = _employeeRepository.GetByState(state);
            List<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (EmployeeDTO dto in dtos)
            {
                IEmployeeModel employee = ConvertToModel(dto);
                employee.Address.State = state;
                employees.Add(employee);
            }

            return employees;
        }

        private IEmployeeModel ConvertToModel(EmployeeDTO dto)
        {
            IEmployeeModel employee = new EmployeeModel()
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

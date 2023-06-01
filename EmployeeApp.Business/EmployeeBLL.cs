using System;
using System.Collections.Generic;

using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IAddressBLL _addressBLL = new AddressBLL();
        private readonly IEmployeeRepository _employeeRepository = new EmployeeRepository();

        public IList<IEmployeeModel> GetAll()
        {
            IList<IEmployeeDTO> dtos = _employeeRepository.GetAll();
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IEmployeeModel GetById(int employeeId)
        {
            IEmployeeDTO dto = _employeeRepository.GetById(employeeId);
            IEmployeeModel employee = ConvertToModel(dto);

            return employee;
        }

        public IList<IEmployeeModel> GetByStartDateAfter(DateTime date)
        {
            IList<IEmployeeDTO> dtos = _employeeRepository.GetByStartDateAfter(date);
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IList<IEmployeeModel> GetByState(string state)
        {
            IList<IEmployeeDTO> dtos = _employeeRepository.GetByState(state);
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                IEmployeeModel employee = ConvertToModel(dto);
                employee.Address.State = state;
                employees.Add(employee);
            }

            return employees;
        }

        private IEmployeeModel ConvertToModel(IEmployeeDTO dto)
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

using System;
using System.Collections.Generic;

using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business.BusinessLogic
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IEmployeeRepository _repository;
        private readonly IAddressBLL _addressBll;

        public EmployeeBLL(IEmployeeRepository repository, IAddressBLL addressBll)
        {
            _repository = repository;
            _addressBll = addressBll;
        }

        public IList<IEmployeeModel> GetAll()
        {
            IList<IEmployeeDTO> dtos = _repository.GetAll();
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IEmployeeModel GetById(int employeeId)
        {
            IEmployeeDTO dto = _repository.GetById(employeeId);
            IEmployeeModel employee = ConvertToModel(dto);

            return employee;
        }

        public IList<IEmployeeModel> GetByStartDateAfter(DateTime date)
        {
            IList<IEmployeeDTO> dtos = _repository.GetByStartDateAfter(date);
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IList<IEmployeeModel> GetByState(string state)
        {
            IList<IEmployeeDTO> dtos = _repository.GetByState(state);
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
            IEmployeeModel employee = Factory.GetNewEmployeeModel(
                dto.FirstName,
                dto.MiddleName,
                dto.LastName,
                dto.DateOfBirth,
                dto.EmploymentStartDate,
                dto.EmploymentEndDate
            );
            if (dto.AddressId.HasValue)
            {
                employee.Address = _addressBll.GetById(dto.AddressId.Value);
            }

            return employee;
        }
    }
}

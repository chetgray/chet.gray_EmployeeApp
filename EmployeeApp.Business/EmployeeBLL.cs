using System;
using System.Collections.Generic;

using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

using Unity;

namespace EmployeeApp.Business
{
    public class EmployeeBLL : IEmployeeBLL
    {
        [Dependency]
        public IAddressBLL AddressBll { get; } = UnityBootstrapper.Resolve<IAddressBLL>();

        [Dependency]
        public IEmployeeRepository EmployeeRepository { get; } =
            UnityBootstrapper.Resolve<IEmployeeRepository>();

        public IList<IEmployeeModel> GetAll()
        {
            IList<IEmployeeDTO> dtos = EmployeeRepository.GetAll();
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IEmployeeModel GetById(int employeeId)
        {
            IEmployeeDTO dto = EmployeeRepository.GetById(employeeId);
            IEmployeeModel employee = ConvertToModel(dto);

            return employee;
        }

        public IList<IEmployeeModel> GetByStartDateAfter(DateTime date)
        {
            IList<IEmployeeDTO> dtos = EmployeeRepository.GetByStartDateAfter(date);
            IList<IEmployeeModel> employees = new List<IEmployeeModel>();

            foreach (IEmployeeDTO dto in dtos)
            {
                employees.Add(ConvertToModel(dto));
            }

            return employees;
        }

        public IList<IEmployeeModel> GetByState(string state)
        {
            IList<IEmployeeDTO> dtos = EmployeeRepository.GetByState(state);
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
            IEmployeeModel employee = UnityBootstrapper.Resolve<IEmployeeModel>();
            employee.FirstName = dto.FirstName;
            employee.MiddleName = dto.MiddleName;
            employee.LastName = dto.LastName;
            employee.DateOfBirth = dto.DateOfBirth;
            employee.EmploymentStartDate = dto.EmploymentStartDate;
            employee.EmploymentEndDate = dto.EmploymentEndDate;
            if (dto.AddressId.HasValue)
            {
                employee.Address = AddressBll.GetById(dto.AddressId.Value);
            }

            return employee;
        }
    }
}

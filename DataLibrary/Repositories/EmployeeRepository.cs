using System;
using System.Collections.Generic;

using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class EmployeeRepository
    {
        public EmployeeDTO GetById(int employeeId)
        {
            EmployeeDTO employee = new EmployeeDTO() { Id = employeeId };

            return employee;
        }

        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            employees.Add(GetById(0));
            employees[0].LastName = "I AM EVERYONE";

            return employees;
        }

        public List<EmployeeDTO> GetByState(string state)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            employees.Add(GetById(0));
            employees[0].LastName = $"I live in {state}";

            return employees;
        }

        public List<EmployeeDTO> GetByStartDateAfter(DateTime date)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            employees.Add(GetById(0));
            employees[0].LastName = $"I started after {date:yyyy-MM-dd}";
            employees[0].EmploymentStartDate = date.AddDays(1);

            return employees;
        }
    }
}

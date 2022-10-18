using System.Collections.Generic;

using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class EmployeeRepository
    {
        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            EmployeeDTO employee = new EmployeeDTO() { Id = employeeId };

            return employee;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            employees.Add(GetEmployeeById(0));

            return employees;
        }
    }
}

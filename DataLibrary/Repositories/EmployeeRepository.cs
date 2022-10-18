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

            return employees;
        }
    }
}

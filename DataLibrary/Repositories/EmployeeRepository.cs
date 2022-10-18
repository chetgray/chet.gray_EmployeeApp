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
    }
}

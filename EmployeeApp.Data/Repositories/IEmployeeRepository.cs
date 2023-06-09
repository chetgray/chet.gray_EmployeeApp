using System;
using System.Collections.Generic;

using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public interface IEmployeeRepository
    {
        IList<IEmployeeDTO> GetAll();
        IEmployeeDTO GetById(int employeeId);
        IList<IEmployeeDTO> GetByStartDateAfter(DateTime startDate);
        IList<IEmployeeDTO> GetByState(string state);
    }
}

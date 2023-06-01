using System;
using System.Collections.Generic;

using EmployeeApp.Business.Models;

namespace EmployeeApp.Business
{
    public interface IEmployeeBLL
    {
        IList<IEmployeeModel> GetAll();
        IEmployeeModel GetById(int employeeId);
        IList<IEmployeeModel> GetByStartDateAfter(DateTime date);
        IList<IEmployeeModel> GetByState(string state);
    }
}

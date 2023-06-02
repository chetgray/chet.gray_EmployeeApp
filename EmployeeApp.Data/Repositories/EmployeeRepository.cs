using System;
using System.Collections.Generic;

using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(IDAL dal) : base(dal) { }

        public IList<IEmployeeDTO> GetAll()
        {
            IList<IEmployeeDTO> employees = Factory.GetNewEmployeeDTOList();
            IList<object[]> records = _dal.GetRecordListFromStoredProcedure(
                "spEmployeeGetAll",
                new Dictionary<string, object>()
            );

            foreach (object[] record in records)
            {
                employees.Add(ConvertToDto(record));
            }

            return employees;
        }

        public IEmployeeDTO GetById(int employeeId)
        {
            IList<object[]> records = _dal.GetRecordListFromStoredProcedure(
                "spEmployeeGetById",
                new Dictionary<string, object>() { { "@employeeId", employeeId } }
            );

            if (records.Count == 0)
            {
                return null;
            }

            IEmployeeDTO employee = ConvertToDto(records[0]);
            return employee;
        }

        public IList<IEmployeeDTO> GetByStartDateAfter(DateTime startDate)
        {
            IList<IEmployeeDTO> employees = Factory.GetNewEmployeeDTOList();
            IList<object[]> records = _dal.GetRecordListFromStoredProcedure(
                "spEmployeeGetByStartDateAfter",
                new Dictionary<string, object> { { "@startDate", startDate } }
            );

            foreach (object[] record in records)
            {
                employees.Add(ConvertToDto(record));
            }

            return employees;
        }

        public IList<IEmployeeDTO> GetByState(string state)
        {
            IList<IEmployeeDTO> employees = Factory.GetNewEmployeeDTOList();
            IList<object[]> records = _dal.GetRecordListFromStoredProcedure(
                "spEmployeeGetByState",
                new Dictionary<string, object> { { "@state", state } }
            );

            foreach (object[] record in records)
            {
                employees.Add(ConvertToDto(record));
            }

            return employees;
        }

        private static IEmployeeDTO ConvertToDto(object[] record)
        {
            IEmployeeDTO employee = Factory.GetNewEmployeeDTO(
                id: (int)record[0],
                firstName: (string)record[1],
                middleName: (string)record[2],
                lastName: (string)record[3],
                dateOfBirth: record[4] is null
                    ? null
                    : (DateTime?)DateTime.Parse((string)record[4]),
                employmentStartDate: record[5] is null
                    ? null
                    : (DateTime?)DateTime.Parse((string)record[5]),
                employmentEndDate: record[6] is null
                    ? null
                    : (DateTime?)DateTime.Parse((string)record[6]),
                addressId: (int?)record[7]
            );

            return employee;
        }
    }
}

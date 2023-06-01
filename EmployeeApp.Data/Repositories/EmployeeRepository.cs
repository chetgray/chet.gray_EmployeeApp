using System;
using System.Collections.Generic;

using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public IList<IEmployeeDTO> GetAll()
        {
            IList<IEmployeeDTO> employees = new List<IEmployeeDTO>();
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
            IList<IEmployeeDTO> employees = new List<IEmployeeDTO>();
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
            IList<IEmployeeDTO> employees = new List<IEmployeeDTO>();
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
            IEmployeeDTO employee = new EmployeeDTO
            {
                Id = (int)record[0],
                FirstName = (string)record[1],
                MiddleName = (string)record[2],
                LastName = (string)record[3],
                DateOfBirth = record[4] is null
                    ? null
                    : (DateTime?)DateTime.Parse((string)record[4]),
                EmploymentStartDate = record[5] is null
                    ? null
                    : (DateTime?)DateTime.Parse((string)record[5]),
                EmploymentEndDate = record[6] is null
                    ? null
                    : (DateTime?)DateTime.Parse((string)record[6]),
                AddressId = (int?)record[7]
            };

            return employee;
        }
    }
}

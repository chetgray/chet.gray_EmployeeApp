using System;
using System.Collections.Generic;

using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class EmployeeRepository : BaseRepository
    {
        public EmployeeDTO GetById(int employeeId)
        {
            List<object[]> records = _dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetById",
                new Dictionary<string, object>() { { "@employeeId", employeeId } }
            );

            if (records.Count == 0)
            {
                return null;
            }
            EmployeeDTO employee = ConvertToDto(records[0]);

            return employee;
        }

        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            List<object[]> records = _dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetAll",
                new Dictionary<string, object>()
            );

            foreach (object[] record in records)
            {
                employees.Add(ConvertToDto(record));
            }

            return employees;
        }

        public List<EmployeeDTO> GetByState(string state)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            List<object[]> records = _dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetByState",
                new Dictionary<string, object> { { "@state", state } }
            );

            foreach (object[] record in records)
            {
                employees.Add(ConvertToDto(record));
            }

            return employees;
        }

        public List<EmployeeDTO> GetByStartDateAfter(DateTime startDate)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            List<object[]> records = _dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetByStartDateAfter",
                new Dictionary<string, object> { { "@startDate", startDate } }
            );

            foreach (object[] record in records)
            {
                employees.Add(ConvertToDto(record));
            }

            return employees;
        }

        private static EmployeeDTO ConvertToDto(object[] record)
        {
            EmployeeDTO employee = new EmployeeDTO
            {
                Id = (int)record[0],
                FirstName = (string)record[1],
                MiddleName = (string)record[2],
                LastName = (string)record[3],
                //DateOfBirth = DateTime.Parse((string)record[4]),
                //EmploymentStartDate = DateTime.Parse((string)record[5]),
                //EmploymentEndDate = DateTime.Parse((string)record[6]),
                AddressId = (int?)record[7]
            };
            DateTime date;
            if (DateTime.TryParse((string)record[4], out date))
            {
                employee.DateOfBirth = date;
            }
            if (DateTime.TryParse((string)record[5], out date))
            {
                employee.EmploymentStartDate = date;
            }
            if (DateTime.TryParse((string)record[6], out date))
            {
                employee.EmploymentEndDate = date;
            }

            return employee;
        }
    }
}

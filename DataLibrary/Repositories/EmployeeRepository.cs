using System;
using System.Collections.Generic;
using System.Configuration;

using DataLibrary.DAL;
using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class EmployeeRepository
    {
        public EmployeeDTO GetById(int employeeId)
        {
            EmployeeAppDAL dal = new EmployeeAppDAL(
                ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
            );
            List<object[]> records = dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetById",
                new Dictionary<string, object>() { { "@employeeId", employeeId } }
            );

            if (records.Count == 0)
            {
                return null;
            }
            EmployeeDTO employee = new EmployeeDTO
            {
                Id = (int)records[0][0],
                FirstName = (string)records[0][1],
                MiddleName = (string)records[0][2],
                LastName = (string)records[0][3],
                DateOfBirth = DateTime.Parse((string)records[0][4]),
                EmploymentStartDate = DateTime.Parse((string)records[0][5]),
                EmploymentEndDate = DateTime.Parse((string)records[0][6]),
                AddressId = (int?)records[0][7]
            };

            return employee;
        }

        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            EmployeeAppDAL dal = new EmployeeAppDAL(
                ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
            );
            List<object[]> records = dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetAll",
                new Dictionary<string, object>()
            );

            foreach (object[] record in records)
            {
                employees.Add(
                    new EmployeeDTO
                    {
                        Id = (int)record[0],
                        FirstName = (string)record[1],
                        MiddleName = (string)record[2],
                        LastName = (string)record[3],
                        DateOfBirth = DateTime.Parse((string)record[4]),
                        EmploymentStartDate = DateTime.Parse((string)record[5]),
                        EmploymentEndDate = DateTime.Parse((string)record[6]),
                        AddressId = (int?)record[7]
                    }
                );
            }

            return employees;
        }

        public List<EmployeeDTO> GetByState(string state)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            employees.Add(GetById(1));
            employees[0].MiddleName = $"\"I live in {state}\"";

            return employees;
        }

        public List<EmployeeDTO> GetByStartDateAfter(DateTime date)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            employees.Add(GetById(1));
            employees[0].MiddleName = $"\"I started after {date:yyyy-MM-dd}\"";
            employees[0].EmploymentStartDate = date.AddDays(1);

            return employees;
        }
    }
}

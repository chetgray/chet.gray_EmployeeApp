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
                employees.Add(employee);
            }

            return employees;
        }

        public List<EmployeeDTO> GetByState(string state)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            EmployeeAppDAL dal = new EmployeeAppDAL(
                ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
            );
            List<object[]> records = dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetByState",
                new Dictionary<string, object> { { "@state", state } }
            );

            foreach (object[] record in records)
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
                employees.Add(employee);
            }

            return employees;
        }

        public List<EmployeeDTO> GetByStartDateAfter(DateTime startDate)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            EmployeeAppDAL dal = new EmployeeAppDAL(
                ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
            );
            List<object[]> records = dal.GetRecordsViaStoredProcedure(
                "spEmployeeGetByStartDateAfter",
                new Dictionary<string, object> { { "@startDate", startDate } }
            );

            foreach (object[] record in records)
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
                employees.Add(employee);
            }

            return employees;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Data
{
    public static class Factory
    {
        public static IAddressDTO GetNewAddressDTO(
            int id = default,
            string streetAddress = default,
            string city = default,
            string state = default,
            string zip = default
        )
        {
            IAddressDTO dto = new AddressDTO
            {
                Id = id,
                StreetAddress = streetAddress,
                City = city,
                State = state,
                Zip = zip
            };
            return dto;
        }

        public static IEmployeeDTO GetNewEmployeeDTO(
            int id = default,
            string firstName = default,
            string middleName = default,
            string lastName = default,
            DateTime? dateOfBirth = default,
            DateTime? employmentStartDate = default,
            DateTime? employmentEndDate = default,
            int? addressId = default
        )
        {
            IEmployeeDTO dto = new EmployeeDTO
            {
                Id = id,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                EmploymentStartDate = employmentStartDate,
                EmploymentEndDate = employmentEndDate,
                AddressId = addressId
            };
            return dto;
        }

        public static IList<IEmployeeDTO> GetNewEmployeeDTOList()
        {
            IList<IEmployeeDTO> list = new List<IEmployeeDTO>();
            return list;
        }

        public static IAddressRepository GetNewAddressRepository(IDAL dal)
        {
            IAddressRepository repository = new AddressRepository(dal);
            return repository;
        }

        public static IEmployeeRepository GetNewEmployeeRepository(IDAL dal)
        {
            IEmployeeRepository repository = new EmployeeRepository(dal);
            return repository;
        }

        public static IDAL GetNewDAL(
            string connectionString,
            Func<string, SqlConnection> connectionFactory,
            Func<string, SqlConnection, SqlCommand> commandFactory,
            Func<int, object[]> recordFactory,
            Func<IList<object[]>> recordListFactory
        )
        {
            IDAL dal = new DAL(
                connectionString,
                connectionFactory,
                commandFactory,
                recordFactory,
                recordListFactory
            );
            return dal;
        }

        public static SqlConnection GetNewConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public static SqlCommand GetNewCommand(string commandText, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            return command;
        }

        public static object[] GetNewRecord(int fieldCount)
        {
            object[] record = new object[fieldCount];
            return record;
        }

        public static IList<object[]> GetNewRecordList()
        {
            IList<object[]> list = new List<object[]>();
            return list;
        }
    }
}

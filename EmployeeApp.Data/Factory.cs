using System;

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

        public static IDAL GetNewDAL(string connectionString)
        {
            IDAL dal = new DAL(connectionString);
            return dal;
        }
    }
}

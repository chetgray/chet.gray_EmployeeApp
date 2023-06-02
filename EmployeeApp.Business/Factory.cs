using System;
using System.Collections.Generic;

using EmployeeApp.Business.BusinessLogic;
using EmployeeApp.Business.Models;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business
{
    public static class Factory
    {
        public static IAddressModel GetNewAddressModel(
            string streetAddress = default,
            string city = default,
            string state = default,
            string zip = default
        )
        {
            IAddressModel model = new AddressModel
            {
                StreetAddress = streetAddress,
                City = city,
                State = state,
                Zip = zip
            };
            return model;
        }

        public static IEmployeeModel GetNewEmployeeModel(
            string firstName = default,
            string middleName = default,
            string lastName = default,
            DateTime? dateOfBirth = default,
            DateTime? employmentStartDate = default,
            DateTime? employmentEndDate = default,
            IAddressModel address = default
        )
        {
            IEmployeeModel model = new EmployeeModel
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                EmploymentStartDate = employmentStartDate,
                EmploymentEndDate = employmentEndDate,
                Address = address
            };
            return model;
        }

        public static IList<IEmployeeModel> GetNewEmployeeModelList()
        {
            IList<IEmployeeModel> list = new List<IEmployeeModel>();
            return list;
        }

        public static IAddressBLL GetNewAddressBLL(IAddressRepository repository)
        {
            IAddressBLL bll = new AddressBLL(repository);
            return bll;
        }

        public static IEmployeeBLL GetNewEmployeeBLL(
            IEmployeeRepository repository,
            IAddressBLL addressBLL
        )
        {
            IEmployeeBLL bll = new EmployeeBLL(repository, addressBLL);
            return bll;
        }
    }
}

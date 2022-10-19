using System.Collections.Generic;
using System.Configuration;

using DataLibrary.DAL;
using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class AddressRepository
    {
        public AddressDTO GetById(int addressId)
        {
            IEmployeeAppDAL dal = new EmployeeAppDAL(
                ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
            );
            List<object[]> records = dal.GetRecordsViaStoredProcedure(
                "dbo.spAddressGetById",
                new Dictionary<string, object> { { "@addressId", addressId } }
            );

            if (records.Count == 0)
            {
                return null;
            }
            AddressDTO address = new AddressDTO
            {
                Id = (int)records[0][0],
                StreetAddress = (string)records[0][1],
                City = (string)records[0][2],
                State = (string)records[0][3],
                Zip = (string)records[0][4]
            };

            return address;
        }
    }
}

using System.Collections.Generic;

using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public IAddressDTO GetById(int addressId)
        {
            IList<object[]> records = _dal.GetRecordListFromStoredProcedure(
                "dbo.spAddressGetById",
                new Dictionary<string, object> { { "@addressId", addressId } }
            );

            if (records.Count == 0)
            {
                return null;
            }

            IAddressDTO address = ConvertToDto(records[0]);
            return address;
        }

        private static IAddressDTO ConvertToDto(object[] record)
        {
            IAddressDTO address = new AddressDTO
            {
                Id = (int)record[0],
                StreetAddress = (string)record[1],
                City = (string)record[2],
                State = (string)record[3],
                Zip = (string)record[4]
            };

            return address;
        }
    }
}

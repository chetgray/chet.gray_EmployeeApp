using System.Collections.Generic;

using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public IAddressDTO GetById(int addressId)
        {
            IList<object[]> records = Dal.GetRecordListFromStoredProcedure(
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
            IAddressDTO address = UnityBootstrapper.Resolve<IAddressDTO>();
            address.Id = (int)record[0];
            address.StreetAddress = (string)record[1];
            address.City = (string)record[2];
            address.State = (string)record[3];
            address.Zip = (string)record[4];

            return address;
        }
    }
}

using System.Collections.Generic;

using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public AddressRepository(IDAL dal) : base(dal) { }

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
            IAddressDTO address = Factory.GetNewAddressDTO(
                id: (int)record[0],
                streetAddress: (string)record[1],
                city: (string)record[2],
                state: (string)record[3],
                zip: (string)record[4]
            );

            return address;
        }
    }
}

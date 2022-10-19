using System.Collections.Generic;

using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class AddressRepository : BaseRepository
    {
        public AddressDTO GetById(int addressId)
        {
            List<object[]> records = _dal.GetRecordsViaStoredProcedure(
                "dbo.spAddressGetById",
                new Dictionary<string, object> { { "@addressId", addressId } }
            );

            if (records.Count == 0)
            {
                return null;
            }
            AddressDTO address = ConvertToDto(records[0]);

            return address;
        }

        private static AddressDTO ConvertToDto(object[] record)
        {
            AddressDTO address = new AddressDTO
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

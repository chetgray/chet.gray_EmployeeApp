using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business
{
    public class AddressBLL
    {
        private readonly AddressRepository _addressRepository = new AddressRepository();

        public IAddressModel GetById(int addressId)
        {
            AddressDTO dto = _addressRepository.GetById(addressId);
            IAddressModel address = ConvertToModel(dto);

            return address;
        }

        private static IAddressModel ConvertToModel(AddressDTO dto)
        {
            IAddressModel address = new AddressModel()
            {
                StreetAddress = dto.StreetAddress,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip
            };

            return address;
        }
    }
}

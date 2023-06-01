using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business
{
    public class AddressBLL : IAddressBLL
    {
        private readonly IAddressRepository _addressRepository = new AddressRepository();

        public IAddressModel GetById(int addressId)
        {
            IAddressDTO dto = _addressRepository.GetById(addressId);
            IAddressModel address = ConvertToModel(dto);

            return address;
        }

        private static IAddressModel ConvertToModel(IAddressDTO dto)
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

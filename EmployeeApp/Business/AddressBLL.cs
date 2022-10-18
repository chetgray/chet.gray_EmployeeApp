using DataLibrary.DTOs;
using DataLibrary.Repositories;

using EmployeeApp.Models;

namespace EmployeeApp.Business
{
    internal class AddressBLL
    {
        private readonly AddressRepository _addressRepository = new AddressRepository();

        public Address GetAddressById(int addressId)
        {
            AddressDTO dto = _addressRepository.GetAddressById(addressId);
            Address address = new Address()
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

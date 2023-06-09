using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

using Unity;

namespace EmployeeApp.Business
{
    public class AddressBLL : IAddressBLL
    {
        [Dependency]
        public IAddressRepository AddressRepository { get; } =
            UnityBootstrapper.Resolve<IAddressRepository>();

        public IAddressModel GetById(int addressId)
        {
            IAddressDTO dto = AddressRepository.GetById(addressId);
            IAddressModel address = ConvertToModel(dto);

            return address;
        }

        private static IAddressModel ConvertToModel(IAddressDTO dto)
        {
            IAddressModel address = UnityBootstrapper.Resolve<IAddressModel>();
            address.StreetAddress = dto.StreetAddress;
            address.City = dto.City;
            address.State = dto.State;
            address.Zip = dto.Zip;

            return address;
        }
    }
}

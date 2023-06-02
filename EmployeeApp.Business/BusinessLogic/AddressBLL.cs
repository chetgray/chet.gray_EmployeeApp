using EmployeeApp.Business.Models;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

namespace EmployeeApp.Business.BusinessLogic
{
    public class AddressBLL : IAddressBLL
    {
        private readonly IAddressRepository _repository;

        public AddressBLL(IAddressRepository repository)
        {
            _repository =
                repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IAddressModel GetById(int addressId)
        {
            IAddressDTO dto = _repository.GetById(addressId);
            IAddressModel address = ConvertToModel(dto);

            return address;
        }

        private static IAddressModel ConvertToModel(IAddressDTO dto)
        {
            IAddressModel address = Factory.GetNewAddressModel(
                dto.StreetAddress,
                dto.City,
                dto.State,
                dto.Zip
            );

            return address;
        }
    }
}

using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class AddressRepository
    {
        public AddressDTO GetAddressById(int addressId)
        {
            AddressDTO address = new AddressDTO() { Id = addressId };

            return address;
        }
    }
}

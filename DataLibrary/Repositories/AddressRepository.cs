using DataLibrary.DTOs;

namespace DataLibrary.Repositories
{
    public class AddressRepository
    {
        public AddressDTO GetById(int addressId)
        {
            AddressDTO address = new AddressDTO() { Id = addressId };

            return address;
        }
    }
}

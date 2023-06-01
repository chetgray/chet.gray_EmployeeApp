using EmployeeApp.Data.DTOs;

namespace EmployeeApp.Data.Repositories
{
    public interface IAddressRepository
    {
        IAddressDTO GetById(int addressId);
    }
}

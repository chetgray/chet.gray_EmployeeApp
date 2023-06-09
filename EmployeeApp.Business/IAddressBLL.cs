using EmployeeApp.Business.Models;

namespace EmployeeApp.Business
{
    public interface IAddressBLL
    {
        IAddressModel GetById(int addressId);
    }
}

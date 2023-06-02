using EmployeeApp.Business.Models;

namespace EmployeeApp.Business.BusinessLogic
{
    public interface IAddressBLL
    {
        IAddressModel GetById(int addressId);
    }
}

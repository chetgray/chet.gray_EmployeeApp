namespace EmployeeApp.Business.Models
{
    public interface IAddressModel
    {
        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }

        string FullAddress { get; }
    }
}

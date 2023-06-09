namespace EmployeeApp.Data.DTOs
{
    public interface IAddressDTO
    {
        int Id { get; set; }

        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}

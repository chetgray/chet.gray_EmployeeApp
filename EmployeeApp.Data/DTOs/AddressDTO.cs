namespace EmployeeApp.Data.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}

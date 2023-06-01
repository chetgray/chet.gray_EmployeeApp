namespace EmployeeApp.Business.Models
{
    public class AddressModel : IAddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string FullAddress
        {
            get => $"{StreetAddress}, {City}, {State} {Zip}";
        }
    }
}

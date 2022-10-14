namespace EmployeeApp.Models
{
    internal class Address : IAddress
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

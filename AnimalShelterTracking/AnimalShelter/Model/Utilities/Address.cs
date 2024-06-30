namespace AnimalShelter.Model.Utilities
{
    public class Address
    {
        public string Country { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalNumber { get; set; }

        public Address() { }

        public Address(string country, string town, string street, string houseNumber, string postalNumber)
        {
            Country = country;
            Town = town;
            Street = street;
            HouseNumber = houseNumber;
            PostalNumber = postalNumber;
        }

    }
}

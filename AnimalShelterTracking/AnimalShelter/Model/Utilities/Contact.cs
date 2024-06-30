namespace AnimalShelter.Model.Utilities
{
    public class Contact
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string InstagramLabel { get; set; }

        public Contact() { }

        public Contact(string phoneNumber, string email, string instagramLabel)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            InstagramLabel = instagramLabel;
        }
    }
}

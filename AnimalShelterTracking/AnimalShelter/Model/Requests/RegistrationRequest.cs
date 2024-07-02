using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Utilities;

namespace AnimalShelter.Model.Requests
{
    public class RegistrationRequest : Request
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdCardNumber { get; set; }

        public RegistrationRequest() { RequestType = RequestType.REGISTRATION; }

        public RegistrationRequest(string name, string surname, string phoneNumber, string email, string password, string idCardNumber, Address address)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            RequestType = RequestType.REGISTRATION;
            IdCardNumber = idCardNumber;
            Address = address;
        }

        public RegistrationRequest(string name, string surname, string phoneNumber, string email, string password, string idCardNumber, RequestType requestType, Address address)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            RequestType = requestType;
            IdCardNumber = idCardNumber;
            Address = address;
        }

    }
}
